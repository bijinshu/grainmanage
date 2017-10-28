using DataBase.GrainManage.Models.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class LoginLogMapper : IEntityTypeConfiguration<LoginLog>
    {
        public void Configure(EntityTypeBuilder<LoginLog> builder)
        {
            builder.ToTable("log_login");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.UserName).HasMaxLength(20);
            builder.Property(m => m.LoginIP).HasMaxLength(64);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.Status);
        }
    }
}
