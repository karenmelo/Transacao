using System;

namespace Pagamento.Business.Integracao.Model.Request
{
    public class TransacaoPostRequest
    {        
        public string MerchantOrderId { get; set; } 
        public CustomerPostRequest Customer { get; set; }
        public PaymentPostRequest Payment { get; set; }
    }

    public class PaymentPostRequest
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public int Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public CreditCardPostRequest CreditCard { get; set; }
        public bool IsCryptoCurrencyNegotiation { get; set; } = false;
    }

    public class CreditCardPostRequest
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }

        public CardOnFilePostRequest CardOnFile { get; set; }
    }
    public class CardOnFilePostRequest
    {
        public string Usage { get; set; } = "Used";
        public string Reason { get; set; } = "Unscheduled";
    }

    public class CustomerPostRequest
    {
        public string Name { get; set; }
    }
}
