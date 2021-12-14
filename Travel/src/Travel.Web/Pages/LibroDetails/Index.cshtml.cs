using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;
using Travel.Web.ApiModels;

namespace Travel.Web.Pages.LibroRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Libros> _repository;

        [BindProperty(SupportsGet = true)]
        public long LibroId { get; set; }
        public string Message { get; set; } = "";

        public LibrosDTO Libro { get; set; }

        public IndexModel(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new LibrosByIdWithLibrosSpec(LibroId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            if (project == null)
            {
                Message = "Libro no encontrado.";
                return;
            }

            Libro = new LibrosDTO
            {
                ISBN = project.ISBN,
                Titulo = project.Titulo,
                NPaginas = project.NPaginas,
                Autor = project.Items.FirstOrDefault()?.AutoresNavigation?.Nombre+" "+
                    project.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos,
                Editorial = project.EditorialesNavigation?.Nombre,
                Sinopsis = project.Sinopsis
            };
        }
    }
}
