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
    public class CriaDadosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] INoSql noSql)
        {
            SetorAtuacao SetorAnimal = new() { Descricao = "Animais de Rua" };
            SetorAtuacao SetorComida = new() { Descricao = "Comida" };
            noSql.InsertOrUpdateAsync(SetorAnimal);
            noSql.InsertOrUpdateAsync(SetorComida);

            var patas4 = new Instituicao()
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
            };
            noSql.InsertOrUpdateAsync(patas4);

            var leoes = new Instituicao()
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
            };
            noSql.InsertOrUpdateAsync(leoes);

            Empresa ifood = new()
            {
                CNPJ = "1231231312",
                Email = "ifood@ifood.com",
                Nome = "Ifood",
                Password = "23442",
                PessoaContato = "Sonia",
                Site = "ifood.com",
                Telefone = "1231231",
                Foto = "https://cdn.freelogovectors.net/wp-content/uploads/2020/10/ifood-logo.png"
            };
            Empresa uber = new()
            {
                CNPJ = "1231231312",
                Email = "Uber@ifood.com",
                Nome = "Uber",
                Password = "23442",
                PessoaContato = "Marcia",
                Site = "Uber.com",
                Telefone = "1231231",
                Foto = "https://pngimg.com/uploads/uber/uber_PNG24.png"
            };
            noSql.InsertOrUpdateAsync(ifood);
            noSql.InsertOrUpdateAsync(uber);

            var pagClaudio = new Pagamento()
            {
                CodigoSegurancaCartao = "123",
                NomeCartao = "Claudio",
                NumeroCartao = "XXXXXXXXXXXX1234",
                ValidadeCartao = "01/2021",
                Valor = 150
            };
            noSql.InsertOrUpdateAsync(pagClaudio);

            var pagAna = new Pagamento()
            {
                CodigoSegurancaCartao = "321",
                NomeCartao = "Ana",
                NumeroCartao = "XXXXXXXXXXXX4321",
                ValidadeCartao = "01/2021",
                Valor = 35
            };
            noSql.InsertOrUpdateAsync(pagAna);

            Doador doador = new()
            {
                Nome = "Ana Lucia",
                CPF = "12345678",
                DataNascimento = new(1990, 05, 02),
                Email = "ana.lucia@querodoar.com",
                Password = "teste",
                Telefone = "12345678"
            };
            noSql.InsertOrUpdateAsync(doador);

            Cupom UB10 = new()
            {
                Ativo = true,
                DataValidade = new(2022, 05, 10),
                Descricao = "R$10,00 no UBER",
                Nivel = 3,
                Nome = "UB10",
                Valor = 25,
                EmpresaParceria = uber
            };
            noSql.InsertOrUpdateAsync(UB10);

            Cupom IF15 = new()
            {
                Ativo = true,
                DataValidade = new(2022, 05, 10),
                Descricao = "R$15,00 no Ifood",
                Nivel = 2,
                Nome = "IF15",
                Valor = 15,
                EmpresaParceria = ifood
            };
            noSql.InsertOrUpdateAsync(IF15);

            Cupom IF30 = new()
            {
                Ativo = true,
                DataValidade = new(2022, 05, 10),
                Descricao = "R$30,00 no Ifood",
                Nivel = 3,
                Nome = "IF30",
                Valor = 30,
                EmpresaParceria = ifood
            };
            noSql.InsertOrUpdateAsync(IF30);

            Cupom IF20 = new()
            {
                Ativo = true,
                DataValidade = new(2022, 05, 10),
                Descricao = "R$20,00 no Ifood",
                Nivel = 2,
                Nome = "IF20",
                Valor = 20,
                EmpresaParceria = ifood
            };
            noSql.InsertOrUpdateAsync(IF20);

            Cupom IF10 = new()
            {
                Ativo = true,
                DataValidade = new(2022, 08, 20),
                Descricao = "R$10,00 no Ifood",
                Nivel = 1,
                Nome = "IF10",
                Valor = 10,
                EmpresaParceria = ifood
            };
            noSql.InsertOrUpdateAsync(IF10);

            Doacao doacao = new()
            {
                Cupom = new Cupom[] { IF10 },
                DataDoacao = new(2021, 05, 10),
                Doador = doador,
                Instituicao = patas4,
                Pagamento = pagAna,
                ValorInstituicao = 35
            };
            noSql.InsertOrUpdateAsync(doacao);

            doacao = new()
            {
                Cupom = new Cupom[] { UB10 },
                DataDoacao = new(2021, 05, 05),
                Doador = doador,
                Instituicao = leoes,
                Pagamento = pagAna,
                ValorInstituicao = 35
            };
            noSql.InsertOrUpdateAsync(doacao);

            return Ok();
        }
    }
}