using System;
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
        [DisplayName("Número de parcelas")]
        public int Installments { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número do cartão")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Validade")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Bandeira")]
        public string Brand { get; set; }
    }
}
