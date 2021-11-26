using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamento.Business.Models;

namespace Pagamento.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
               .IsRequired()
               .HasColumnType("varchar(100)");
            
        }
    }
}
