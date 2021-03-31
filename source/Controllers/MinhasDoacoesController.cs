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
    public class MinhasDoacoesController : ControllerBase
    {
        private readonly MinhasDoacoesService _minhasDoacoesService;

        public MinhasDoacoesController(MinhasDoacoesService minhasDoacoesService)
        {
            _minhasDoacoesService = minhasDoacoesService;
        }
    }
}