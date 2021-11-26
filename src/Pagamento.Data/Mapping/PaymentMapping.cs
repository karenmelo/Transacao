using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamento.Business.Integracao;
using Pagamento.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Data.Mapping
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.PaymentId)                  
                   .IsRequired();

            builder.Ignore(p => p.Id);

            builder.Ignore(p => p.CreditCard);
           

            builder.ToTable("Payments");
        }
    }
}
