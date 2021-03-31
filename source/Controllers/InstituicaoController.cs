using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoService _instituicaoService;

        public InstituicaoController(InstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CadastroInstituicaoVM>> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> Salvar(CadastroInstituicaoVM cadastroInstituicaoVM)
        {
            int _id_cliente = 0;//await _clienteService.SalvarCliente(value);
            return Ok(new { id_cliente = _id_cliente });
        }
    }
}