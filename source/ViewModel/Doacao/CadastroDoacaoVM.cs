using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.ViewModel.Doacao
{
    public class CadastroDoacaoVM
    {
        public string IdDoador { get; set; }
        public string IdInstituicao { get; set; }
        public string IdPagamento { get; set; }
        public decimal Valor { get; set; }
    }
}