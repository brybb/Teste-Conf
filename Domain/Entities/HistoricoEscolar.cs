using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Entities
{
    public class HistoricoEscolar : BaseEntidade
    {
        public string Arquivo { get; set; }

        public string Nome { get; set; }


        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

    }
}
