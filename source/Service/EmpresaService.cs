using MongoDB.Bson;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Empresa;
using System.Threading.Tasks;

namespace source.Service
{
    public class EmpresaService : IService
    {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaService(EmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<DadosEmpresaVM> Consultar(string id)
        {
            DadosEmpresaVM dadosEmpresaVM = new DadosEmpresaVM();
            var empresa = await _empresaRepository.GetDocumentByID(id);

            if (empresa == null)
                return null;

            dadosEmpresaVM.Id = empresa._id.ToString();
            dadosEmpresaVM.Nome = empresa.Nome;
            dadosEmpresaVM.CNPJ = empresa.CNPJ;
            dadosEmpresaVM.Site = empresa.Site;
            dadosEmpresaVM.PessoaContato = empresa.PessoaContato;
            dadosEmpresaVM.Telefone = empresa.Telefone;
            dadosEmpresaVM.Email = empresa.Email;
            dadosEmpresaVM.Password = empresa.Password;

            return dadosEmpresaVM;
        }

        public async Task<string> Salvar(CadastroEmpresaVM cadastroEmpresaVM)
        {
            Empresa empresa = new Empresa();

            empresa.Nome = cadastroEmpresaVM.Nome;
            empresa.CNPJ = cadastroEmpresaVM.CNPJ;
            empresa.Site = cadastroEmpresaVM.Site;
            empresa.PessoaContato = cadastroEmpresaVM.PessoaContato;
            empresa.Telefone = cadastroEmpresaVM.Telefone;
            empresa.Email = cadastroEmpresaVM.Email;
            empresa.Password = cadastroEmpresaVM.Password;

            await _empresaRepository.InsertOrUpdateAsync(empresa);

            return empresa._id.ToString();
        }

        public async Task Atualizar(AtualizaEmpresaVM atualizaEmpresaVM)
        {
            Empresa empresa = new Empresa();

            empresa._id = new ObjectId(atualizaEmpresaVM.Id);
            empresa.Nome = atualizaEmpresaVM.Nome;
            empresa.CNPJ = atualizaEmpresaVM.CNPJ;
            empresa.Site = atualizaEmpresaVM.Site;
            empresa.PessoaContato = atualizaEmpresaVM.PessoaContato;
            empresa.Telefone = atualizaEmpresaVM.Telefone;
            empresa.Email = atualizaEmpresaVM.Email;
            empresa.Password = atualizaEmpresaVM.Password;

            await _empresaRepository.InsertOrUpdateAsync(empresa);
        }
    }
}