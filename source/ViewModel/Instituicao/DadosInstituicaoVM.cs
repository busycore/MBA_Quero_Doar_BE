using source.ViewModel.SetorAtuacao;

namespace source.ViewModel.Instituicao
{
    public class DadosInstituicaoVM
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DadosSetorAtuacaoVM SetorAtuacao { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public string PessoaContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}