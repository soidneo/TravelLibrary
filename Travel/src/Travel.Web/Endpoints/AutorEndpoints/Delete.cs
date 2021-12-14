using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteAutorRequest>
        .WithoutResponse
    {
        private readonly IRepository<Autores> _repository;

        public Delete(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteAutorRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Autores",
            Description = "Deletes a Autores",
            OperationId = "Autoress.Delete",
            Tags = new[] { "AutoresEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteAutorRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.AutorId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}
