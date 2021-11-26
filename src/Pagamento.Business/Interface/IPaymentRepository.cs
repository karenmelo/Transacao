using Pagamento.Business.Models;
using System;
using System.Threading.Tasks;

namespace Pagamento.Business.Interface
{
    public interface IPaymentRepository : IRepository<Payment> 
    {      
        Task<Payment> ObterPagamento(Guid id);
    }
}
