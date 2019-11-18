using Microsoft.EntityFrameworkCore;
using System;
using Dominio.Fornecedores;

namespace Infra.Mapeamentos
{
    class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.CpfCnpj).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey(x => x.EmpresaId);
            builder.Property(x => x.DataNascimento).IsRequired(false);
            builder.Property(x => x.RG).IsRequired(false);
        }
    }
}
