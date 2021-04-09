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
            var pagamento = ConvertToVM(cadastroPagamentoVM);
            await _pagamentoRepository.InsertOrUpdateAsync(pagamento);
            return pagamento._id.ToString();
        }

        public async Task<CadastroDoacaoVM> GerarDoacao(CadastroPagamentoVM cadastroPagamentoVM)
        {
            string idPagamento = await Salvar(cadastroPagamentoVM);
            return ConvertToModel(cadastroPagamentoVM, idPagamento);
        }

        private Pagamento ConvertToVM(CadastroPagamentoVM cadastroPagamentoVM)
        {
            Pagamento pagamento = new Pagamento();
            pagamento.Valor = cadastroPagamentoVM.Valor;
            pagamento.NomeCartao = cadastroPagamentoVM.NomeCartao;
            pagamento.NumeroCartao = cadastroPagamentoVM.NumeroCartao;
            pagamento.CodigoSegurancaCartao = cadastroPagamentoVM.CodigoSegurancaCartao;
            pagamento.ValidadeCartao = cadastroPagamentoVM.ValidadeCartao;
            return pagamento;
        }

        private CadastroDoacaoVM ConvertToModel(CadastroPagamentoVM cadastroPagamentoVM, string idPagamento)
        {
            CadastroDoacaoVM cadastroDoacaoVM = new CadastroDoacaoVM();
            cadastroDoacaoVM.IdDoador = cadastroPagamentoVM.IdDoador;
            cadastroDoacaoVM.IdInstituicao = cadastroPagamentoVM.IdInstituicao;
            cadastroDoacaoVM.Valor = cadastroPagamentoVM.Valor;
            cadastroDoacaoVM.IdPagamento = idPagamento;
            return cadastroDoacaoVM;
        }
    }
}