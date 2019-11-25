using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Empresas
{
    public interface IEmpresaService
    {
        Guid CriarEmpresa(EmpresaRequest empresaRequest);
        Guid AlterarEmpresa(EmpresaRequest empresaRequest);
        void ExcluirEmpresa(Guid empresId);
        Task<IList<EmpresaResponse>> BuscarEmpres(EmpresaFiltroRequest filtroRequest);

    }
}
