﻿using AutoMapper;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Cupom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace source.Service
{
    public class CupomService
    {
        private readonly CupomRepository _cupomRepository;
        private readonly IMapper _mapper;
        private readonly EmpresaRepository _empresaRepository;

        public CupomService(CupomRepository cupomRepository, IMapper mapper, EmpresaRepository empresaRepository)
        {
            _cupomRepository = cupomRepository;
            _mapper = mapper;
            _empresaRepository = empresaRepository;
        }

        public Task<Cupom> ConsultarCupom(string id)
        {
            return _cupomRepository.GetDocumentByID(id);
        }

        public async Task<IEnumerable<DadosCupomVM>> GetAll()
        {
            var _listRepo = await _cupomRepository.GetAllDocument();
            var _list = _mapper.Map<IEnumerable<DadosCupomVM>>(_listRepo);
            return _list;
        }

        public async Task<DadosCupomVM> Consultar(string id)
        {
            var cupom = await ConsultarCupom(id);
            var map = _mapper.Map<DadosCupomVM>(cupom);
            return map;
        }

        public async Task<string> Salvar(CadastroCupomVM cadastroCupomVM)
        {
            var newCumpom = _mapper.Map<Cupom>(cadastroCupomVM);
            newCumpom.EmpresaParceria = await _empresaRepository.GetDocumentByID(cadastroCupomVM.IdEmpresaParceira);

            await _cupomRepository.InsertOrUpdateAsync(newCumpom);
            return newCumpom._id.ToString();
        }

        //public async Task Atualizar(AtualizaCupomVM atualizaCupomVM)
        //{
        //    return Task.CompletedTask;
        //}
    }
}