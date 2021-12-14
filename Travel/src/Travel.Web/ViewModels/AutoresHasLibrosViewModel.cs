using Travel.Core.ModelAggregate;

namespace Travel.Web.ViewModels
{
    public class AutoresHasLibrosViewModel
    {
        public int Id { get; set; }
        public int AutoresId { get; set; }
        public long LibrosISBN { get; set; }

        public static AutoresHasLibrosViewModel FromAutoresHasLibros(AutoresHasLibros item)
        {
            return new AutoresHasLibrosViewModel()
            {
                Id = item.Id,
                AutoresId = item.AutoresId,
                LibrosISBN = item.LibrosISBN
            };
        }
    }
}
