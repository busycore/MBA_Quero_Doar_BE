using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Doacao;
using source.ViewModel.Instituicao;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly DoacaoService _doacao;

        public DoacaoController(DoacaoService doacao)
        {
            _doacao = doacao;
        }

        [HttpPost("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DadosInstituicaoVM>> FazerDoacao(CadastroDoacaoVM doacaoVM)
        {
            await _doacao.Salvar(doacaoVM);
            return Ok(doacaoVM);
        }
    }
}