using System;

namespace Pagamento.Business.Integracao.Model.Request
{
    public class TransactionPutRequest
    {
        public string PaymentId { get; set; }
        public decimal Amount { get; set; }
        public decimal ServiceTaxAmount { get; set; }
    }
}
