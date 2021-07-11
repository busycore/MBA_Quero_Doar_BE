using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.Auth;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        /// <summary>
        /// Faz o login do usuário
        /// <paramref name="dadosLogin"/> 
        /// TipoLogin
        ///   E = Empresa
        ///   D = Doador
        ///   I = Instituição
        /// </summary>
        /// <param name="dadosLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<DadosToken>> Login(DadosLogin dadosLogin)
        {
            var _token = await _auth.ValidarUsuario(dadosLogin);
            if (_token == null)
                return Unauthorized();

            return Ok(_token);
        }

    }
}