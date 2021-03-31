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
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoService _pagamentoService;

        public PagamentoController(PagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }
    }
}