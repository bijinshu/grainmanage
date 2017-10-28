using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ImageMapper : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("bm_image");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ImageName).HasMaxLength(64);
            builder.Property(m => m.Guid).HasMaxLength(36);
            builder.Property(m => m.Remark).HasMaxLength(200);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
            builder.HasOne(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
