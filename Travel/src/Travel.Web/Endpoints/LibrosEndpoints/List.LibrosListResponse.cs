using System.Collections.Generic;

namespace Travel.Web.Endpoints.LibrosEndpoints
{
    public class LibrosListResponse
    {
        public List<LibrosRecord> Libros { get; set; } = new();
    }
}
