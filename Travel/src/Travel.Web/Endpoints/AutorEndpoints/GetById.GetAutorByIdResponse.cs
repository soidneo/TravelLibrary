using System.Collections.Generic;

namespace Travel.Web.Endpoints.AutorEndpoints
{
    public class GetAutorByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<AutorHasLibrosRecord> Items { get; set; } = new();
    }
}