using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateAutorRequest>
        .WithResponse<CreateAutorResponse>
    {
        private readonly IRepository<Autores> _repository;

        public Create(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpPost("/CAutores")]
        [SwaggerOperation(
            Summary = "Creates a new Autores",
            Description = "Creates a new Autores",
            OperationId = "Autores.Create",
            Tags = new[] { "AutoresEndpoints" })
        ]
        public override async Task<ActionResult<CreateAutorResponse>> HandleAsync(CreateAutorRequest request,
            CancellationToken cancellationToken)
        {
            var newAutores = new Autores(request.Nombre,request.Apellidos);

            var createdItem = await _repository.AddAsync(newAutores); // TODO: pass cancellation token

            var response = new CreateAutorResponse
            {
                Id = createdItem.Id,
                Nombre = createdItem.Nombre,
                Apellidos = createdItem.Apellidos
            };

            return Ok(response);
        }
    }
}
