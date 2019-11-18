using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Empresas
{
    interface IEmpresaService
    {
        Task<Guid> CriarEmpresa(EmpresaRequest empresaRequest);
        Task<Guid> AlterarEmpresa(EmpresaRequest empresaRequest);
        void ExcluirEmpresa(Guid empresId);
        Task<IList<EmpresaResponse>> BuscarEmpres(EmpresaFiltroRequest filtroRequest);

    }
}
