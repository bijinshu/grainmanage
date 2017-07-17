using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class UserRoleMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.UserRole>
    {
        public UserRoleMapper()
        {
            ToTable("rm_user_roles");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(m => m.Account).WithMany().HasForeignKey(c => c.UserName);
            HasRequired(m => m.Role).WithMany().HasForeignKey(c => c.RoleId);
        }
    }
}
