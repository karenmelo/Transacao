namespace Pagamento.Business.Models
{
    public class CreditCard : Entity
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }

        public string Usage { get; set; }
        public string Reason { get; set; }
    }   
}
