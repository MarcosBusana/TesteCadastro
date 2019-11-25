using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data
{   
    public class ContextoBase : DbContext
    {
        public Guid Id { get; set; }

        public ContextoBase() : base()
        {
            Id = Guid.NewGuid();
        }

        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
            Id = Guid.NewGuid();
        }

        
        public void AutoLoadMappings<TContext>(ModelBuilder modelBuilder) where TContext : ContextoBase
        {
            var implementedConfigTypes = typeof(TContext).Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract
                    && !t.IsGenericTypeDefinition
                    && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
                        i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }
        }

        public override int SaveChanges()
        {
            
            CustomChangeTrackingBeforeSave(ChangeTracker);
            var result = base.SaveChanges();
            CustomChangeTrackingAfterSave(ChangeTracker);
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            CustomChangeTrackingBeforeSave(ChangeTracker);
            var result = base.SaveChangesAsync(cancellationToken);
            CustomChangeTrackingAfterSave(ChangeTracker);
            return result;
        }

        public virtual void CustomChangeTrackingBeforeSave(ChangeTracker changeTracker)
        {

        }

        public virtual void CustomChangeTrackingAfterSave(ChangeTracker changeTracker)
        {

        }

    }
}
