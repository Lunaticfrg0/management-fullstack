using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Domain.Entities;


namespace Persistance.Context.Configurations
{
    internal class ClientAddressConfiguration: IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.ToTable("ClientAddresses");
            builder.Property(x => x.FirstLine)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.SecondLine)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(x => x.AdditionalDetails)
                .HasMaxLength(50);
        }
    }
}
