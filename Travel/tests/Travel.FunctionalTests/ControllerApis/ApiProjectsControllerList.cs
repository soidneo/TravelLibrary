using Ardalis.HttpClientTestExtensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Travel.Web;
using Travel.Web.ApiModels;
using Xunit;

namespace Travel.FunctionalTests.ControllerApis
{
    [Collection("Sequential")]
    public class LibroCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public LibroCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOneProject()
        {
            var result = await _client.GetAndDeserialize<LibrosDTO>("/api/libros/1");

            Assert.Equal(SeedData.TestLibro1.EditorialesId, result.EditorialesId);
            Assert.Equal(SeedData.TestLibro1.Titulo, result.Titulo);
            Assert.Equal(SeedData.TestLibro1.Sinopsis, result.Sinopsis);
            Assert.Equal(SeedData.TestLibro1.NPaginas, result.NPaginas);
        }
    }
}
