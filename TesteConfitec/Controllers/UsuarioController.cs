using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Api.ViewModels;
using Confitec.Application.Interfaces;
using Confitec.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;
        readonly IHistoricoEscolarRepositorio _historicoEscolarRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IHistoricoEscolarRepositorio historicoEscolarRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _historicoEscolarRepositorio = historicoEscolarRepositorio;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            try
            {
                var usuario = await _usuarioRepositorio.Obter(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro");
            }
        }



        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var usuarios = await _usuarioRepositorio.Listar();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao carregar as escolaridades");
            }
        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] UsuarioReq usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadHistorico");

                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }


                var fileExt = System.IO.Path.GetExtension(usuario.Filearq.FileName).Substring(1).ToLower();

                if (fileExt != "pdf" && fileExt != "doc")
                {
                    return BadRequest("Extensão de arquivo não suportada");
                }


                //Salvar arquivo de historico
                string namefull = Guid.NewGuid().ToString() + usuario.Filearq.FileName;

                string filePath = Path.Combine(path, namefull);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await usuario.Filearq.CopyToAsync(fileStream);
                }

                int usuarioId = await _usuarioRepositorio.Salvar(usuario.ConvertDb());


                HistoricoEscolar historico = new HistoricoEscolar()
                {
                    Arquivo = namefull,
                    UsuarioId = usuarioId,
                    Nome = usuario.Filearq.FileName
                };

                await _historicoEscolarRepositorio.Salvar(historico);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar o usuário");
            }
        }

        /// <summary>
        /// Atualizar usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioReq usuario)
        {
            try
            {
                usuario.Id = id;
                await _usuarioRepositorio.Atualizar(usuario.ConvertDb());

                return Ok("Usuário atualizado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _usuarioRepositorio.Deletar(id);
                return Ok("Usuário deletado");
            }
            catch (Exception ex)
            {
                var e = ex;
                return StatusCode(500, "Ocorreu um erro");
            }
        }
    }
}
