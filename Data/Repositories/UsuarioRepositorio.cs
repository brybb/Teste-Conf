using Confitec.Application.Interfaces;
using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Data.Repositories
{
    public class UsuarioRepositorio : Repository<Usuario, int>, IUsuarioRepositorio
    {
        private readonly Context _context;

        public UsuarioRepositorio(Context dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task Atualizar(Usuario usuario)
        {
            var usuarioDB = await _context.Set<Usuario>().SingleOrDefaultAsync(x => x.Id == usuario.Id);

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Sobrenome = usuario.Sobrenome;
            usuarioDB.EscolaridadeId = usuario.EscolaridadeId;
            usuarioDB.DataNascimento = usuario.DataNascimento;

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var usuarioDB = await _context.Set<Usuario>().SingleOrDefaultAsync(x => x.Id == id);
            _context.Entry<Usuario>(usuarioDB).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Usuario>> Listar()
        {
            var query = _context.Set<Usuario>().Include(x => x.Escolaridade).Where(x => x.Ativo).OrderBy(x => x.Nome);
            return await query.ToListAsync();
        }

        public async Task<Usuario> Obter(int id)
        {
            return await _context.Set<Usuario>().Include(x => x.Escolaridade).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Salvar(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            return await _context.SaveChangesAsync();
        }
    }
}
