using System;

namespace Pagamento.Business.Models
{
    public class Transaction : Entity
    {   
        public string MerchantOrderId { get; set; }

        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }        
    }
}
