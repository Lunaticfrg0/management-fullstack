using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Persistance.Domain.BaseProperties;

namespace Persistance.Context.Extentions
{
    public static class DeletedEntityFilter
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
              .Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(DeletedEntityFilter)
          .GetMethods(BindingFlags.Public | BindingFlags.Static)
          .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
          where TEntity : class, IDeleteFlag
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
