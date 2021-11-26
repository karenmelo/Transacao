using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamento.Business.Models;

namespace Pagamento.Data.Mapping
{
    public class TLinkMapping : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.HasKey(t => t.Id);

            // 1 pagamento pode ter N links
            builder.HasOne(t => t.Payment)
                   .WithMany(p => p.Links)
                   .HasForeignKey(c => c.PaymentId);

         
            builder.ToTable("Links");
        }
    }
}
