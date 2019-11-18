using FluentAssertions;
using Dominio.Fornecedores.Validacao;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Dominio.Fornecedores;

namespace Dominio.Testes.Fornecedores.Validacao
{
    [TestFixture]
    public class FornecedorValidadorTeste
    {
        private readonly IFornecedorValidador _validador;

        public FornecedorValidadorTeste()
        {
            _validador = new FornecedorValidador();
        }

        [Test]
        public void retorna_erro_pessoa_fisica_menor_de_dezoito_no_parana()
        {
            var fornecedor = new FornecedorBuilder()
                .InformarDataNascimento(DateTime.Now.AddYears(-17))
                .InformaTipoPessoa(TipoPessoa.Fisica)
                .InformarRG("1234568")
                .Construir();

            var retorno = _validador.EhValido(fornecedor);

           retorno.Should().BeFalse();
        }

        [Test]
        public void retorna_sucesso_pessoa_fisica_maior_de_dezoito_no_parana()
        {
            var fornecedor = new FornecedorBuilder()
                .InformarDataNascimento(DateTime.Now.AddYears(-19))
                .InformaTipoPessoa(TipoPessoa.Fisica)
                .Construir();

            var retorno = _validador.EhValido(fornecedor);

            retorno.Should().BeTrue();
        }

        [Test]
        public void retorna_erro_pessoa_fisica_sem_rg_e_data_nascimento()
        {
            var fornecedor = new FornecedorBuilder()
                .InformaTipoPessoa(TipoPessoa.Fisica)
                .Construir();

            var retorno = _validador.EhValido(fornecedor);
            retorno.Should().BeFalse();
        }

    }
}
