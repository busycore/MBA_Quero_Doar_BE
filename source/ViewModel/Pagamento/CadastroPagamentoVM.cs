namespace source.ViewModel.Pagamento
{
    public class CadastroPagamentoVM
    {
        public string IdDoador { get; set; }
        public string IdInstituicao { get; set; }
        public decimal Valor { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoSegurancaCartao { get; set; }
        public string ValidadeCartao { get; set; }
    }
}