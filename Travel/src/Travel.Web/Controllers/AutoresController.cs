using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core;
using Travel.Core.ModelAggregate;
using Travel.Core.ModelAggregate.Specifications;
using Travel.SharedKernel.Interfaces;
using Travel.Web.ApiModels;
using Travel.Web.ViewModels;

namespace Travel.Web.Controllers
{
    [Route("[controller]")]
    public class AutoresController : Controller
    {
        private readonly IRepository<Autores> _AutoresRepository;

        public AutoresController(IRepository<Autores> AutoresRepository)
        {
            _AutoresRepository = AutoresRepository;
        }

        // GET Autores/{AutoresId?}
        [HttpGet("{AutoresId:int}")]
        public async Task<IActionResult> Index(int AutoresId = 1)
        {
            var spec = new AutoresByIdWithLibrosSpec(AutoresId);
            var Autores = await _AutoresRepository.GetBySpecAsync(spec);

            var dto = new AutoresViewModel
            {
                Id = Autores.Id,
                Nombre = Autores.Nombre,
                Apellidos = Autores.Apellidos,
                Items = Autores.Items
                            .Select(item => AutoresHasLibrosViewModel.FromAutoresHasLibros(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}
