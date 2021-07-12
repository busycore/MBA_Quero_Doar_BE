using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Doador;
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
            _doadorService = doadorService;
        }

        /// <summary>
        /// Método para consultar um Doador através do Id
        /// </summary>
        /// <param name="id">Código do Doador</param>
        /// <returns>Entidade ViewModel Doador</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosDoadorVM>> Consultar(string id)
        {
            var dadosDoadorVM = await _doadorService.Consultar(id);

            if (dadosDoadorVM == null)
                return NotFound();

            return Ok(dadosDoadorVM);
        }

        /// <summary>
        /// Método para gravar um novo Doador
        /// </summary>
        /// <param name="cadastroDoadorVM">Entidade ViewModel cadastroDoadorVM</param>
        /// <returns>Código do Doador</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Salvar(CadastroDoadorVM cadastroDoadorVM)
        {
            string id = await _doadorService.Salvar(cadastroDoadorVM);
            return Ok(id);
        }

        /// <summary>
        /// Método para atualizar as informações do Doador
        /// </summary>
        /// <param name="atualizaDoadorVM">Entidade ViewModel atualizaDoadorVM</param>
        /// <returns>Resultado da requisição</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Atualizar(AtualizaDoadorVM atualizaDoadorVM)
        {
            await _doadorService.Atualizar(atualizaDoadorVM);
            return Ok();
        }
    }
}