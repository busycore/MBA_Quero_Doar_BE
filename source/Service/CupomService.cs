using MongoDB.Bson;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Cupom;
using source.ViewModel.Empresa;
using System;
using System.Threading.Tasks;

namespace source.Service
{
    public class CupomService
    {
        private readonly CupomRepository _cupomRepository;
        public CupomService(CupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }

        public async Task<Cupom> ConsultarCupom(string id)
        {
            return await _cupomRepository.GetDocumentByID(id);
        }

        public async Task<DadosCupomVM> Consultar(string id)
        {
            DadosCupomVM dadosCupomVM = new DadosCupomVM();
            var cupom = await _cupomRepository.GetDocumentByID(id);

            if (cupom == null)
                return null;

            dadosCupomVM.Id = cupom._id.ToString();
            dadosCupomVM.IdEmpresaParceira = cupom.EmpresaParceria._id.ToString();
            dadosCupomVM.Nome = cupom.Nome;
            dadosCupomVM.Descricao = cupom.Descricao;
            dadosCupomVM.Valor = cupom.Valor;
            dadosCupomVM.DataValidade = cupom.DataValidade;

            if (cupom.EmpresaParceria != null)
            {
                dadosCupomVM.DadosEmpresaVM = new DadosEmpresaVM()
                {
                    Id = cupom.EmpresaParceria._id.ToString(),
                    Nome = cupom.EmpresaParceria.Nome
                };
            }
         
            return dadosCupomVM;
        }

        public async Task<string> Salvar(CadastroCupomVM cadastroCupomVM)
        {
            Cupom cupom = new Cupom();

            cupom.Nome = cadastroCupomVM.Nome;
            cupom.Nome = cadastroCupomVM.Nome;
            cupom.Descricao = cadastroCupomVM.Descricao;
            cupom.Valor = cadastroCupomVM.Valor;
            cupom.Ativo = true;

            cupom.EmpresaParceria = new Empresa() 
            {
                _id = new ObjectId(cadastroCupomVM.IdEmpresaParceira),
                Nome = cadastroCupomVM.NomeEmpresaParceira 

            };
            
            if (!string.IsNullOrEmpty(cadastroCupomVM.DataValidade))
                cupom.DataValidade = Convert.ToDateTime(cadastroCupomVM.DataValidade);

            await _cupomRepository.InsertOrUpdateAsync(cupom);

            return cupom._id.ToString();
        }

        public async Task Atualizar(AtualizaCupomVM atualizaCupomVM)
        {
            Cupom cupom = new Cupom();

            cupom._id = new ObjectId(atualizaCupomVM.IdCupom);
            cupom.Nome = atualizaCupomVM.Nome;
            cupom.EmpresaParceria = new Empresa()
            {
                _id = new ObjectId(atualizaCupomVM.IdEmpresaParceira),
                Nome = atualizaCupomVM.NomeEmpresaParceira
            };
            cupom.Nome = atualizaCupomVM.Nome;
            cupom.Descricao = atualizaCupomVM.Descricao;
            cupom.Valor = atualizaCupomVM.Valor;
            cupom.DataValidade = atualizaCupomVM.DataValidade;

            await _cupomRepository.InsertOrUpdateAsync(cupom);
        }
    }
}
