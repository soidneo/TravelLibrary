using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Travel.Core.ModelAggregate;
using Travel.Infrastructure.Data;

namespace Travel.Web
{
    public static class SeedData
    {
        public static readonly Autores TestAutor1 = new Autores("Gabriel", "Garcia Marquez");
        public static readonly Autores TestAutor2 = new Autores("Julio", "Cortazar");
        public static readonly Autores TestAutor3 = new Autores("Stephen", "King");
        public static readonly Editoriales TestEditorial1 = new Editoriales("AlfaOmega", "Bogota");
        public static readonly Editoriales TestEditorial2 = new Editoriales("Debolsillo", "Madrid");
        public static readonly Editoriales TestEditorial3 = new Editoriales("Random House", "Bogotá");
        public static readonly Libros TestLibro1 = new Libros(TestEditorial1.Id, "Cien años de soledad", "Entre la boda de " +
            "José Arcadio Buendía con Amelia Iguarán hasta la maldición de Aureliano Babilonia transcurre todo un siglo. " +
            "Cien años de soledad para una estirpe única, fantástica, capaz de fundar una ciudad tan especial como " +
            "Macondo y de engendrar niños con cola de cerdo", "504");
        public static readonly Libros TestLibro2 = new Libros(TestEditorial1.Id, "Cronicas de una muerte anunciada", "En un pequeño y " +
            "aislado pueblo en la costa del Caribe, se casan Bayardo San Román, un hombre rico y recién llegado, y " +
            "Ángela Vicario. ... Años después, Ángela Vicario estaría escribiendo cada día a Bayardo, primero formalmente, " +
            "después con cartas de joven enamorada y, al final, fingiendo enfermedades.", "156");
        public static readonly Libros TestLibro3 = new Libros(TestEditorial1.Id, "El amor en los tiempos del colera", "De jóvenes, " +
            "Florentino Ariza y Fermina Daza se enamoran apasionadamente, pero Fermina eventualmente decide casarse con un médico " +
            "rico y de muy buena familia. Florentino está anonadado, pero es un romántico. ... A los cincuenta años, nueve meses " +
            "y cuatro días de haberle profesado amor a Fermina, lo hará una vez más.", "185");
        public static readonly Libros TestLibro4 = new Libros(TestEditorial2.Id, "Rayuela", "El amor turbulento de Oliveira y La Maga, " +
            "los amigos del Club de la Serpiente, las caminatas por Paría en busca del cielo y el infierno tienen su reverso en " +
            "la aventura simétrica de Oliveira, Talira y Traveler en un Buenos Aires teñido por el recuerdo.", "130");
        public static readonly Libros TestLibro5 = new Libros(TestEditorial2.Id, "Bestiario", "En Bestiario (1951), el primer libro " +
            "de cuentos de Julio Cortázar, las situaciones fantásticas irrumpen por fuerzas anónimas, salvajismos sutiles y sobre " +
            "todo, por interrogantes que cuestionan la realidad de los cuentos y que nos interpelan de forma inevitable.", "160");
        public static readonly Libros TestLibro6 = new Libros(TestEditorial2.Id, "62 modelos para amar", "62/Modelo para armar, es " +
            "la tercera novela del escritor argentino Julio Cortázar, publicada en 1968.​Escrita a partir de una idea ya planteada" +
            " en el capítulo 62 de su anterior novela, Rayuela —de ahí el nombre de la misma", "210");
        public static readonly Libros TestLibro7 = new Libros(TestEditorial3.Id, "El resplandor", "Jack Torrance" +
            " acepta una oferta de trabajo en un hotel de montaña que se encuentra a 65 kilómetros del pueblo más cercano. ... " +
            "Danny, el hijo de Jack tiene la capacidad de ver visiones sobre el pasado del hotel y de resistirse a su poder " +
            "hipnótico. Es entonces cuando su padre comienza a enloquecer.", "203");
        public static readonly Libros TestLibro8 = new Libros(TestEditorial3.Id, "Doctor Sueño", "Ahora Danny Torrance, " +
            "aquel niño aterrorizado del Hotel Overlook, es un adulto alcohólico y sin residencia fija que va de ciudad " +
            "en ciudad atormentado por sus visiones y por los fantasmas de su infancia, que ha aprendido a controlar " +
            "pero no a eliminar de su mente.", "110");
        public static readonly Libros TestLibro9 = new Libros(TestEditorial3.Id, "La Torre Oscura", "La Torre Oscura es" +
            " una saga de libros escrita por el autor estadounidense Stephen King, que incorpora temas de múltiples géneros, " +
            "incluyendo fantasía, fantasía científica, terror y wéstern. Describe a un pistolero y su búsqueda de una torre, " +
            "cuya naturaleza es tanto física como metafórica.", "225");
        public static readonly AutoresHasLibros TestAutores_Has_Libros1 = new AutoresHasLibros(TestAutor1.Id, TestLibro1.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros2 = new AutoresHasLibros(TestAutor1.Id, TestLibro2.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros3 = new AutoresHasLibros(TestAutor1.Id, TestLibro3.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros4 = new AutoresHasLibros(TestAutor2.Id, TestLibro4.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros5 = new AutoresHasLibros(TestAutor2.Id, TestLibro5.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros6 = new AutoresHasLibros(TestAutor2.Id, TestLibro6.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros7 = new AutoresHasLibros(TestAutor3.Id, TestLibro7.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros8 = new AutoresHasLibros(TestAutor3.Id, TestLibro8.ISBN);
        public static readonly AutoresHasLibros TestAutores_Has_Libros9 = new AutoresHasLibros(TestAutor3.Id, TestLibro9.ISBN);


        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.AutoresHasLibros.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.AutoresHasLibros)
            {
                dbContext.Remove(item);
            }
            foreach (var item in dbContext.Editoriales)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            TestEditorial1.AddItem(TestLibro1);
            TestEditorial1.AddItem(TestLibro2);
            TestEditorial1.AddItem(TestLibro3);
            TestEditorial2.AddItem(TestLibro4);
            TestEditorial2.AddItem(TestLibro5);
            TestEditorial2.AddItem(TestLibro6);
            TestEditorial3.AddItem(TestLibro7);
            TestEditorial3.AddItem(TestLibro8);
            TestEditorial3.AddItem(TestLibro9);

            dbContext.Editoriales.Add(TestEditorial1);
            dbContext.Editoriales.Add(TestEditorial2);
            dbContext.Editoriales.Add(TestEditorial3);

            TestAutor1.AddItem(TestAutores_Has_Libros1);
            TestAutor1.AddItem(TestAutores_Has_Libros2);
            TestAutor1.AddItem(TestAutores_Has_Libros3);
            TestAutor2.AddItem(TestAutores_Has_Libros4);
            TestAutor2.AddItem(TestAutores_Has_Libros5);
            TestAutor2.AddItem(TestAutores_Has_Libros6);
            TestAutor3.AddItem(TestAutores_Has_Libros7);
            TestAutor3.AddItem(TestAutores_Has_Libros8);
            TestAutor3.AddItem(TestAutores_Has_Libros9);

            TestLibro1.AddItem(TestAutores_Has_Libros1);
            TestLibro2.AddItem(TestAutores_Has_Libros2);
            TestLibro3.AddItem(TestAutores_Has_Libros3);
            TestLibro4.AddItem(TestAutores_Has_Libros4);
            TestLibro5.AddItem(TestAutores_Has_Libros5);
            TestLibro6.AddItem(TestAutores_Has_Libros6);
            TestLibro7.AddItem(TestAutores_Has_Libros7);
            TestLibro8.AddItem(TestAutores_Has_Libros8);
            TestLibro9.AddItem(TestAutores_Has_Libros9);
            dbContext.Autores.Add(TestAutor1);
            dbContext.Autores.Add(TestAutor2);
            dbContext.Autores.Add(TestAutor3);

            dbContext.SaveChanges();
        }
    }
}
