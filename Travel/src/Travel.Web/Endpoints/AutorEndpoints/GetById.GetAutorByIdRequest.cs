namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class GetAutorByIdRequest
    {
        public const string Route = "/CAutores/{AutorId:int}";
        public static string BuildRoute(int projectId) => Route.Replace("{AutorId:int}", projectId.ToString());

        public int AutorId { get; set; }
    }
}
