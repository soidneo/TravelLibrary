using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Core.ModelAggregate;

namespace Travel.Infrastructure.Data.Config
{
    public class LibrosConfiguration : IEntityTypeConfiguration<Libros>
    {
        public void Configure(EntityTypeBuilder<Libros> builder)
        {
            builder.Property(p => p.Titulo)
                .HasMaxLength(45)
                .IsRequired();
            builder.Property(p => p.Sinopsis)
                .HasColumnType("text");
            builder.Property(p => p.NPaginas)
                .HasMaxLength(45)
                .IsRequired();
        }
    }
}
