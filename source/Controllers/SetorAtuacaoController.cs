using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.SetorAtuacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetorAtuacaoController : ControllerBase
    {
        private readonly SetorAtuacaoService _setorAtuacaoService;

        public SetorAtuacaoController(SetorAtuacaoService setorAtuacaoService)
        {
            _setorAtuacaoService = setorAtuacaoService;
        }

        /// <summary>
        /// Método para consultar todos os SetorAtuacao
        /// </summary>
        /// <returns>Lista Entidade ViewModel SetorAtuacao</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<DadosSetorAtuacaoVM>>> ListarTodos()
        {
            var listaDadosSetorAtuacaoVM = await _setorAtuacaoService.ListarTodos();
            return Ok(listaDadosSetorAtuacaoVM);
        }

        /// <summary>
        /// Método para consultar um SetorAtuacao através do Id
        /// </summary>
        /// <param name="id">Código do SetorAtuacao</param>
        /// <returns>Entidade ViewModel SetorAtuacao</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosSetorAtuacaoVM>> Consultar(string id)
        {
            var dadosSetorAtuacaoVM = await _setorAtuacaoService.Consultar(id);

            if (dadosSetorAtuacaoVM == null)
                return NotFound();

            return Ok(dadosSetorAtuacaoVM);
        }
    }
}