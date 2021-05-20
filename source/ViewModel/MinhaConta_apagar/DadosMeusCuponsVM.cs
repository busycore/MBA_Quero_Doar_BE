using source.ViewModel.Cupom;
using source.ViewModel.Doador;
using source.ViewModel.Empresa;
using System;

namespace source.ViewModel.MinhaConta
{
    public class DadosMeusCuponsVM
    {
        public string Id { get; set; }
        public DadosCupomVM Cupom { get; set; }
        public DadosEmpresaVM DadosEmpresa { get; set; }
        public DadosDoadorVM DadosDoador { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataValidade { get; set; }
        public bool CupomUtilizado { get; set; }
    }
}