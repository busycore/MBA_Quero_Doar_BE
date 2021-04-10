using MongoDB.Bson;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Instituicao;
using source.ViewModel.SetorAtuacao;
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

            dadosInstituicaoVM.Id = Instituicao._id.ToString();
            dadosInstituicaoVM.Nome = Instituicao.Nome;
            if (Instituicao.SetorAtuacao != null)
            {
                dadosInstituicaoVM.SetorAtuacaoVM = new DadosSetorAtuacaoVM()
                {
                    Id = Instituicao.SetorAtuacao._id.ToString(),
                    Descricao = Instituicao.SetorAtuacao.Descricao
                };
            }
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
            Instituicao instituicao = new Instituicao
            {
                Nome = cadastroInstituicaoVM.Nome,
                SetorAtuacao = new SetorAtuacao() { Descricao = cadastroInstituicaoVM.SetorAtuacao },
                CNPJ = cadastroInstituicaoVM.CNPJ,
                Site = cadastroInstituicaoVM.Site,
                PessoaContato = cadastroInstituicaoVM.PessoaContato,
                Telefone = cadastroInstituicaoVM.Telefone,
                Email = cadastroInstituicaoVM.Email,
                Password = cadastroInstituicaoVM.Password
            };

            await _instituicaoRepository.InsertOrUpdateAsync(instituicao);

            return instituicao._id.ToString();
        }

        public async Task Atualizar(AtualizaInstituicaoVM atualizaInstituicaoVM)
        {
            Instituicao instituicao = new Instituicao
            {
                _id = new ObjectId(atualizaInstituicaoVM.Id),
                Nome = atualizaInstituicaoVM.Nome,
                SetorAtuacao = new SetorAtuacao()
                {
                    _id = new ObjectId(atualizaInstituicaoVM.IdSetorAtuacao),
                    Descricao = atualizaInstituicaoVM.SetorAtuacao
                },
                CNPJ = atualizaInstituicaoVM.CNPJ,
                Site = atualizaInstituicaoVM.Site,
                PessoaContato = atualizaInstituicaoVM.PessoaContato,
                Telefone = atualizaInstituicaoVM.Telefone,
                Email = atualizaInstituicaoVM.Email,
                Password = atualizaInstituicaoVM.Password
            };

            await _instituicaoRepository.InsertOrUpdateAsync(instituicao);
        }
    }
}
