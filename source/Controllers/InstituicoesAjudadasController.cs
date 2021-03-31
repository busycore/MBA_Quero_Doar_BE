using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using source.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstituicoesAjudadasController : ControllerBase
    {
        private readonly InstituicoesAjudadasService _instituicoesAjudadasService;

        public InstituicoesAjudadasController(InstituicoesAjudadasService instituicoesAjudadasService)
        {
            _instituicoesAjudadasService = instituicoesAjudadasService;
        }
    }
}