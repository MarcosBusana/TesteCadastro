using Infra.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmpresaMapeamento());
            builder.ApplyConfiguration(new FornecedorMapeamento());

            base.OnModelCreating(builder);
        }

    }
}
