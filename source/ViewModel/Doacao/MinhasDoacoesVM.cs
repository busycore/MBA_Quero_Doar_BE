using System;
using System.Collections.Generic;

namespace source.ViewModel.Doacao
{
    public class MinhasDoacoesVM
    {
        public string id { get; set; }
        public MinhasDoacoesInstituicaoVM Instituicao { get; set; }
        public IEnumerable<MinhasDoacoesCupomVM> Cupom { get; set; }
        public MinhasDoacoesPagamentoVM Pagamento { get; set; }
        public DateTime DataDoacao { get; set; }
        public decimal ValorDoado { get; set; }
    }
}