using Pagamento.Business.Models;
using System;
using System.Threading.Tasks;

namespace Pagamento.Business.Interface
{
    public interface ITransacaoRepository : IRepository<Transacao> 
    {
        Task<Transacao> ObterTransacao(Guid id);
    }
}
