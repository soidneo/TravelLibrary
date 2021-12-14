using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ProjectAggregate;
using Travel.SharedKernel.Interfaces;

namespace Travel.Web.Pages.ToDoRazorPage
{
    public class IncompleteModel : PageModel
    {
        private readonly IRepository<Autores> _repository;

        public List<ToDoItem> ToDoItems { get; set; }

        public IncompleteModel(IRepository<Autores> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(1); // TODO: get from route
            var project = await _repository.GetBySpecAsync(projectSpec);
            var spec = new IncompleteItemsSpec();

            ToDoItems = spec.Evaluate(project.Items).ToList();
        }
    }
}
