using MongoDB.Bson;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service
{
    public class DoadorService : IService
    {
        private readonly DoadorRepository _doadorRepository;

        public DoadorService(DoadorRepository doadorRepository)
        {
            _doadorRepository = doadorRepository;
        }

        public async Task<DadosDoadorVM> Consultar(string id)
        {
            DadosDoadorVM dadosDoadorVM = new DadosDoadorVM();
            var doador = await _doadorRepository.GetDocumentByID(id);

            if (doador == null)
                return null;

            dadosDoadorVM.id = doador._id.ToString();
            dadosDoadorVM.Nome = doador.Nome;
            dadosDoadorVM.CPF = doador.CPF;
            dadosDoadorVM.Telefone = doador.Telefone;
            dadosDoadorVM.DataNascimento = doador.DataNascimento;
            dadosDoadorVM.Email = doador.Email;
            dadosDoadorVM.Password = doador.Password;

            return dadosDoadorVM;
        }

        public async Task<string> Salvar(CadastroDoadorVM cadastroDoadorVM)
        {
            Doador doador = new Doador();

            doador.Nome = cadastroDoadorVM.Nome;
            doador.CPF = cadastroDoadorVM.CPF;
            doador.Telefone = cadastroDoadorVM.Telefone;
            doador.DataNascimento = cadastroDoadorVM.DataNascimento;
            doador.Email = cadastroDoadorVM.Email;
            doador.Password = cadastroDoadorVM.Password;

            await _doadorRepository.InsertOrUpdateAsync(doador);

            return doador._id.ToString();
        }

        public async Task Atualizar(AtualizaDoadorVM atualizaDoadorVM)
        {
            Doador doador = new Doador();

            doador._id = new ObjectId(atualizaDoadorVM.id);
            doador.Nome = atualizaDoadorVM.Nome;
            doador.CPF = atualizaDoadorVM.CPF;
            doador.Telefone = atualizaDoadorVM.Telefone;
            doador.DataNascimento = atualizaDoadorVM.DataNascimento;
            doador.Email = atualizaDoadorVM.Email;
            doador.Password = atualizaDoadorVM.Password;

            await _doadorRepository.InsertOrUpdateAsync(doador);
        }
    }
}