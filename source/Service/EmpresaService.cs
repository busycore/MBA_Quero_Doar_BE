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
            var empresa = await _empresaRepository.GetDocumentByID(id);

            if (empresa == null)
                return null;

            return ConvertToVM(empresa);
        }

        public async Task<string> Salvar(CadastroEmpresaVM cadastroEmpresaVM)
        {
            var empresa = ConvertToModel(cadastroEmpresaVM);
            await _empresaRepository.InsertOrUpdateAsync(empresa);

            return empresa._id.ToString();
        }

        public async Task Atualizar(AtualizaEmpresaVM atualizaEmpresaVM)
        {
            var empresa = ConvertToModel(atualizaEmpresaVM);
            await _empresaRepository.InsertOrUpdateAsync(empresa);
        }

        private static DadosEmpresaVM ConvertToVM(Empresa empresa)
        {
            DadosEmpresaVM dadosEmpresaVM = new DadosEmpresaVM
            {
                Id = empresa._id.ToString(),
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Site = empresa.Site,
                PessoaContato = empresa.PessoaContato,
                Telefone = empresa.Telefone,
                Email = empresa.Email,
                Password = empresa.Password
            };
            return dadosEmpresaVM;
        }

        private static Empresa ConvertToModel(CadastroEmpresaVM cadastroEmpresaVM)
        {
            Empresa empresa = new Empresa
            {
                Nome = cadastroEmpresaVM.Nome,
                CNPJ = cadastroEmpresaVM.CNPJ,
                Site = cadastroEmpresaVM.Site,
                PessoaContato = cadastroEmpresaVM.PessoaContato,
                Telefone = cadastroEmpresaVM.Telefone,
                Email = cadastroEmpresaVM.Email,
                Password = cadastroEmpresaVM.Password
            };
            return empresa;
        }

        private static Empresa ConvertToModel(AtualizaEmpresaVM atualizaEmpresaVM)
        {
            Empresa empresa = new Empresa
            {
                _id = new ObjectId(atualizaEmpresaVM.Id),
                Nome = atualizaEmpresaVM.Nome,
                CNPJ = atualizaEmpresaVM.CNPJ,
                Site = atualizaEmpresaVM.Site,
                PessoaContato = atualizaEmpresaVM.PessoaContato,
                Telefone = atualizaEmpresaVM.Telefone,
                Email = atualizaEmpresaVM.Email,
                Password = atualizaEmpresaVM.Password
            };
            return empresa;
        }
    }
}