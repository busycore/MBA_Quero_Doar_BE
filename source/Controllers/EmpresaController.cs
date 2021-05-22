using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Empresa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        /// <summary>
        /// Método para consultar uma Empresa através do Id
        /// </summary>
        /// <param name="id">Código da Empresa</param>
        /// <returns>Entidade ViewModel Empresa</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosEmpresaVM>> Consultar(string id)
        {
            var dadosEmpresaVM = await _empresaService.Consultar(id);

            if (dadosEmpresaVM == null)
                return NotFound();

            return Ok(dadosEmpresaVM);
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<DadosEmpresaVM>>> GetAll()
        {
            var _list = await _empresaService.GetAll();
            return Ok(_list);
        }

        /// <summary>
        /// Método para gravar uma nova Empresa
        /// </summary>
        /// <param name="cadastroEmpresaVM">Entidade ViewModel cadastroEmpresaVM</param>
        /// <returns>Código da Empresa</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroEmpresaVM cadastroEmpresaVM)
        {
            string id = await _empresaService.Salvar(cadastroEmpresaVM);
            return Ok(id);
        }

        /// <summary>
        /// Método para atualizar as informações da Empresa
        /// </summary>
        /// <param name="atualizaDoadorVM">Entidade ViewModel atualizaEmpresaVM</param>
        /// <returns>Resultado da requisição</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Atualizar(AtualizaEmpresaVM atualizaEmpresaVM)
        {
            await _empresaService.Atualizar(atualizaEmpresaVM);
            return Ok();
        }
    }
}