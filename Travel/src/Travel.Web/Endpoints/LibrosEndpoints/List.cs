using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<LibrosListResponse>
    {
        private readonly IReadRepository<Libros> _repository;

        public List(IReadRepository<Libros> repository)
        {
            _repository = repository;
        }

        [HttpGet("/OApi/Libros")]
        [SwaggerOperation(
            Summary = "Gets a list of all Libros",
            Description = "Gets a list of all Libros",
            OperationId = "Libros.List",
            Tags = new[] { "LibrosEndpoints" })
        ]
        public override async Task<ActionResult<LibrosListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new LibrosListResponse();
            response.Libros = (await _repository.ListAsync()) // TODO: pass cancellation token
                .Select(Libros => new LibrosRecord(Libros.ISBN, Libros.EditorialesId, Libros.Titulo, Libros.Sinopsis, Libros.NPaginas))
                .ToList();

            return Ok(response);
        }
    }
}
