using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Core.ModelAggregate;

namespace Travel.Infrastructure.Data.Config
{
    public class EditorialesConfiguration : IEntityTypeConfiguration<Editoriales>
    {
        public void Configure(EntityTypeBuilder<Editoriales> builder)
        {
            builder.Property(p => p.Nombre)
                .HasMaxLength(45)
                .IsRequired();
            builder.Property(p => p.Sede)
                .HasMaxLength(45)
                .IsRequired();
        }
    }
}
