using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetLibroByIdRequest>
        .WithResponse<GetLibroByIdResponse>
    {
        private readonly IRepository<Libros> _repository;

        public GetById(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        [HttpGet(GetLibroByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single Libro",
            Description = "Gets a single Libro by Id",
            OperationId = "Libros.GetById",
            Tags = new[] { "LibroEndpoints" })
        ]
        public override async Task<ActionResult<GetLibroByIdResponse>> HandleAsync([FromRoute] GetLibroByIdRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new LibrosByIdWithLibrosSpec(request.LibroId);
            var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
            if (entity == null) return NotFound();
            var response = new GetLibroByIdResponse
            {
                ISBN = entity.ISBN,
                EditorialesId = entity.EditorialesId,
                Titulo = entity.Titulo,
                Sinopsis = entity.Sinopsis,
                NPaginas = entity.NPaginas
            };
            return Ok(response);
        }
    }
}
