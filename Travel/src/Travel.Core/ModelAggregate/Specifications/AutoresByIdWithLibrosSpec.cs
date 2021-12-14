using Ardalis.Specification;

namespace Travel.Core.ModelAggregate.Specifications
{
    public class AutoresByIdWithLibrosSpec : Specification<Autores>, ISingleResultSpecification
    {
        public AutoresByIdWithLibrosSpec(int AutoresId)
        {
            Query
                .Where(Autores => Autores.Id == AutoresId)
                .Include(Autores => Autores.Items);
        }
    }
}
