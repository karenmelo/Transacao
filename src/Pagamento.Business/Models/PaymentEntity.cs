using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Business.Models
{
    public partial class Payment
    {
        public void Update(Payment payment)
        {
            Status = payment.Status;
            Tid = payment.Tid;
            ProofOfSale = payment.ProofOfSale;
            AuthorizationCode = payment.AuthorizationCode;
            ReturnCode = payment.ReturnCode;
            ReturnMessage = payment.ReturnMessage;
        }

    }
}
