using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateLibroRequest>
        .WithResponse<CreateLibroResponse>
    {
        private readonly IRepository<Libros> _repository;

        public Create(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        [HttpPost("/CLibros")]
        [SwaggerOperation(
            Summary = "Creates a new Libros",
            Description = "Creates a new Libros",
            OperationId = "Libros.Create",
            Tags = new[] { "LibrosEndpoints" })
        ]
        public override async Task<ActionResult<CreateLibroResponse>> HandleAsync(CreateLibroRequest request,
            CancellationToken cancellationToken)
        {
            var newLibros = new Libros( request.EditorialesId, request.Titulo, request.Sinopsis, request.NPaginas);

            var createdItem = await _repository.AddAsync(newLibros); // TODO: pass cancellation token

            var response = new CreateLibroResponse
            {
                ISBN = createdItem.ISBN,
                EditorialesId = createdItem.EditorialesId,
                Titulo = createdItem.Titulo,
                Sinopsis = createdItem.Sinopsis,
                NPaginas = createdItem.NPaginas
            };

            return Ok(response);
        }
    }
}
