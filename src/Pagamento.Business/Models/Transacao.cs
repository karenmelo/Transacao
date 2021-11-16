using System;

namespace Pagamento.Business.Models
{
    public class Transacao : Entity
    {               
        public string Type { get; set; }
        public int Amount { get; set; }        
        public int Installments { get; set; }        
        public string CardNumber { get; set; }        
        public DateTime ExpirationDate { get; set; }        
        public string Brand { get; set; }
        public int Cvc { get; set; }
    }
}
