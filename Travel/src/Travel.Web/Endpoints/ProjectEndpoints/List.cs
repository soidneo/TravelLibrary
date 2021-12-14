using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Core.ProjectAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Endpoints.ProjectEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ProjectListResponse>
    {
        private readonly IReadRepository<Autores> _repository;

        public List(IReadRepository<Autores> repository)
        {
            _repository = repository;
        }

        [HttpGet("/Projects")]
        [SwaggerOperation(
            Summary = "Gets a list of all Projects",
            Description = "Gets a list of all Projects",
            OperationId = "Project.List",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<ProjectListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ProjectListResponse();
            response.Projects = (await _repository.ListAsync()) // TODO: pass cancellation token
                .Select(project => new ProjectRecord(project.Id, project.Name))
                .ToList();

            return Ok(response);
        }
    }
}
