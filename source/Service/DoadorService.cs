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
            var doador = await _doadorRepository.GetDocumentByID(id);

            if (doador == null)
                return null;

            DadosDoadorVM dadosDoadorVM = ConvertToVM(doador);

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

        private static DadosDoadorVM ConvertToVM(Doador doador)
        {
            DadosDoadorVM dadosDoadorVM = new DadosDoadorVM
            {
                Id = doador._id.ToString(),
                Nome = doador.Nome,
                CPF = doador.CPF,
                Telefone = doador.Telefone,
                DataNascimento = doador.DataNascimento,
                Email = doador.Email,
                Password = doador.Password
            };
            return dadosDoadorVM;
        }

        private static Doador ConvertToModel(CadastroDoadorVM cadastroDoadorVM)
        {
            Doador doador = new Doador
            {
                Nome = cadastroDoadorVM.Nome,
                CPF = cadastroDoadorVM.CPF,
                Telefone = cadastroDoadorVM.Telefone,
                DataNascimento = cadastroDoadorVM.DataNascimento,
                Email = cadastroDoadorVM.Email,
                Password = cadastroDoadorVM.Password
            };
            return doador;
        }

        private static Doador ConvertToModel(AtualizaDoadorVM atualizaDoadorVM)
        {
            Doador doador = new Doador
            {
                _id = new ObjectId(atualizaDoadorVM.Id),
                Nome = atualizaDoadorVM.Nome,
                CPF = atualizaDoadorVM.CPF,
                Telefone = atualizaDoadorVM.Telefone,
                DataNascimento = atualizaDoadorVM.DataNascimento,
                Email = atualizaDoadorVM.Email,
                Password = atualizaDoadorVM.Password
            };
            return doador;
        }
    }
}