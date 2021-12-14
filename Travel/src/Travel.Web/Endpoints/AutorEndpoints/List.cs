using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<AutoresListResponse>
    {
        private readonly IReadRepository<Autores> _repository;

        public List(IReadRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpGet("/CAutores")]
        [SwaggerOperation(
            Summary = "Gets a list of all Autores",
            Description = "Gets a list of all Autores",
            OperationId = "Autores.List",
            Tags = new[] { "AutoresEndpoints" })
        ]
        public override async Task<ActionResult<AutoresListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new AutoresListResponse();
            response.Autores = (await _repository.ListAsync()) // TODO: pass cancellation token
                .Select(Autores => new AutoresRecord(Autores.Id, Autores.Nombre, Autores.Apellidos))
                .ToList();

            return Ok(response);
        }
    }
}
