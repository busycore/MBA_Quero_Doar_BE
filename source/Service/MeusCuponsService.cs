using MongoDB.Bson;
using source.Models;
using source.Service.Repository;
using source.ViewModel.Cupom;
using source.ViewModel.Doador;
using source.ViewModel.Empresa;
using source.ViewModel.MinhaConta;
using System;
using System.Threading.Tasks;


namespace source.Service
{
    public class MeusCuponsService
    {
        private readonly MeusCuponsRepository _meusCuponsRepository;

        public MeusCuponsService(MeusCuponsRepository meusCuponsRepository)
        {
            _meusCuponsRepository = meusCuponsRepository;
        }

        public async Task<MeusCupons> ConsultarMeusCupons(string id)
        {
            return await _meusCuponsRepository.GetDocumentByID(id);
        }

        public async Task<DadosMeusCuponsVM> Consultar(string id)
        {
            DadosMeusCuponsVM dadosMeusCupomVM = new DadosMeusCuponsVM();
            var meuCupon = await _meusCuponsRepository.GetDocumentByID(id);

            if (meuCupon == null)
                return null;
            
            dadosMeusCupomVM.Id = meuCupon._id.ToString();
            dadosMeusCupomVM.DataValidade = meuCupon.DataValidade;
            dadosMeusCupomVM.DataResgate = meuCupon.DataResgate;

            if (meuCupon.EmpresaParceria != null)
            {
                dadosMeusCupomVM.DadosEmpresa = new DadosEmpresaVM()
                {
                    Id = meuCupon.EmpresaParceria._id.ToString(),
                    Nome = meuCupon.EmpresaParceria.Nome
                };
            }

            if (meuCupon.Doador != null)
            {
                dadosMeusCupomVM.DadosDoador = new DadosDoadorVM()
                {
                    Id = meuCupon.Doador._id.ToString(),
                    Nome = meuCupon.Doador.Nome
                };
            }

            if (meuCupon.Cupom != null)
            {
                dadosMeusCupomVM.Cupom = new DadosCupomVM()
                {
                    Id = meuCupon.Doador._id.ToString(),
                    Nome = meuCupon.Doador.Nome,
                    DataValidade = meuCupon.DataValidade
                };
            }

            return dadosMeusCupomVM;
        }

        //public async Task<string> Salvar(DadosMeusCuponsVM cadastroCupomVM)
        //{
        //    MeusCupons meusCupom = new MeusCupons();

        //    meusCupom.DataValidade = cadastroCupomVM.DataValidade;
        //    meusCupom.DataResgate = cadastroCupomVM.DataResgate;
        //    meusCupom.Ativo = true;

            
            

        //    meusCupom.EmpresaParceria = new Empresa()
        //    {
        //        _id = new ObjectId(cadastroCupomVM.IdEmpresaParceira),
        //        Nome = cadastroCupomVM.NomeEmpresaParceira

        //    };

        //    if (!string.IsNullOrEmpty(cadastroCupomVM.DataValidade))
        //        cupom.DataValidade = Convert.ToDateTime(cadastroCupomVM.DataValidade);

        //    await _meusCuponsRepository.InsertOrUpdateAsync(cupom);

        //    return cupom._id.ToString();
        //}
    }
}
