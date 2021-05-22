using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Instituicao;
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

        /// <summary>
        /// Método para consultar uma Instituicao através do Id
        /// </summary>
        /// <param name="id">Código do Instituicao</param>
        /// <param name="DadosInstituicaoVM">Entidade ViewModel DadosInstituicaoVM</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosInstituicaoVM>> Consultar(string id)
        {
            var dadosInstituicaoVM = await _instituicaoService.Consultar(id);

            if (dadosInstituicaoVM == null)
                return NotFound();

            return Ok(dadosInstituicaoVM);
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DadosInstituicaoVM>> Consultar()
        {
            var _all = await _instituicaoService.GetAll();
            return Ok(_all);
        }

        /// <summary>
        /// Método para gravar uma nova Instituicao
        /// </summary>
        /// <param name="cadastroInstituicaoVM">Entidade ViewModel cadastroInstituicaoVM</param>
        /// <returns>Código da Instituicao</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroInstituicaoVM cadastroInstituicaoVM)
        {
            string id = await _instituicaoService.Salvar(cadastroInstituicaoVM);
            return Ok(id);
        }

        /// <summary>
        /// Método para atualizar as informações da Instituicao
        /// </summary>
        /// <param name="atualizaInstituicaoVM">Entidade ViewModel atualizaInstituicaoVM</param>
        /// <returns>Resultado da requisição</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Atualizar(AtualizaInstituicaoVM atualizaInstituicaoVM)
        {
            await _instituicaoService.Atualizar(atualizaInstituicaoVM);
            return Ok();
        }
    }
}