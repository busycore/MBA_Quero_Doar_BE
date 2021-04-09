using source.Service.Interfaces;
using source.ViewModel.MinhaConta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class MinhasDoacoesService : IService
    {
        private readonly DoacaoService _doacaoService;

        public MinhasDoacoesService(DoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        public async Task<IEnumerable<DadosMinhasDoacoesVM>> ListarMinhasDoacoes(string id)
        {
            var listaMinhasDoacoes = await _doacaoService.ListarMinhasDoacoes(id);

            List<DadosMinhasDoacoesVM> listaDadosMeusCuponsVM = new List<DadosMinhasDoacoesVM>();

            foreach (var minhaDoacoes in listaMinhasDoacoes)
            {
                DadosMinhasDoacoesVM dadosMinhasDoacoesVM = new DadosMinhasDoacoesVM();
                dadosMinhasDoacoesVM.Cartao = $"**** {minhaDoacoes.Cartao.Substring(5, 9)} ****";
                dadosMinhasDoacoesVM.Valor = minhaDoacoes.Valor;
                dadosMinhasDoacoesVM.DataDoacao = minhaDoacoes.DataDoacao;
                listaDadosMeusCuponsVM.Add(dadosMinhasDoacoesVM);
            }

            return listaDadosMeusCuponsVM;
        }
    }
}