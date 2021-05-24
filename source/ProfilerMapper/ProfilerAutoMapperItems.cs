using AutoMapper;
using MongoDB.Bson;
using source.Models;
using source.ViewModel.Cupom;
using source.ViewModel.Doacao;
using source.ViewModel.Doador;
using source.ViewModel.Empresa;
using source.ViewModel.Instituicao;
using source.ViewModel.SetorAtuacao;

namespace source.ProfilerMapper
{
    public class ProfilerAutoMapperItems : Profile
    {
        public ProfilerAutoMapperItems()
        {
            _ = CreateMap<DadosCupomVM, Cupom>()
                .ForMember(m => m._id, opt => opt.MapFrom(src => new ObjectId(src.Id)));
            _ = CreateMap<Cupom, DadosCupomVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));

            _ = CreateMap<Empresa, DadosEmpresaVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));
            _ = CreateMap<DadosEmpresaVM, Empresa>()
                .ForMember(m => m._id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

            _ = CreateMap<DadosInstituicaoVM, Instituicao>()
                .ForMember(m => m._id, opt => opt.MapFrom(src => new ObjectId(src.Id)));
            _ = CreateMap<Instituicao, DadosInstituicaoVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));

            _ = CreateMap<SetorAtuacao, DadosSetorAtuacaoVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));
            _ = CreateMap<DadosSetorAtuacaoVM, SetorAtuacao>()
                .ForMember(m => m._id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

            _ = CreateMap<Doador, DadosDoadorVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));
            _ = CreateMap<DadosDoadorVM, Doador>()
                .ForMember(m => m._id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

            _ = CreateMap<Doacao, MinhasDoacoesVM>()
                .ForMember(m => m.id, opt => opt.MapFrom(src => src._id.ToString()))
                .ForMember(m => m.ValorDoado, opt => opt.MapFrom(src => src.Pagamento.Valor));
            _ = CreateMap<Instituicao, MinhasDoacoesInstituicaoVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));
            _ = CreateMap<Cupom, MinhasDoacoesCupomVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()));
            _ = CreateMap<Pagamento, MinhasDoacoesPagamentoVM>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src._id.ToString()))
                .ForMember(m => m.NumeroCartao, opt => opt.MapFrom(src => src.NumeroCartao.Substring(12, 4).PadLeft(16, 'x')));
        }
    }
}