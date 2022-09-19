using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Interfaces
{
    public interface IUsuarioRepositorio 
    {
        Task<int> Salvar(Usuario usuario);
        Task<IList<Usuario>> Listar();
        Task<Usuario> Obter(int id);
        Task Atualizar(Usuario usuario);

        Task Deletar(int id);
    }
}
