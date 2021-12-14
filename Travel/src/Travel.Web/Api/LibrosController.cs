using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate.Specifications;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;
using Travel.Web.ApiModels;

namespace Travel.Web.Api
{
    /// <summary>
    /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
    /// https://github.com/ardalis/ApiEndpoints
    /// </summary>
    public class LibrosController : BaseApiController
    {
        private readonly IRepository<Libros> _repository;

        public LibrosController(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var LibrosDTOs = (await _repository.ListAsync())
                .Select(libros => new LibrosDTO
                {
                    ISBN = libros.ISBN,
                    Titulo = libros.Titulo,
                    NPaginas = libros.NPaginas,
                    Sinopsis = libros.Sinopsis,
                    EditorialesId = libros.EditorialesId
                })
                .ToList();

            return Ok(LibrosDTOs);
        }

        // GET: api/Libros
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var librospec = new LibrosByIdWithLibrosSpec(id);
            var libros = await _repository.GetBySpecAsync(librospec);

            var result = new LibrosDTO
            {
                ISBN = libros.ISBN,
                Titulo = libros.Titulo,
                NPaginas = libros.NPaginas,
                EditorialesId = libros.EditorialesId,
                Autor = libros.Items.FirstOrDefault()?.AutoresNavigation?.Nombre+""+
                libros.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos,
                Editorial = libros.EditorialesNavigation?.Nombre,
                Sinopsis = libros.Sinopsis
                //Items = new List<LibrosHasLibrosDTO>
                //(
                //    Libros.Items.Select(i => LibrosHasLibrosDTO.FromLibrosHasLibros(i)).ToList()
                //)
            };

            return Ok(result);
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLibroDTO request)
        {
            var newLibros = new Libros(request.EditorialesId, request.Titulo, request.Sinopsis, request.NPaginas);

            var createdLibros = await _repository.AddAsync(newLibros);

            var result = new LibrosDTO
            {
                ISBN = createdLibros.ISBN,
                Titulo = createdLibros.Titulo,
                NPaginas = createdLibros.NPaginas,
                Autor = createdLibros.Items.FirstOrDefault()?.AutoresNavigation?.Nombre+" "+
                    createdLibros.Items.FirstOrDefault()?.AutoresNavigation?.Apellidos,
                Editorial = createdLibros.EditorialesNavigation?.Nombre,
                Sinopsis = createdLibros.Sinopsis
            };
            return Ok(result);
        }

    }
}
