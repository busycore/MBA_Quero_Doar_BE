using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Pagamento;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoService _pagamentoService;
        private readonly DoacaoService _doacaoService;

        public PagamentoController(PagamentoService pagamentoService, DoacaoService doacaoService)
        {
            _pagamentoService = pagamentoService;
            _doacaoService = doacaoService;
        }

        /// <summary>
        /// Método para gravar um novo Pagamento
        /// </summary>
        /// <param name="cadastroPagamentoVM">Entidade ViewModel cadastroPagamentoVM</param>
        /// <returns>Código do Pagamento</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroPagamentoVM cadastroPagamentoVM)
        {
            var cadastroDoacaoVM = await _pagamentoService.GerarDoacao(cadastroPagamentoVM);
            string id = await _doacaoService.Salvar(cadastroDoacaoVM);
            return Ok(id);
        }
    }
}