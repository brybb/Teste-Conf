using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [Route("api/escolaridade")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        readonly IEscolaridadeRepositorio _escolaridadeRepositorio;

        public EscolaridadeController(IEscolaridadeRepositorio escolaridadeRepositorio)
        {
            _escolaridadeRepositorio = escolaridadeRepositorio;
        }


        /// <summary>
        /// Listar as Escolaridades para o Front
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var escolaridades = await _escolaridadeRepositorio.Listar();
                return Ok(escolaridades);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao carregar as escolaridades");
            }
        }
    }
}
