using Travel.SharedKernel;

namespace Travel.Core.ModelAggregate.Events
{
    public class NewLibroAddedEvent : BaseDomainEvent
    {
        public Libros NewItem { get; set; }
        public Editoriales Editorial { get; set; }

        public NewLibroAddedEvent(Editoriales editorial,
            Libros newItem)
        {
            Editorial = editorial;
            NewItem = newItem;
        }
    }
}
