using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class UpdateAutorRequest
    {
        public const string Route = "/CAutores";
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apeliidos { get; set; }
    }
}