using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Entities
{
    public class Usuario : BaseEntidade
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }
        public int EscolaridadeId { get; set; }

        public Escolaridade Escolaridade { get; set; }

        public virtual IList<HistoricoEscolar> HistoricoEscolar { get; set; }
    }
}
