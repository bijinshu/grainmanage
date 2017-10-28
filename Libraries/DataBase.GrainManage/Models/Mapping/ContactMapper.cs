using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ContactMapper : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("bm_contact");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ContactName).HasMaxLength(40);
            builder.Property(m => m.Gender).HasMaxLength(1);
            builder.Property(m => m.BirthDate);
            builder.Property(m => m.Mobile).HasMaxLength(11);
            builder.Property(m => m.QQ).HasMaxLength(20);
            builder.Property(m => m.Weixin).HasMaxLength(60);
            builder.Property(m => m.Email).HasMaxLength(11);
            builder.Property(m => m.Address).HasMaxLength(255);
            builder.Property(m => m.Remark).HasMaxLength(255);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
            builder.HasOne(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
