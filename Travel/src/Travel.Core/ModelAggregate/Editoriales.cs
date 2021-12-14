using Ardalis.GuardClauses;
using System.Collections.Generic;
using Travel.Core.ModelAggregate.Events;
using Travel.SharedKernel;

namespace Travel.Core.ModelAggregate
{
    public class Editoriales : BaseEntity
    {
        public string Nombre { get; private set; }
        public string Sede { get; private set; }


        private List<Libros> _items = new List<Libros>();
        public IEnumerable<Libros> Items => _items.AsReadOnly();
        public Editoriales(string nombre, string sede)
        {
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
            Sede = Guard.Against.NullOrEmpty(sede, nameof(sede));
        }

        public void AddItem(Libros newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewLibroAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateNombreAndSede(string newName, string newSede)
        {
            Nombre = Guard.Against.NullOrEmpty(newName, nameof(newName));
            Sede = Guard.Against.NullOrEmpty(newSede, nameof(newSede));
        }
        
    }
}
