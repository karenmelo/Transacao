using FluentValidation;
using Pagamento.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Business.Validation
{
    public class TransacaoValidation : AbstractValidator<Transacao>
    {
        public TransacaoValidation()
        {
            RuleFor(m => m.CardNumber)
                .NotEmpty().WithMessage("O número do cartão é obrigatório")
                .NotNull().WithMessage("O número do cartão é obrigatório")
                .When(m => m.CardNumber.ElementAt(0) == 4)
                .When(m => m.Brand == "visa")
                .Length(13,16);

            RuleFor(m => m.CardNumber)
                .NotEmpty().WithMessage("O número do cartão é obrigatório")
                .NotNull().WithMessage("O número do cartão é obrigatório")
                .When(m => m.CardNumber.ElementAt(0) == 5)
                .When(m => m.Brand == "mastercard" && m.CardNumber.Length == 16)
                .Equals(16);

            RuleFor(m => m.Cvc).NotEmpty().NotNull().LessThanOrEqualTo(3);


        }
    }
}
