using System.Linq;
using System.Threading.Tasks;
using Travel.Core.ModelAggregate;
using Xunit;

namespace Travel.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsProjectAndSetsId()
        {
            var editorialesId = 1;
            var titulo = "titulo test";
            var sinopsis = "sinopsis test";
            var nPaginas = "nPaginas test";
            var repository = GetRepository();
            var libro = new Libros(editorialesId,titulo,sinopsis,nPaginas);

            await repository.AddAsync(libro);

            var newProject = (await repository.ListAsync())
                            .FirstOrDefault();

            Assert.Equal(editorialesId, newProject.EditorialesId);
            Assert.Equal(titulo, newProject.Titulo);
            Assert.Equal(sinopsis, newProject.Sinopsis);
            Assert.Equal(nPaginas, newProject.NPaginas);
            Assert.True(newProject?.ISBN > 0);
        }
    }
}
