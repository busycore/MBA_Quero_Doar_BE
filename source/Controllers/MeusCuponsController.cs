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
        private readonly MeusCuponsService _meusCuponsService;

        public MeusCuponsController(MeusCuponsService meusCuponsService)
        {
            _meusCuponsService = meusCuponsService;
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
            var dadosCupomVM = await _meusCuponsService.Consultar(id);

            if (dadosCupomVM == null)
                return NotFound("Meu cupon não localizado");

            return Ok(dadosCupomVM);
        }

        /// <summary>
        /// Método para gravar um novo Cupom
        /// </summary>
        /// <param name="CadastroMeusCuponsVM">Entidade ViewModel CadastroMeusCuponsVM</param>
        /// <returns>Código do Meu Cupom</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroMeusCuponsVM cadastroMeusCuponsVM)
        {
            string id = await _meusCuponsService.Salvar(cadastroMeusCuponsVM);
            return Ok(id);
        }

        ///// <summary>
        ///// Método para atualizar as informações do Cupom
        ///// </summary>
        ///// <param name="atualizaCupomVM">Entidade ViewModel atualizaCupomVM</param>
        ///// <returns>Resultado da requisição</returns>
        //[HttpPut]
        //[ProducesResponseType(200)]
        //public async Task<ActionResult> Atualizar(AtualizaCupomVM atualizaCupomVM)
        //{
        //    await _cupomService.Atualizar(atualizaCupomVM);
        //    return Ok();
        //}
        //}
    }
}
