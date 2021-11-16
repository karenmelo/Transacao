﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pagamento.App.ViewModels
{
    public class TransacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

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
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Bandeira")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CVC")]
        [StringLength(3, ErrorMessage ="O Campo {0} precisa ter {1}", MinimumLength = 3 )]
        public string Cvc { get; set; }
    }
}
