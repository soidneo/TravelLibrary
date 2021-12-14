namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class GetLibroByIdRequest
    {
        public const string Route = "/CLibros/{LibroId:long}";
        public static string BuildRoute(long LibroId) => Route.Replace("{LibroId:long}", LibroId.ToString());

        public long LibroId { get; set; }
    }
}
