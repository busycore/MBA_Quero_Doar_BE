using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.MinhaConta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstituicoesAjudadasController : ControllerBase
    {
        private readonly InstituicoesAjudadasService _instituicoesAjudadasService;

        public InstituicoesAjudadasController(InstituicoesAjudadasService instituicoesAjudadasService)
        {
            _instituicoesAjudadasService = instituicoesAjudadasService;
        }

        /// <summary>
        /// Método para listar as Instituições Ajudadas através do Id do doador
        /// </summary>
        /// <param name="id">Código da Doador</param>
        /// <returns>Entidade ViewModel DadosInstituicoesAjudadasVM</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<DadosInstituicoesAjudadasVM>>> Listar(string id)
        {
            var listarMinhasDoacoes = await _instituicoesAjudadasService.ListarInstituicoesAjudadas(id);

            if (listarMinhasDoacoes == null)
                return NotFound("Doador não foi localizado");

            return Ok(listarMinhasDoacoes);
        }

    }
}