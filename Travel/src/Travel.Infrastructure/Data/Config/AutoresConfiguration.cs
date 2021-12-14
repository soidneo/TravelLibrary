using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Infrastructure.Data.Config
{
    public class AutoresConfiguration : IEntityTypeConfiguration<Core.ModelAggregate.Autores>
    {
        public void Configure(EntityTypeBuilder<Core.ModelAggregate.Autores> builder)
        {
            builder.Property(p => p.Nombre)
                .HasMaxLength(45)
                .IsRequired();
            builder.Property(p => p.Apellidos)
                .HasMaxLength(45)
                .IsRequired();
        }
    }
}
