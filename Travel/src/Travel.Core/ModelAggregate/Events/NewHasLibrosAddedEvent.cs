using Travel.SharedKernel;

namespace Travel.Core.ModelAggregate.Events
{
    public class NewHasLibrosAddedEvent : BaseDomainEvent
    {
        public AutoresHasLibros NewItem { get; set; }
        public Libros Libros { get; set; }

        public NewHasLibrosAddedEvent(Libros libros,
            AutoresHasLibros newItem)
        {
            Libros = libros;
            NewItem = newItem;
        }
    }
}
