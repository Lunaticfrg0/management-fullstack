using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Domain.Entities;

namespace Persistance.Context.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany<ClientAddress>(ca => ca.ClientAddresses)
                .WithOne(c => c.Client);
            builder.HasMany<ClientNumber>(cn => cn.ClientNumbers)
                .WithOne(c => c.Client);
        }
    }
}
