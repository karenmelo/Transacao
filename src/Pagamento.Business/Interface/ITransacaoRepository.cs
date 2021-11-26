using Pagamento.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagamento.Business.Interface
{
    public interface ITransacaoRepository : IRepository<Transaction> 
    {
        Task<IEnumerable<Transaction>> ObterTodasTransacoes();
        Task<Transaction> ObterTransacao(Guid id);    
    }
}
