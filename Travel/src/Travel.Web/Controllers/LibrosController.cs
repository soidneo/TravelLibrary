using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;
using Travel.Web.ViewModels;

namespace Travel.Web.Controllers
{
    [Route("[controller]")]
    public class LibrosController : Controller
    {
        private readonly IRepository<Libros> _librosRepository;

        public LibrosController(IRepository<Libros> LibrosRepository)
        {
            _librosRepository = LibrosRepository;
        }


        // GET Libros/{LibrosId?}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dto = new List<LibrosViewModel>();
            var spec = new LibrosWithSpec();
            var libros = await _librosRepository.ListAsync(specification: spec);
            foreach (var libro in libros)
            {
                var autor = libro.Items.FirstOrDefault()?.AutoresNavigation?.Nombre +" " +
                    libro.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos;
                var editorial = libro.EditorialesNavigation?.Nombre;
                dto.Add(new LibrosViewModel
                {
                    ISBN = libro.ISBN,
                    EditorialesId = libro.EditorialesId,
                    NPaginas = libro.NPaginas,
                    Sinopsis = libro.Sinopsis,
                    Titulo = libro.Titulo,
                    Editorial = editorial,
                    Autor = autor
                });
            }
            
            return View(dto);
        }

        // GET Libros/{LibrosId?}
        [HttpGet("{LibrosId:int}")]
        public async Task<IActionResult> Get(int LibrosId = 1)
        {
            var spec = new LibrosByIdWithLibrosSpec(LibrosId);
            var libro = await _librosRepository.GetBySpecAsync(spec);
            var autor = libro.Items.FirstOrDefault()?.AutoresNavigation?.Nombre +" "+ 
                libro.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos;
            var editorial = libro.EditorialesNavigation?.Nombre;
            var dto = new LibrosViewModel
            {
                ISBN = libro.ISBN,
                EditorialesId = libro.EditorialesId,
                NPaginas = libro.NPaginas,
                Sinopsis = libro.Sinopsis,
                Autor = autor,
                Editorial = editorial,
                Titulo = libro.Titulo
            };
            return View(dto);
        }
    }
}
