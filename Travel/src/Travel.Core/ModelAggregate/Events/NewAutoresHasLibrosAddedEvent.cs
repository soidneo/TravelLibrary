using Travel.SharedKernel;

namespace Travel.Core.ModelAggregate.Events
{
    public class NewAutoresHasLibrosAddedEvent : BaseDomainEvent
    {
        public AutoresHasLibros NewItem { get; set; }
        public Autores Autores { get; set; }

        public NewAutoresHasLibrosAddedEvent(Autores autores,
            AutoresHasLibros newItem)
        {
            Autores = autores;
            NewItem = newItem;
        }
    }
}
