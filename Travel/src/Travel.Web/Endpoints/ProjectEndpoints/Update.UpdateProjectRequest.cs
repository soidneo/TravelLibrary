using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Endpoints.ProjectEndpoints
{
    public class UpdateProjectRequest
    {
        public const string Route = "/Projects";
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}