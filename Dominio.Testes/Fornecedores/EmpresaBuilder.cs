using System;
using Dominio.Empresas;

namespace Dominio.Testes.Fornecedores
{
    public class EmpresaBuilder
    {

        private Guid Id = Guid.NewGuid();
        private string Nome = "Empresa Teste";
        private string CNPJ = "93060514000113";
        private UnidadeFederativa UF = UnidadeFederativa.Parana;
        

        public Empresa Construir()
        {
            return new Empresa(UF, Nome, CNPJ);
        }
    }
}