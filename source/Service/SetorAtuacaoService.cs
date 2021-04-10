using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.SetorAtuacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class SetorAtuacaoService : IService
    {
        private readonly SetorAtuacaoRepository _setorAtuacaoRepository;

        public SetorAtuacaoService(SetorAtuacaoRepository setorAtuacaoRepository)
        {
            _setorAtuacaoRepository = setorAtuacaoRepository;
        }

        public async Task<IEnumerable<DadosSetorAtuacaoVM>> Listar()
        {
            List<DadosSetorAtuacaoVM> listaDadosSetorAtuacaoVM = new List<DadosSetorAtuacaoVM>();
            var listaSetorAtuacao = await _setorAtuacaoRepository.GetAllDocument();

            foreach (var setorAtuacao in listaSetorAtuacao)
            {
                DadosSetorAtuacaoVM dadosSetorAtuacaoVM = new DadosSetorAtuacaoVM
                {
                    Id = setorAtuacao._id.ToString(),
                    Descricao = setorAtuacao.Descricao
                };
                listaDadosSetorAtuacaoVM.Add(dadosSetorAtuacaoVM);
            }

            return listaDadosSetorAtuacaoVM;
        }

        public async Task<DadosSetorAtuacaoVM> Consultar(string id)
        {
            DadosSetorAtuacaoVM dadosSetorAtuacaoVM = new DadosSetorAtuacaoVM();
            var setorAtuacao = await _setorAtuacaoRepository.GetDocumentByID(id);

            if (setorAtuacao == null)
                return null;

            dadosSetorAtuacaoVM.Id = setorAtuacao._id.ToString();
            dadosSetorAtuacaoVM.Descricao = setorAtuacao.Descricao;

            return dadosSetorAtuacaoVM;
        }

        public async Task<string> Salvar(CadastroSetorAtuacaoVM cadastroSetorAtuacaoVM)
        {
            SetorAtuacao setorAtuacao = new SetorAtuacao
            {
                Descricao = cadastroSetorAtuacaoVM.Descricao
            };

            await _setorAtuacaoRepository.InsertOrUpdateAsync(setorAtuacao);

            return setorAtuacao._id.ToString();
        }
    }
}