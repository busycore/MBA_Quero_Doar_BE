using source.ViewModel.Empresa;
using System;

namespace source.ViewModel.Cupom
{
    public class DadosCupomVM
    {
        public string Id { get; set; }
        public DadosEmpresaVM EmpresaParceria { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Nivel { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}