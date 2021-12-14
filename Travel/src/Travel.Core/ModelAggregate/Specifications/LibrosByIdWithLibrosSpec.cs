using Ardalis.Specification;

namespace Travel.Core.ModelAggregate.Specifications
{
    public class LibrosByIdWithLibrosSpec : Specification<Libros>, ISingleResultSpecification
    {
        public LibrosByIdWithLibrosSpec(long LibrosId)
        {
            Query
                .Where(Libros => Libros.ISBN == LibrosId)
                .Include(libros => libros.EditorialesNavigation)
                .Include(Libros => Libros.Items)
                .ThenInclude(O => O.AutoresNavigation);
        }
    }
}
