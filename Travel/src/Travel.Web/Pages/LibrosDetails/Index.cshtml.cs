using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;
using Travel.Web.ApiModels;

namespace Travel.Web.Pages.LibrosRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Libros> _repository;

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; } = "";

        public List<LibrosDTO> Libros { get; set; }

        public IndexModel(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            Libros = new List<LibrosDTO>();
            var projectSpec = new LibrosWithSpec();
            var projects = await _repository.ListAsync(projectSpec);

            if (projects.Count == 0)
            {
                Message = "No se encontró registros.";
                return;
            }
            foreach (var project in projects)
            {
                Libros.Add( new LibrosDTO
                {
                    ISBN = project.ISBN,
                    Titulo = project.Titulo,
                    NPaginas = project.NPaginas,
                    Autor = project.Items.FirstOrDefault()?.AutoresNavigation?.Nombre + " " +
                        project.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos,
                    Editorial = project.EditorialesNavigation?.Nombre,
                    Sinopsis = project.Sinopsis
                });

            }
            
        }
    }
}
