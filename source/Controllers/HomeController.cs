using Microsoft.AspNetCore.Mvc;
using source.Models;
using source.Service.Data;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] INoSql noSql)
        {
            SetorAtuacao SetorAnimal = new() { Descricao = "Animais de Rua" };
            SetorAtuacao SetorComida = new() { Descricao = "Comida" };
            noSql.InsertOrUpdateAsync(SetorAnimal);
            noSql.InsertOrUpdateAsync(SetorComida);

            List<Instituicao> instituicoes = new();
            instituicoes.Add(new Instituicao()
            {
                CNPJ = "1231231",
                Nome = "4 PATAS",
                Email = "4PATAS@semfome.com",
                Password = "32137289371",
                PessoaContato = "Brandão",
                SetorAtuacao = SetorAnimal,
                Site = "4patas.com.br",
                Telefone = "123",
                Descricao = "Uma instituição focada em ajudar os animais de rua a serem adotados",
                Foto = "https://cdn.pixabay.com/photo/2019/05/15/23/34/welcome-4206177_960_720.jpg"
            });

            instituicoes.Add(new Instituicao()
            {
                CNPJ = "1231231",
                Nome = "LEOES DA NOITE",
                Email = "leos@danoite.com",
                Password = "32137289371",
                PessoaContato = "Brandão",
                SetorAtuacao = SetorComida,
                Site = "LeoesDanoite.com.br",
                Telefone = "123",
                Descricao = "Uma instituição focada em ajudar todos a poderem se alimentar",
                Foto = "https://cdn.pixabay.com/photo/2020/06/21/15/58/the-rice-and-beans-5325625_960_720.jpg"
            });

            List<Empresa> empresas = new();
            empresas.Add(new()
            {
                CNPJ = "1231231312",
                Email = "ifood@ifood.com",
                Nome = "Ifood",
                Password = "23442",
                PessoaContato = "Sonia",
                Site = "ifood.com",
                Telefone = "1231231",
                Foto = "https://cdn.freelogovectors.net/wp-content/uploads/2020/10/ifood-logo.png"
            });
            empresas.Add(new()
            {
                CNPJ = "1231231312",
                Email = "Uber@ifood.com",
                Nome = "Uber",
                Password = "23442",
                PessoaContato = "Marcia",
                Site = "Uber.com",
                Telefone = "1231231",
                Foto = "https://pngimg.com/uploads/uber/uber_PNG24.png"
            });

            foreach (var inst in instituicoes)
                noSql.InsertOrUpdateAsync(inst);

            foreach (var emp in empresas)
                noSql.InsertOrUpdateAsync(emp);

            return Ok();
        }
    }
}