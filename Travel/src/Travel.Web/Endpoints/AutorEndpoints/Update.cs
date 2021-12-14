using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateAutorRequest>
        .WithResponse<UpdateAutorResponse>
    {
        private readonly IRepository<Autores> _repository;

        public Update(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpPut(UpdateAutorRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a Autor",
            Description = "Updates a Autor with a longer description",
            OperationId = "Autors.Update",
            Tags = new[] { "AutorEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAutorResponse>> HandleAsync(UpdateAutorRequest request,
            CancellationToken cancellationToken)
        {
            var existingAutor = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

            existingAutor.UpdateNombreAndApellido(request.Nombre,request.Apeliidos);

            await _repository.UpdateAsync(existingAutor); // TODO: pass cancellation token

            var response = new UpdateAutorResponse()
            {
                Autor = new AutoresRecord(existingAutor.Id, existingAutor.Nombre, existingAutor.Apellidos)
            };
            return Ok(response);
        }
    }
}
