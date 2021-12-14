using System.Collections.Generic;
using Travel.Core.ProjectAggregate;

namespace Travel.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
