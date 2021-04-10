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
            var cupom = await _cupomRepository.GetDocumentByID(id);

            if (cupom == null)
                return null;

            DadosCupomVM dadosCupomVM = new DadosCupomVM
            {
                Id = cupom._id.ToString(),
                IdEmpresaParceira = cupom.EmpresaParceria._id.ToString(),
                Nome = cupom.Nome,
                Descricao = cupom.Descricao,
                Valor = cupom.Valor,
                DataValidade = cupom.DataValidade
            };

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
            Cupom cupom = new Cupom
            {
                Nome = cadastroCupomVM.Nome,
                Descricao = cadastroCupomVM.Descricao,
                Valor = cadastroCupomVM.Valor,
                Ativo = true,

                EmpresaParceria = new Empresa()
                {
                    _id = new ObjectId(cadastroCupomVM.IdEmpresaParceira),
                    Nome = cadastroCupomVM.NomeEmpresaParceira

                }
            };

            if (!string.IsNullOrEmpty(cadastroCupomVM.DataValidade))
                cupom.DataValidade = Convert.ToDateTime(cadastroCupomVM.DataValidade);

            await _cupomRepository.InsertOrUpdateAsync(cupom);

            return cupom._id.ToString();
        }

        public async Task Atualizar(AtualizaCupomVM atualizaCupomVM)
        {
            Cupom cupom = new Cupom
            {
                _id = new ObjectId(atualizaCupomVM.IdCupom),
                Nome = atualizaCupomVM.Nome,
                EmpresaParceria = new Empresa()
                {
                    _id = new ObjectId(atualizaCupomVM.IdEmpresaParceira),
                    Nome = atualizaCupomVM.NomeEmpresaParceira
                },
                Descricao = atualizaCupomVM.Descricao,
                Valor = atualizaCupomVM.Valor,
                DataValidade = atualizaCupomVM.DataValidade
            };

            await _cupomRepository.InsertOrUpdateAsync(cupom);
        }
    }
}