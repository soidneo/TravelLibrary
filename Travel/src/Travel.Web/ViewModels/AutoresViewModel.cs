using System.Collections.Generic;

namespace Travel.Web.ViewModels
{
    public class AutoresViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<AutoresHasLibrosViewModel> Items = new();
    }
}
