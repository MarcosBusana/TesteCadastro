using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Empresas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        protected readonly EmpresaService Service;

        public EmpresaController(EmpresaService service)
        {
            Service = service;
        }

        [HttpPost]
        public virtual void Post(EmpresaRequest command)
        {
            Service.CriarEmpresa(command);
        }

        [HttpPut]
        public virtual void Put(EmpresaRequest command)
        {
            Service.AlterarEmpresa(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual void Delete(Guid id)
        {
            Service.ExcluirEmpresa(id);
        }
    }
}