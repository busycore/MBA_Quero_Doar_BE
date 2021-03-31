using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Doador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoadorController : ControllerBase
    {
        private readonly DoadorService _doadorService;

        public DoadorController(DoadorService doadorService)
        {
            this._doadorService = doadorService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CadastroDoadorVM>> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> Salvar(CadastroDoadorVM cadastroDoadorVM)
        {
            int _id_cliente = 0;//await _clienteService.SalvarCliente(value);
            return Ok(new { id_cliente = _id_cliente });
        }
    }
}