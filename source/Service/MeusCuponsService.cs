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
        private readonly CupomRepository _cupomRepository;
        private readonly EmpresaRepository _empresaRepository;
        private readonly DoadorRepository _doadorRepository;

        public MeusCuponsService(MeusCuponsRepository meusCuponsRepository , CupomRepository cupomRepository , EmpresaRepository empresaRepository , DoadorRepository doadorRepository)
        {
            _meusCuponsRepository = meusCuponsRepository;
            _cupomRepository = cupomRepository;
            _empresaRepository = empresaRepository;
            _doadorRepository = doadorRepository;
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

        public async Task<string> Salvar(CadastroMeusCuponsVM cadastroCupomVM)
        {
            MeusCupons meusCupons = new MeusCupons();

            var cupom = await _cupomRepository.GetDocumentByID(cadastroCupomVM.IdCupom);

            meusCupons.Cupom = await _cupomRepository.GetDocumentByID(cadastroCupomVM.IdCupom);
            meusCupons.EmpresaParceria = await _empresaRepository.GetDocumentByID(meusCupons.Cupom.EmpresaParceria._id.ToString());
            meusCupons.Doador = await _doadorRepository.GetDocumentByID(cadastroCupomVM.IdDoador);

            meusCupons.DataValidade = meusCupons.Cupom.DataValidade;
            meusCupons.DataResgate = DateTime.Now;
            meusCupons.Ativo = true;

            await _meusCuponsRepository.InsertOrUpdateAsync(meusCupons);

            return meusCupons._id.ToString();
        }
    }
}
