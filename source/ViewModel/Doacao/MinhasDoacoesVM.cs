using source.ViewModel.Cupom;
using System;

namespace source.ViewModel.Doacao
{
    public class MinhasDoacoesVM
    {
        public string id { get; set; }
        public MinhasDoacoesInstituicaoVM Instituicao { get; set; }
        public MinhasDoacoesCupomVM Cupom { get; set; }
        public DateTime DataDoacao { get; set; }
        public decimal ValorDoado { get; set; }
    }
}