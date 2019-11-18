using System;
using System.Threading.Tasks;
using Dominio.Fornecedores;
using Dominio.Fornecedores.Validacao;

namespace Dominio.Testes.Fornecedores.Validacao
{
    public class FornecedorValidador : IFornecedorValidador
    {
        public bool EhValido(Fornecedor fornecedor)
        {
            return ValidarPessoaFisica(fornecedor) && ValidarMenorIdadeParana(fornecedor);
        }

        private bool ValidarMenorIdadeParana(Fornecedor fornecedor)
        {
            if (
                fornecedor.Tipo == TipoPessoa.Fisica &&
                fornecedor.Empresa.UF == Empresas.UnidadeFederativa.Parana &&
                fornecedor.DataNascimento > DateTime.Now.AddYears(-18)
            )
            {
                return false;
            }

            return true;
        }

        private bool ValidarPessoaFisica(Fornecedor fornecedor)
        {
            if( 
                fornecedor.Tipo == TipoPessoa.Fisica &&
                (!fornecedor.DataNascimento.HasValue || fornecedor.DataNascimento == DateTime.MinValue)&&
                (fornecedor.RG == null || fornecedor.RG == "")
            )
            {
                return false;
            }

            return true;
        }
    }
}