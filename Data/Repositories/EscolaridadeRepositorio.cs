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
    public class EscolaridadeRepositorio : Repository<Escolaridade, int>, IEscolaridadeRepositorio
    {
        private readonly Context _context;

        public EscolaridadeRepositorio(Context dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IList<Escolaridade>> Listar()
        {
            var query = _context.Set<Escolaridade>().Where(x => x.Ativo);
            return await query.ToListAsync();
        }
    }
}
