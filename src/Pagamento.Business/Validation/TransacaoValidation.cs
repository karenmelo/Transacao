using FluentValidation;
using Pagamento.Business.Models;
using System.Linq;

namespace Pagamento.Business.Validation
{
    public class TransacaoValidation : AbstractValidator<Transaction>
    {
        public TransacaoValidation()
        {
            RuleFor(m => m.Payment.CreditCard.CardNumber)
                .NotEmpty().WithMessage("O número do cartão é obrigatório")
                .NotNull().WithMessage("O número do cartão é obrigatório")
                .When(m => m.Payment.CreditCard.CardNumber.ElementAt(0) == 4)
                .When(m => m.Payment.CreditCard.Brand == "visa")
                .Length(13,16);

            RuleFor(m => m.Payment.CreditCard.CardNumber)
                .NotEmpty().WithMessage("O número do cartão é obrigatório")
                .NotNull().WithMessage("O número do cartão é obrigatório")
                .When(m => m.Payment.CreditCard.CardNumber.ElementAt(0) == 5)
                .When(m => m.Payment.CreditCard.Brand == "mastercard" && m.Payment.CreditCard.CardNumber.Length == 16)
                .Equals(16);

            RuleFor(m => m.Payment.CreditCard.SecurityCode).NotEmpty().NotNull().Length(3);
        }
    }
}
