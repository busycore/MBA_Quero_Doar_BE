using System;

namespace source.ViewModel
{
    public class DadosMeusCuponsVM
    {
        public string Empresa { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public bool CupomUtilizado { get; set; }
    }
}