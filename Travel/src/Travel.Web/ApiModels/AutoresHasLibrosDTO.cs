using Travel.Core.ModelAggregate;

namespace Travel.Web.ApiModels
{
    // ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
    public class AutoresHasLibrosDTO
    {
        public int Id { get; set; }
        public int AutoresId { get; set; }
        public long LibrosISBN { get; set; }

        public static AutoresHasLibrosDTO FromAutoresHasLibros(AutoresHasLibros item)
        {
            return new AutoresHasLibrosDTO()
            {
                Id = item.Id,
                AutoresId = item.AutoresId,
                LibrosISBN = item.LibrosISBN,
                
            };
        }
    }
}
