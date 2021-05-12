using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.MinhaConta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinhasDoacoesController : ControllerBase
    {
        private readonly MinhasDoacoesService _minhasDoacoesService;

        public MinhasDoacoesController(MinhasDoacoesService minhasDoacoesService)
        {
            _minhasDoacoesService = minhasDoacoesService;
        }

        /// <summary>
        /// Método para listar as doações através do Id do doador
        /// </summary>
        /// <param name="id">Código da Doador</param>
        /// <returns>Entidade ViewModel DadosMinhasDoacoesVM</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<DadosMinhasDoacoesVM>>> Listar(string id)
        {
            var listarMinhasDoacoes = await _minhasDoacoesService.ListarMinhasDoacoes(id);

            if (listarMinhasDoacoes == null)
                return NotFound();

            return Ok(listarMinhasDoacoes);
        }
    }
}