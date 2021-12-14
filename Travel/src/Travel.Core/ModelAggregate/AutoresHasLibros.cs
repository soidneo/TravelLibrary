using Ardalis.GuardClauses;
using Travel.SharedKernel;

namespace Travel.Core.ModelAggregate
{
    public class AutoresHasLibros : BaseEntity
    {

        public int AutoresId{ get; set; }
        public long LibrosISBN { get; set; }
        public virtual Autores AutoresNavigation { get; set; }
        public virtual Libros LibrosNavigation { get; set; }

        public AutoresHasLibros(int autoresId, long librosISBN)
        {
            AutoresId = Guard.Against.Negative(autoresId, nameof(autoresId));
            LibrosISBN = Guard.Against.Negative(librosISBN, nameof(librosISBN));
        }
    }
}
