namespace source.ViewModel.Doacao
{
    public class CadastroPagamentoVM
    {
        public decimal Valor { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoSegurancaCartao { get; set; }
        public string ValidadeCartao { get; set; }
        public string StatusProcessamento { get; set; }

    }
}