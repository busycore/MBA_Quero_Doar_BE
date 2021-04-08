using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Instituicao;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Método para consultar um Instituicao através do Id
        /// </summary>
        /// <param name="id">Código do Instituicao</param>
        /// <returns>Entidade ViewModel Instituicao</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DadosInstituicaoVM>> Consultar(string id)
        {
            var dadosInstituicaoVM = await _instituicaoService.Consultar(id);

            if (dadosInstituicaoVM == null)
                return NotFound("Instituicao não localizada");

            return Ok(dadosInstituicaoVM);
        }

        /// <summary>
        /// Método para gravar um novo Instituicao
        /// </summary>
        /// <param name="cadastroInstituicaoVM">Entidade ViewModel cadastroInstituicaoVM</param>
        /// <returns>Código do Instituicao</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> Salvar(CadastroInstituicaoVM cadastroInstituicaoVM)
        {
            string id = await _instituicaoService.Salvar(cadastroInstituicaoVM);
            return Ok(id);
        }

        /// <summary>
        /// Método para atualizar as informações do Instituicao
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