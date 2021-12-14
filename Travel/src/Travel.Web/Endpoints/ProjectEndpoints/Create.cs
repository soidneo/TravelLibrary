using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ProjectAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.ProjectEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateProjectRequest>
        .WithResponse<CreateProjectResponse>
    {
        private readonly IRepository<Autores> _repository;

        public Create(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpPost("/Projects")]
        [SwaggerOperation(
            Summary = "Creates a new Project",
            Description = "Creates a new Project",
            OperationId = "Project.Create",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<CreateProjectResponse>> HandleAsync(CreateProjectRequest request,
            CancellationToken cancellationToken)
        {
            var newProject = new Autores(request.Name);

            var createdItem = await _repository.AddAsync(newProject); // TODO: pass cancellation token

            var response = new CreateProjectResponse
            {
                Id = createdItem.Id,
                Name = createdItem.Name
            };

            return Ok(response);
        }
    }
}
