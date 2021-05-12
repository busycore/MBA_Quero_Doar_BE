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
        public async Task<ActionResult<IEnumerable<DadosSetorAtuacaoVM>>> Listar()
        {
            var listaDadosSetorAtuacaoVM = await _setorAtuacaoService.Listar();

            if (listaDadosSetorAtuacaoVM == null)
                return NotFound();

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

        /// <summary>
        /// Método para gravar um novo SetorAtuacao
        /// </summary>
        /// <param name="cadastroSetorAtuacaoVM">Entidade ViewModel cadastroSetorAtuacaoVM</param>
        /// <returns>Código do SetorAtuacao</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroSetorAtuacaoVM cadastroSetorAtuacaoVM)
        {
            string id = await _setorAtuacaoService.Salvar(cadastroSetorAtuacaoVM);
            return Ok(id);
        }
    }
}