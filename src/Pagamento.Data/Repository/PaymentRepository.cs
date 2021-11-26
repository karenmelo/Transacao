using Pagamento.Business.Interface;
using Pagamento.Business.Models;
using Pagamento.Data.Context;
using System;
using System.Threading.Tasks;

namespace Pagamento.Data.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MeuDbContext context) : base(context) { }
                       
        public async Task<Payment> ObterPagamento(Guid id)
        {
            return await _context.Payments.FindAsync(id);
        }
    }
}
