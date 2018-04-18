using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class TradeDetailMapper : IEntityTypeConfiguration<TradeDetail>
    {
        public void Configure(EntityTypeBuilder<TradeDetail> builder)
        {
            builder.ToTable("bm_trade_detail");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ProductName).IsRequired();
            builder.Property(m => m.Price);
            builder.Property(m => m.RoughWeight);
            builder.Property(m => m.Tare);
            builder.Property(m => m.Remark).IsRequired();
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
        }
    }
}
