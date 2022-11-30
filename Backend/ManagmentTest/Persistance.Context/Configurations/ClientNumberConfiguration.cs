using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Domain.Entities;

namespace Persistance.Context.Configurations
{
    internal class ClientNumberConfiguration : IEntityTypeConfiguration<ClientNumber>
    {
        public void Configure(EntityTypeBuilder<ClientNumber> builder)
        {
            builder.ToTable("ClientNumbers");
            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(55);
        }
    }
}
