using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class CreateLibroRequest
    {
        public const string Route = "/CLibros";
        [Required]
        public int EditorialesId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Sinopsis { get; set; }
        [Required]
        public string NPaginas { get; set; }
    }
}