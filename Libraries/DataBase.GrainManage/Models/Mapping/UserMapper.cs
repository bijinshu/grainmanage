using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("rm_user");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.UserName).HasMaxLength(20).IsRequired();
            builder.Property(m => m.Pwd).HasMaxLength(64).IsRequired();
            builder.Property(m => m.RealName).HasMaxLength(40).IsRequired();
            builder.Property(m => m.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(64).IsRequired();
            builder.Property(m => m.Weixin).HasMaxLength(60).IsRequired();
            builder.Property(m => m.QQ).HasMaxLength(20).IsRequired();
            builder.Property(m => m.Remark).HasMaxLength(200).IsRequired();
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
            builder.Property(m => m.Roles).IsRequired();
        }
    }
}
