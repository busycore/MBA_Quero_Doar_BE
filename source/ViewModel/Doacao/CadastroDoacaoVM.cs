using System.Collections.Generic;

namespace source.ViewModel.Doacao
{
    public class CadastroDoacaoVM
    {
        public string IdDoador { get; set; }
        public string IdInstituicao { get; set; }
        public CadastroPagamentoVM pagamento { get; set; }
        public IEnumerable<string> IdCupom { get; set; }
        public decimal Valor { get; set; }
    }
}