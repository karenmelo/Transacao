using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamento.Business.Models;

namespace Pagamento.Data.Mapping
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            // 1 pagamento pode ter N transações
            builder.HasOne(t => t.Payment)
                   .WithMany(p => p.Transactions)
                   .HasForeignKey(c => c.PaymentId);

         
            builder.ToTable("Transactions");
        }
    }
}
