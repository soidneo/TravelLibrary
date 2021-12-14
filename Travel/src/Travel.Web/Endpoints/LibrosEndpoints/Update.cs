using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateLibroRequest>
        .WithResponse<UpdateLibroResponse>
    {
        private readonly IRepository<Libros> _repository;

        public Update(IRepository<Libros> repository)
        {
            _repository = repository;
        }

        [HttpPut(UpdateLibroRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a Libro",
            Description = "Updates a Libro with a longer description",
            OperationId = "Libros.Update",
            Tags = new[] { "LibroEndpoints" })
        ]
        public override async Task<ActionResult<UpdateLibroResponse>> HandleAsync(UpdateLibroRequest request,
            CancellationToken cancellationToken)
        {
            var existingLibro = await _repository.GetByIdAsync(request.ISBN); // TODO: pass cancellation token

            existingLibro.UpdateTituloAndSinopsis(request.Titulo,request.Sinopsis);

            await _repository.UpdateAsync(existingLibro); // TODO: pass cancellation token

            var response = new UpdateLibroResponse()
            {
                Libro = new LibrosRecord(existingLibro.ISBN, existingLibro.EditorialesId
                , existingLibro.Titulo, existingLibro.Sinopsis, existingLibro.NPaginas)
            };
            return Ok(response);
        }
    }
}
