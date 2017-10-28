using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class PriceMapper : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("bm_price");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.Grain).HasMaxLength(40);
            builder.Property(m => m.UnitPrice);
            builder.Property(m => m.PriceType).HasMaxLength(20);
            builder.Property(m => m.Remark).HasMaxLength(200);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
            builder.HasOne(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
