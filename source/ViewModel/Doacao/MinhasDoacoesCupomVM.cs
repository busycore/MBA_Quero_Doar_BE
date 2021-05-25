using source.ViewModel.Empresa;

namespace source.ViewModel.Doacao
{
    public class MinhasDoacoesCupomVM
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string nome { get; set; }
        public DadosEmpresaVM EmpresaParceria { get; set; }
    }
}