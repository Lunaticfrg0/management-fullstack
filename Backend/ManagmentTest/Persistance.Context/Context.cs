using Microsoft.EntityFrameworkCore;
using Persistance.Context.Extentions;
using Persistance.Domain.BaseProperties;
using Persistance.Domain.Entities;

namespace Persistance.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<ClientNumber> ClientNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            //Deleted filter
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IDeleteFlag).IsAssignableFrom(type.ClrType))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private void CustomSave()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }
        public override int SaveChanges()
        {
            CustomSave();
            return base.SaveChanges();
        }
    }
}