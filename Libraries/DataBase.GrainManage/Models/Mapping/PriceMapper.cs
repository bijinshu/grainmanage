using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class PriceMapper : IEntityTypeConfiguration<PriceInfo>
    {
        public void Configure(EntityTypeBuilder<PriceInfo> builder)
        {
            builder.ToTable("bm_price");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ProductId);
            builder.Property(m => m.PriceType);
            builder.Property(m => m.Remark).HasMaxLength(200);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
            builder.HasOne(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
