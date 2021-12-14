using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetAutorByIdRequest>
        .WithResponse<GetAutorByIdResponse>
    {
        private readonly IRepository<Autores> _repository;

        public GetById(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpGet(GetAutorByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single Autor",
            Description = "Gets a single Autor by Id",
            OperationId = "Autors.GetById",
            Tags = new[] { "AutorEndpoints" })
        ]
        public override async Task<ActionResult<GetAutorByIdResponse>> HandleAsync([FromRoute] GetAutorByIdRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new AutoresByIdWithLibrosSpec(request.AutorId);
            var entity = await _repository.GetByIdAsync(spec); // TODO: pass cancellation token

            var response = new GetAutorByIdResponse
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellidos = entity.Apellidos,
                Items = entity.Items.Select(item => new AutorHasLibrosRecord(item.Id, item.AutoresId, item.LibrosISBN)).ToList()
            };
            return Ok(response);
        }
    }
}
