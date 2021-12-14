using Ardalis.Specification;

namespace Travel.Core.ModelAggregate.Specifications
{
    public class LibrosWithSpec : Specification<Libros>, ISingleResultSpecification
    {
        public LibrosWithSpec()
        {
            Query
                .Where(libros => libros.ISBN > 0)
                .Include(libros => libros.EditorialesNavigation)
                .Include(libros => libros.Items)
                .ThenInclude(O => O.AutoresNavigation);
        }
    }
}
