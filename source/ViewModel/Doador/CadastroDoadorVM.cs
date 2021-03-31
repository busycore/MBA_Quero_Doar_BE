using System;

namespace source.ViewModel.Doador
{
    public class CadastroDoadorVM
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}