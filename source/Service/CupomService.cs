using AutoMapper;
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
        private readonly IMapper _mapper;

        public CupomService(CupomRepository cupomRepository, IMapper mapper)
        {
            _cupomRepository = cupomRepository;
            _mapper = mapper;
        }

        public Task<Cupom> ConsultarCupom(string id)
        {
            return _cupomRepository.GetDocumentByID(id);
        }

        public async Task<DadosCupomVM> Consultar(string id)
        {
            var cupom = await _cupomRepository.GetDocumentByID(id);
            var map = _mapper.Map<DadosCupomVM>(cupom);
            return map;
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