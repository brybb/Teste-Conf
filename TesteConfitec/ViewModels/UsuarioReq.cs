using Confitec.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Api.ViewModels
{
    public class UsuarioReq
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        
        [Required(ErrorMessage = "Campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione a escolaridade")]
        public string EscolaridadeId { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public IFormFile Filearq { get; set; }

        public int HistoricoEscolarId { get; set; }

        public Usuario ConvertDb()
        {
            return new Usuario
            {
                Id = this.Id,
                Nome = this.Nome,
                Sobrenome = this.Sobrenome,
                Email = this.Email,
                EscolaridadeId = Convert.ToInt32(this.EscolaridadeId),
                DataNascimento = this.DataNascimento,
                DataCadastro = DateTime.Now,
                Ativo = true
            };
       }
    }
}
