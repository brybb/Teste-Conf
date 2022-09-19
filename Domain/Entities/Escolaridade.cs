using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Entities
{
    public class Escolaridade : BaseEntidade
    {
        public string Descricao { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
    }
}
