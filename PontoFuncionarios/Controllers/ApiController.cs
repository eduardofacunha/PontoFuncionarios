using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PontoFuncionarios.Context;
using PontoFuncionarios.Cores;
using PontoFuncionarios.Exceptions;
using PontoFuncionarios.Models;

namespace PontoFuncionarios.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class ApiController : ControllerBase
    {
        public BancoContext Bd { get; set; }
        public ApiController(BancoContext bd)
        {
            Bd = bd;
        }

        [HttpPut]
        public ActionResult CriarPonto([FromBody] Ponto ponto)
        {
            try
            {
                CorePonto.CriarPonto(Bd, ponto);
                return new JsonResult(true);
            }
            catch(ParameterException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult PegarUltimosPontos()
        {
            try
            {
                var pontos = CorePonto.PegarUltimosPontos(Bd);
                return new JsonResult(pontos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
