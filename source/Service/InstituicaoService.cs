using MongoDB.Bson;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Instituicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service
{
    public class InstituicaoService
    {
        private readonly InstituicaoRepository _instituicaoRepository;
        public InstituicaoService(InstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        public async Task<Instituicao> ConsultarInstituicao(string id)
        {
            return await _instituicaoRepository.GetDocumentByID(id);
        }

        public async Task<DadosInstituicaoVM> Consultar(string id)
        {
            DadosInstituicaoVM dadosInstituicaoVM = new DadosInstituicaoVM();
            var Instituicao = await _instituicaoRepository.GetDocumentByID(id);

            if (Instituicao == null)
                return null;

            dadosInstituicaoVM.id = Instituicao._id.ToString();
            dadosInstituicaoVM.Nome = Instituicao.Nome;
            dadosInstituicaoVM.SetorAtuacaoVM.Id = Instituicao.SetorAtuacao._id.ToString();
            dadosInstituicaoVM.CNPJ = Instituicao.CNPJ;
            dadosInstituicaoVM.Site = Instituicao.Site;
            dadosInstituicaoVM.PessoaContato = Instituicao.PessoaContato;
            dadosInstituicaoVM.Telefone = Instituicao.Telefone;
            dadosInstituicaoVM.Email = Instituicao.Email;
            dadosInstituicaoVM.Password = Instituicao.Password;

            return dadosInstituicaoVM;
        }

        public async Task<string> Salvar(CadastroInstituicaoVM cadastroInstituicaoVM)
        {
            Instituicao instituicao = new Instituicao();

            instituicao.Nome = cadastroInstituicaoVM.Nome;
            instituicao.SetorAtuacao = new SetorAtuacao() { Descricao = cadastroInstituicaoVM.SetorAtuacao };
            instituicao.CNPJ = cadastroInstituicaoVM.CNPJ;
            instituicao.Site = cadastroInstituicaoVM.Site;
            instituicao.PessoaContato = cadastroInstituicaoVM.PessoaContato;
            instituicao.Telefone = cadastroInstituicaoVM.Telefone;
            instituicao.Email = cadastroInstituicaoVM.Email;
            instituicao.Password = cadastroInstituicaoVM.Password;

            await _instituicaoRepository.InsertOrUpdateAsync(instituicao);

            return instituicao._id.ToString();
        }

        public async Task Atualizar(AtualizaInstituicaoVM atualizaInstituicaoVM)
        {
            Instituicao instituicao = new Instituicao();

            instituicao.Nome = atualizaInstituicaoVM.Nome;
            instituicao.SetorAtuacao._id = new ObjectId(atualizaInstituicaoVM.SetorAtuacaoVM.Id);
            instituicao.CNPJ = atualizaInstituicaoVM.CNPJ;
            instituicao.Site = atualizaInstituicaoVM.Site;
            instituicao.PessoaContato = atualizaInstituicaoVM.PessoaContato;
            instituicao.Telefone = atualizaInstituicaoVM.Telefone;
            instituicao.Email = atualizaInstituicaoVM.Email;
            instituicao.Password = atualizaInstituicaoVM.Password;

            await _instituicaoRepository.InsertOrUpdateAsync(instituicao);
        }
    }
}
