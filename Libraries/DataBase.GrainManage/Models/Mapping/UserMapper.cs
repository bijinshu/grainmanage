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
            ToTable("rm_user");
            HasKey(m => m.Guid);
            Property(m => m.UserName).HasMaxLength(20).IsRequired();
            Property(m => m.Pwd).HasMaxLength(64).IsRequired();
            Property(m => m.NickName).HasMaxLength(40).IsRequired();
            Property(m => m.CellPhone).HasMaxLength(11).IsRequired();
            Property(m => m.Email).HasMaxLength(64).IsRequired();
            Property(m => m.Weixin).HasMaxLength(60).IsRequired();
            Property(m => m.QQ).HasMaxLength(20).IsRequired();
            Property(m => m.Remark).HasMaxLength(200).IsRequired();
            Property(m => m.Created);
            Property(m => m.LastActive);
            Property(m => m.Roles).IsRequired();
        }
    }
}
