using Confitec.Application.Interfaces;
using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Data.Repositories
{
    public class HistoricoEscolarRepositorio : Repository<HistoricoEscolar, int>, IHistoricoEscolarRepositorio
    {
        private readonly Context _context;

        public HistoricoEscolarRepositorio(Context dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<int> Salvar(HistoricoEscolar Historico)
        {
           await _context.Set<HistoricoEscolar>().AddAsync(Historico);
           return await _context.SaveChangesAsync();
        }
    }
}
