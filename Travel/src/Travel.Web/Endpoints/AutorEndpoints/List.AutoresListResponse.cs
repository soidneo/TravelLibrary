using System.Collections.Generic;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class AutoresListResponse
    {
        public List<AutoresRecord> Autores { get; set; } = new();
    }
}
