using System;

namespace source.ViewModel.Cupom
{
    public class CadastroCupomVM
    {
        public string IdEmpresaParceira { get; set; }
        public string Nome { get; set; }
        public string NomeEmpresaParceira { get; set; }
        public decimal Valor { get; set; }
        public decimal Nivel { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}