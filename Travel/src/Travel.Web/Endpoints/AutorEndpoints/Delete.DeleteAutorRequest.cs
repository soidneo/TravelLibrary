
namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class DeleteAutorRequest
    {
        public const string Route = "/CAutores/{AutorId:int}";
        public static string BuildRoute(int projectId) => Route.Replace("{AutorId:int}", projectId.ToString());

        public int AutorId { get; set; }
    }
}
