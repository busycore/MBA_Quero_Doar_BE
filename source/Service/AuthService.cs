using Microsoft.IdentityModel.Tokens;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace source.Service
{
    public class AuthService : IService
    {
        private readonly DoadorRepository _doador;
        private readonly EmpresaRepository _empresa;
        private readonly InstituicaoRepository _instituicao;

        public AuthService(DoadorRepository doador, EmpresaRepository empresa, InstituicaoRepository instituicao)
        {
            _doador = doador;
            _empresa = empresa;
            _instituicao = instituicao;
        }

        public async Task<DadosToken> ValidarUsuario(DadosLogin dadosLogin)
        {
            bool _valido = false;
            string _nome = null;
            string _userId = null;
            switch (dadosLogin.TipoLogin)
            {
                case 'D':
                    var _d = await _doador.GetByAsync(m => m.Email.Equals(dadosLogin.Email) && m.Password.Equals(dadosLogin.Password));
                    if (_d != null && _d.Any())
                    {
                        _nome = _d.FirstOrDefault().Nome;
                        _userId = _d.FirstOrDefault()._id.ToString();
                        _valido = true;
                    }
                    break;

                case 'E':
                    var _e = await _empresa.GetByAsync(m => m.Email.Equals(dadosLogin.Email) && m.Password.Equals(dadosLogin.Password));
                    if (_e != null && _e.Any())
                    {
                        _nome = _e.FirstOrDefault().Nome;
                        _userId = _d.FirstOrDefault()._id.ToString();
                        _valido = true;
                    }
                    break;

                case 'I':
                    var _i = await _empresa.GetByAsync(m => m.Email.Equals(dadosLogin.Email) && m.Password.Equals(dadosLogin.Password));
                    if (_i != null && _i.Any())
                    {
                        _nome = _i.FirstOrDefault().Nome;
                        _userId = _d.FirstOrDefault()._id.ToString();
                        _valido = true;
                    }
                    break;
            }

            if (_valido)
                return CriarToken(_nome, _userId);

            return null;
        }

        private DadosToken CriarToken(string nomeUsuario, string userId)
        {
            byte[] _key = Convert.FromBase64String("mlyDaLVs3SA0jQcHOlxZRiTZ0JvYvpGLxHN312KddWPHg8vlNSpXh0Xt61QelkEcz+UGnQ85fhMy/X0/cBmJAQ==");
            DateTime dataCriacao = DateTime.UtcNow;
            DateTime dataExpiracao = dataCriacao.AddMinutes(30);
            SigningCredentials creds = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256);

            //-- cria parametros para o token
            JwtSecurityTokenHandler handle = new();
            JwtSecurityToken tokenSecurity = handle.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new GenericIdentity(nomeUsuario), null),
                Issuer = "http://localhost:8080", //-- origem de criação do token
                IssuedAt = dataCriacao, //-- data de criação do token
                Audience = "", //-- recurso habilitado para login
                Expires = dataExpiracao, //-- data de expiração\
                NotBefore = dataCriacao.AddMinutes(-1), //-- inicio da possibilidade de utilização do token
                SigningCredentials = creds, //-- forma de assinatura
            });

            return new DadosToken()
            {
                Token = handle.WriteToken(tokenSecurity),
                DtValidade = dataExpiracao,
                userId = userId
            };
        }
    }
}