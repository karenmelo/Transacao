using Pagamento.Business.Interface;
using Pagamento.Business.Models;
using Pagamento.Data.Context;
using System;
using System.Threading.Tasks;

namespace Pagamento.Data.Repository
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<Transacao> ObterTransacao(Guid id)
        {
            return null;//await _context.Transacoes.FindAsync(id);
        }
    }
}
