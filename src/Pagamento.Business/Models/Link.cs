using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Business.Models
{
    public class Link : Entity
    {
        public Guid PaymentId { get; set; }
        public string Method { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }

        public Payment Payment { get; set; }
    }
}
