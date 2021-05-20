using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doacao;
using source.ViewModel.Pagamento;
using System.Threading.Tasks;

namespace source.Service
{
    public class PagamentoService : IService
    {
        private readonly PagamentoRepository _pagamentoRepository;

        public PagamentoService(PagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<Pagamento> ConsultarPagamento(string id)
        {
            return await _pagamentoRepository.GetDocumentByID(id);
        }

        public async Task<string> Salvar(CadastroPagamentoVM cadastroPagamentoVM)
        {
            return "";
        }
    }
}