
namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class DeleteLibroRequest
    {
        public const string Route = "/CLibros/{LibroId:int}";
        public static string BuildRoute(int projectId) => Route.Replace("{LibroId:int}", projectId.ToString());

        public int LibroId { get; set; }
    }
}
