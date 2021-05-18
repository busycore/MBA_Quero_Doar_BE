using AutoMapper;
using source.Models;
using source.ViewModel.Cupom;
using source.ViewModel.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.ProfilerMapper
{
    public class ProfilerAutoMapperItems : Profile
    {
        public ProfilerAutoMapperItems()
        {
            CreateMap<DadosCupomVM, Cupom>();
            CreateMap<Cupom, DadosCupomVM>();

            CreateMap<Empresa, DadosEmpresaVM>();
            CreateMap<DadosEmpresaVM, Empresa>();
        }
    }
}