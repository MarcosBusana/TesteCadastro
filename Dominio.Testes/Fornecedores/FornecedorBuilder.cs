using Dominio.Empresas;
using Dominio.Fornecedores;
using System;

namespace Dominio.Testes.Fornecedores
{
    public class FornecedorBuilder
    {
        private Guid Id = Guid.NewGuid() ;
        private Empresa Empresa = new EmpresaBuilder().Construir();
        private string Nome = "Fornecedor Teste";
        private string CpfCnpj = "15490496000104";
        private DateTime DataCadastro = DateTime.Now;
        private string Telefone =  "47991001122";
        private TipoPessoa Tipo = TipoPessoa.Juridica;
        private DateTime DataNascimento;
        private string RG;

        public Fornecedor Construir()
        {
            if (Tipo == TipoPessoa.Fisica)
                return new Fornecedor(
                    Empresa,
                    Nome,
                    CpfCnpj,
                    DataCadastro,
                    Telefone,
                    Tipo,
                    DataNascimento,
                    RG
                );
            else
                return new Fornecedor(
                    Empresa, 
                    Nome, 
                    CpfCnpj, 
                    DataCadastro, 
                    Telefone, 
                    Tipo
                );
        }

        public FornecedorBuilder InformarRG(string rg)
        {
            RG = rg;
            return this;
        }

        public FornecedorBuilder InformaTipoPessoa(TipoPessoa tipoPessoa)
        {
            Tipo = tipoPessoa;
            return this;
        }

        public FornecedorBuilder InformarDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
            return this;
        }

    }
}
