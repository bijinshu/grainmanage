using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class UserMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.User>
    {
        public UserMapper()
        {
            ToTable("rm_users");
            HasKey(m => m.UserName);
            Property(m => m.UserName).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasMaxLength(20).IsRequired();
            Property(m => m.Pwd).HasMaxLength(64);
            Property(m => m.RealName).HasMaxLength(40);
            Property(m => m.CellPhone).HasMaxLength(11);
            Property(m => m.Email).HasMaxLength(64);
            Property(m => m.Guid).HasMaxLength(36);
            Property(m => m.EncryptKey).HasMaxLength(8);
            Property(m => m.ResetCount);
            Property(m => m.Remark).HasMaxLength(200);
            Property(m => m.Created);
            Property(m => m.LastActive);
        }
    }
}
