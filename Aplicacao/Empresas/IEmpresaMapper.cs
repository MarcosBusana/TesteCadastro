using Dominio.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Empresas
{
    public interface IEmpresaMapper
    {
        Empresa Converte(EmpresaRequest request);
        EmpresaResponse Converte(Empresa empresa);
    }
}
