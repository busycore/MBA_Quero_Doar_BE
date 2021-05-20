using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.MinhaConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeusCuponsController : ControllerBase
    {
        private readonly DoacaoService _doacaoService;

        public MeusCuponsController(DoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        /// <summary>
        /// Método para consultar uma Cupom através do Id
        /// </summary>
        /// <param name="id">Código do Cupom</param>
        /// <returns>Entidade ViewModel Cupom</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosMeusCuponsVM>> Consultar(string id)
        {
            var dadosCupomVM = await _doacaoService.ListarMeusCupons(id);

            if (dadosCupomVM == null)
                return NotFound();

            return Ok(dadosCupomVM);
        }
    }
}