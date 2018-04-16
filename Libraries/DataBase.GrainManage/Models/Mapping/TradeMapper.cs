using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class TradeMapper : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("bm_trade");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ContactName).IsRequired();
            builder.Property(m => m.PaidMoney);
            builder.Property(m => m.Remark).IsRequired().HasMaxLength(600);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
        }
    }
}
