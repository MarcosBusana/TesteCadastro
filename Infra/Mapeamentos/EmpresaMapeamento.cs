using Dominio.Empresas;
using Microsoft.EntityFrameworkCore;

namespace Infra.Mapeamentos
{
    class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.CNPJ).IsRequired();
        }
    }
}
