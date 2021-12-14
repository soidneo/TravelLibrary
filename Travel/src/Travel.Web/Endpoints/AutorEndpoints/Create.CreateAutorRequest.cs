using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class CreateAutorRequest
    {
        public const string Route = "/CAutores";

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
    }
}