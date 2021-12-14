using Ardalis.HttpClientTestExtensions;
using System.Net.Http;
using System.Threading.Tasks;
using Travel.Web;
using Travel.Web.Endpoints.LibrosEndpoints;
using Xunit;

namespace Travel.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class LibroGetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public LibroGetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsSeedLibroGivenId1()
        {
            //var routa = GetLibroByIdRequest.BuildRoute(1);
            //var result1 = await _client.GetAsync(routa);
            var result = await _client.GetAndDeserialize<GetLibroByIdResponse>(GetLibroByIdRequest.BuildRoute(1));
            Assert.Equal(1, result.ISBN);
            Assert.Equal(SeedData.TestLibro1.Titulo, result.Titulo);
            Assert.Equal(SeedData.TestLibro1.Sinopsis, result.Sinopsis);
            Assert.Equal(SeedData.TestLibro1.NPaginas, result.NPaginas);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenId0()
        {
            string route = GetLibroByIdRequest.BuildRoute(0);
            var res = _client.GetAsync(route);
            _ = await _client.GetAndEnsureNotFound(route);
        }
    }
}
