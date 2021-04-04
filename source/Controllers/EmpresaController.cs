using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CadastroEmpresaVM> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<CadastroEmpresaVM> Post(CadastroEmpresaVM cadastroEmpresaVM)
        {
            return Ok();
        }
    }
}