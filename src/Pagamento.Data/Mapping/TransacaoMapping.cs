using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamento.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Data.Mapping
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Type)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(f => f.CardNumber)
                .IsRequired()
                .HasColumnType("varchar(19)");

            builder.Property(f => f.Brand)
               .IsRequired()
               .HasColumnType("varchar(10)");

            builder.Property(f => f.ExpirationDate)
               .IsRequired()
               .HasColumnType("date");

            builder.Property(f => f.Type)
               .IsRequired()
               .HasColumnType("varchar(100)");

        }
    }
}
