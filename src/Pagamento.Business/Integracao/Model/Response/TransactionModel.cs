using System.Collections.Generic;

namespace Pagamento.Business.Integracao.Model.Response
{
    public class TransactionModel
    {               
        public string MerchantOrderId { get; set; }     
        public CustomerModel Customer { get; set; }
        public PaymentModel Payment { get; set; }
        
    }

    public class PaymentModel
    {
        public decimal ServiceTaxAmount { get; set; }
        public int Installments { get; set; }
        public string Interest { get; set; }
        public bool Capture { get; set; }
        public bool Authenticate { get; set; }
        public bool Recurrent { get; set; }
        public CreditCardModel CreditCard { get; set; }
        public string Tid { get; set; }
        public string ProofOfSale { get; set; }
        public string AuthorizationCode { get; set; }
        public string Provider { get; set; }
        public bool IsQrCode { get; set; }
        public decimal Amount { get; set; }
        public string ReceivedDate { get; set; }
        public int Status { get; set; }
        public bool IsSplitted { get; set; }
        public string ReturnMessage { get; set; }
        public string ReturnCode { get; set; }
        public string PaymentId { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public bool IsCryptoCurrencyNegotiation { get; set; }

        public string ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public string ProviderReturnCode { get; set; }
        public string ProviderReturnMessage { get; set; }

        public List<LinkModel> Links { get; set; }
    }

    public class CreditCardModel
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public bool SaveCard { get; set; }
        public string Brand { get; set; }        
        public CardOnFileModel CardOnFile { get; set; }
    }

    public class CardOnFileModel
    {
        public string Usage { get; set; }
        public string Reason { get; set; }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
    }

    public class LinkModel
    {
        public string Method { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}
