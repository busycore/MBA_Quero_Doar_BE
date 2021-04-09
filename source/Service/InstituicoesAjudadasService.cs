using source.ViewModel.MinhaConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service
{
    public class InstituicoesAjudadasService
    {
        private readonly DoacaoService _doacaoService;

        public InstituicoesAjudadasService(DoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        public async Task<IEnumerable<DadosInstituicoesAjudadasVM>> ListarInstituicoesAjudadas(string id)
        {
            var listaInstituicoesAjudadas = await _doacaoService.ListarInstituicoesAjudadas(id);

            List<DadosInstituicoesAjudadasVM> listaInstituicoesAjudadasVM = new List<DadosInstituicoesAjudadasVM>();

            foreach (var instituicoesAjudadasVM in listaInstituicoesAjudadas)
            {
                DadosInstituicoesAjudadasVM dadosInstituicoesAjudadasVM = new DadosInstituicoesAjudadasVM();
                dadosInstituicoesAjudadasVM.Nome = instituicoesAjudadasVM.Nome;
                dadosInstituicoesAjudadasVM.Valor = instituicoesAjudadasVM.Valor;
                dadosInstituicoesAjudadasVM.DataDoacao = instituicoesAjudadasVM.DataDoacao;
                dadosInstituicoesAjudadasVM.Site = instituicoesAjudadasVM.Site;
                listaInstituicoesAjudadasVM.Add(dadosInstituicoesAjudadasVM);
            }

            return listaInstituicoesAjudadasVM;
        }
    }
}