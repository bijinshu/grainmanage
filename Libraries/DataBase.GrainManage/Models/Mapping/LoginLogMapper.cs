using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class LoginLogMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.LoginLog>
    {
        public LoginLogMapper()
        {
            ToTable("log_login");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.UserName).HasMaxLength(20);
            Property(m => m.LoginIP).HasMaxLength(64);
            Property(m => m.Created);
            Property(m => m.Status);
        }
    }
}
