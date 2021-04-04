using Microsoft.AspNetCore.Mvc;
using source.Service;
using source.ViewModel.MinhaConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeusCuponsController : ControllerBase
    {
        private readonly MeusCuponsService _meusCuponsService;

        public MeusCuponsController(MeusCuponsService meusCuponsService)
        {
            _meusCuponsService = meusCuponsService;
        }

        /// <summary>
        /// Rrea df
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<DadosMeusCuponsVM>> Get()
        {
            return Ok();
            //if (1 == 1)
            //    return Ok();
            //return NotFound();
        }


        [HttpGet("{alho}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<DadosMeusCuponsVM>> Get2(string alho)
        {
            return Ok();
            //if (1 == 1)
            //    return Ok();
            //return NotFound();
        }

        
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<DadosMeusCuponsVM>> Get3(int id)
        {
            return Ok();
            //if (1 == 1)
            //    return Ok();
            //return NotFound();
        }
    }
}
