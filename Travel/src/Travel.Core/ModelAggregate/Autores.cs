
using Ardalis.GuardClauses;
using System.Collections.Generic;
using Travel.Core.ModelAggregate.Events;
using Travel.SharedKernel;
using Travel.SharedKernel.Interfaces;

namespace Travel.Core.ModelAggregate
{
    public class Autores : BaseEntity, IAggregateRoot
    {
        public string Nombre { get; private set; }
        public string Apellidos { get; private set; }

        private List<AutoresHasLibros> _items = new List<AutoresHasLibros>();
        public IEnumerable<AutoresHasLibros> Items => _items.AsReadOnly();

        public Autores(string nombre, string apellidos)
        {
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
            Apellidos = Guard.Against.NullOrEmpty(apellidos, nameof(apellidos));
        }

        public void AddItem(AutoresHasLibros newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewAutoresHasLibrosAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateNombreAndApellido(string newnombre, string newApellidos)
        {
            Nombre = Guard.Against.NullOrEmpty(newnombre, nameof(newnombre));
            Apellidos = Guard.Against.NullOrEmpty(newApellidos, nameof(newApellidos));
        }
    }
}
