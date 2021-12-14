using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteLibroRequest>
        .WithoutResponse
    {
        private readonly IRepository<Libros> _repository;

        public Delete(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteLibroRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Libros",
            Description = "Deletes a Libros",
            OperationId = "Libross.Delete",
            Tags = new[] { "LibrosEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteLibroRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.LibroId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}
