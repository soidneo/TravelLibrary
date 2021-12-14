
namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class CreateLibroResponse
    {
        public long ISBN { get; set; }
        public int EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
    }
}