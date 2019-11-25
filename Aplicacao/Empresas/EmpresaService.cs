using Dominio.Empresas;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Empresas
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaMapper _empresaMapper;
        private readonly IEmpresaRepository _repository;
        private readonly IUnityOfWork _unityOfWork;

        public EmpresaService(IEmpresaMapper empresaMapper)
        {
            _empresaMapper = empresaMapper;
        }

        public Guid AlterarEmpresa(EmpresaRequest empresaRequest)
        {
            var empresa = _empresaMapper.Converte(empresaRequest);
            _repository.Update(empresa);
            return empresa.Id;
        }

        public Task<IList<EmpresaResponse>> BuscarEmpres(EmpresaFiltroRequest filtroRequest)
        {
            throw new NotImplementedException();
        }

        public Guid CriarEmpresa(EmpresaRequest empresaRequest)
        {
            var empresa = _empresaMapper.Converte(empresaRequest);
            _repository.Add(empresa);
            return empresa.Id;
        }

        public void ExcluirEmpresa(Guid empresId)
        {
            _repository.Remove(empresId);
            _unityOfWork.Save();
        }
    }
}
