using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pagamento.App.ViewModels
{
    public class TransacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome do Cliente")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tipo de pagamento")]
        public string Type { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Parcelas")]
        public int Installments { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número do cartão")]
        [StringLength(16, ErrorMessage = "O campo {0} precisa ter {2} ou {1}", MinimumLength = 13)]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Validade")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Bandeira")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CVV")]
        [StringLength(3, ErrorMessage ="O Campo {0} precisa ter {1}", MinimumLength = 3 )]
        public string Cvv { get; set; }


        public Guid PaymentId { get; set; }
                
        [DisplayName("Código de retorno")]
        public string ReturnCode { get; set; }
        public decimal ServiceTaxAmount { get; set; }

    }
}
