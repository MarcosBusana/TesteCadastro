using Dominio.Empresas;
using System;

namespace Dominio.Fornecedores
{
    public class Fornecedor
    {
        public Fornecedor( Empresa empresa, string nome, string cpfCnpj, DateTime dataCadastro, string telefone, TipoPessoa tipo)
        {
            Empresa = empresa;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            DataCadastro = dataCadastro;
            Telefone = telefone;
            Tipo = tipo;
            EmpresaId = empresa.Id;
        }

        public Fornecedor(Empresa empresa, string nome, string cpfCnpj, DateTime dataCadastro, string telefone, TipoPessoa tipo, DateTime dataNascimento, string rg) : this(empresa, nome, cpfCnpj, dataCadastro, telefone, tipo)
        {
            DataNascimento = dataNascimento;
            RG = rg;
        }

        public Guid Id { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Telefone { get; private set; }
        public TipoPessoa Tipo { get; private set; }
        public Guid EmpresaId { get; set; }
        public DateTime? DataNascimento { get; private set; }
        public string RG { get; private set; }


    }
}