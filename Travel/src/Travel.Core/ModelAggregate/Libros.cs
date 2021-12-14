using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Travel.Core.ModelAggregate.Events;
using Travel.SharedKernel;
using Travel.SharedKernel.Interfaces;

namespace Travel.Core.ModelAggregate
{
    public class Libros : IAggregateRoot
    {
        [Key]
        public  long ISBN { get; set; }
        //public  long ISBN { get { return base.Id; } set { base.Id = ((int)value); } }
        public int EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public Editoriales EditorialesNavigation { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

        private List<AutoresHasLibros> _items = new List<AutoresHasLibros>();
        public IEnumerable<AutoresHasLibros> Items => _items.AsReadOnly();
        public Libros(int editorialesId, string titulo, string sinopsis, string nPaginas)
        {
            EditorialesId = Guard.Against.Negative(editorialesId, nameof(editorialesId));
            Titulo = Guard.Against.NullOrEmpty(titulo, nameof(titulo));
            Sinopsis = Guard.Against.NullOrEmpty(sinopsis, nameof(sinopsis));
            NPaginas = Guard.Against.NullOrEmpty(nPaginas, nameof(nPaginas));
        }

        public void AddItem(AutoresHasLibros newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewHasLibrosAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateTituloAndSinopsis(string newTitulo, string newSinopsis)
        {
            Titulo = Guard.Against.NullOrEmpty(newTitulo, nameof(newTitulo));
            Sinopsis = Guard.Against.NullOrEmpty(newSinopsis, nameof(newSinopsis));
        }
    }
}
