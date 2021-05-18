using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Cupom;
using source.ViewModel.Empresa;
using System;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly CupomService _cupomService;

        public CupomController(CupomService cupomService)
        {
            _cupomService = cupomService;
        }

        /// <summary>
        /// Método para consultar uma Cupom através do Id
        /// </summary>
        /// <param name="id">Código do Cupom</param>
        /// <returns>Entidade ViewModel Cupom</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosCupomVM>> Consultar(string id)
        {
            var dadosCupomVM = await _cupomService.Consultar(id);

            if (dadosCupomVM == null)
                return NotFound();

            return Ok(dadosCupomVM);
        }

        /// <summary>
        /// Método para gravar um novo Cupom
        /// </summary>
        /// <param name="cadastroCupomVM">Entidade ViewModel cadastroCupomVM</param>
        /// <returns>Código do Cupom</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroCupomVM cadastroCupomVM)
        {
            string id = await _cupomService.Salvar(cadastroCupomVM);
            return Ok(id);
        }

        /// <summary>
        /// Método para atualizar as informações do Cupom
        /// </summary>
        /// <param name="atualizaCupomVM">Entidade ViewModel atualizaCupomVM</param>
        /// <returns>Resultado da requisição</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Atualizar(AtualizaCupomVM atualizaCupomVM)
        {
            throw new NotImplementedException();
            //return Ok();
        }
    }
}