using System;

namespace Dominio.Empresas
{
    public class Empresa
    {
        public Empresa(UnidadeFederativa uF, string nome, string cNPJ)
        {
            UF = uF;
            Nome = nome;
            CNPJ = cNPJ;
        }

        public Guid Id { get; private set; }
        public UnidadeFederativa UF { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
    }
}
