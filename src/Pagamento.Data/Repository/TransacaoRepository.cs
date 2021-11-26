using Microsoft.EntityFrameworkCore;
using Pagamento.Business.Interface;
using Pagamento.Business.Models;
using Pagamento.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagamento.Data.Repository
{
    public class TransacaoRepository : Repository<Transaction>, ITransacaoRepository
    {
        public TransacaoRepository(MeuDbContext context) : base(context) { }



        public async Task<Transaction> ObterTransacao(Guid id)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Include(c => c.Customer)
                .Include(p => p.Payment)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transaction>> ObterTodasTransacoes()
        {
            return await _context.Transactions
                .AsNoTracking()
                .Include(c => c.Customer)
                .Include(p => p.Payment)
                .ToListAsync();
        }
    }
}
