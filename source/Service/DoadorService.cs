using MongoDB.Bson;
using source.Models;
using source.Service.Interfaces;
using source.Service.Repository;
using source.ViewModel.Doador;
using System.Threading.Tasks;

namespace source.Service
{
    public class DoadorService : IService
    {
        private readonly DoadorRepository _doadorRepository;

        public DoadorService(DoadorRepository doadorRepository)
        {
            _doadorRepository = doadorRepository;
        }

        public async Task<Doador> ConsultarDoador(string id)
        {
            return await _doadorRepository.GetDocumentByID(id);
        }

        public async Task<DadosDoadorVM> Consultar(string id)
        {
            DadosDoadorVM dadosDoadorVM = new DadosDoadorVM();
            var doador = await _doadorRepository.GetDocumentByID(id);

            if (doador == null)
                return null;

            dadosDoadorVM = ConvertToVM(doador);

            return dadosDoadorVM;
        }

        public async Task<string> Salvar(CadastroDoadorVM cadastroDoadorVM)
        {
            Doador doador = ConvertToModel(cadastroDoadorVM);

            await _doadorRepository.InsertOrUpdateAsync(doador);

            return doador._id.ToString();
        }

        public async Task Atualizar(AtualizaDoadorVM atualizaDoadorVM)
        {
            Doador doador = ConvertToModel(atualizaDoadorVM);
            await _doadorRepository.InsertOrUpdateAsync(doador);
        }

        private DadosDoadorVM ConvertToVM(Doador doador)
        {
            DadosDoadorVM dadosDoadorVM = new DadosDoadorVM();
            dadosDoadorVM.Id = doador._id.ToString();
            dadosDoadorVM.Nome = doador.Nome;
            dadosDoadorVM.CPF = doador.CPF;
            dadosDoadorVM.Telefone = doador.Telefone;
            dadosDoadorVM.DataNascimento = doador.DataNascimento;
            dadosDoadorVM.Email = doador.Email;
            dadosDoadorVM.Password = doador.Password;
            return dadosDoadorVM;
        }

        private Doador ConvertToModel(CadastroDoadorVM cadastroDoadorVM)
        {
            Doador doador = new Doador();
            doador.Nome = cadastroDoadorVM.Nome;
            doador.CPF = cadastroDoadorVM.CPF;
            doador.Telefone = cadastroDoadorVM.Telefone;
            doador.DataNascimento = cadastroDoadorVM.DataNascimento;
            doador.Email = cadastroDoadorVM.Email;
            doador.Password = cadastroDoadorVM.Password;
            return doador;
        }

        private Doador ConvertToModel(AtualizaDoadorVM atualizaDoadorVM)
        {
            Doador doador = new Doador();
            doador._id = new ObjectId(atualizaDoadorVM.Id);
            doador.Nome = atualizaDoadorVM.Nome;
            doador.CPF = atualizaDoadorVM.CPF;
            doador.Telefone = atualizaDoadorVM.Telefone;
            doador.DataNascimento = atualizaDoadorVM.DataNascimento;
            doador.Email = atualizaDoadorVM.Email;
            doador.Password = atualizaDoadorVM.Password;
            return doador;
        }
    }
}