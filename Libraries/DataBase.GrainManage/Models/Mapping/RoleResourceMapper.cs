using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class RoleResourceMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.RoleResource>
    {
        public RoleResourceMapper()
        {
            ToTable("rm_role_resource");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(m => m.Role).WithMany().HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false);
            HasRequired(m => m.Resource).WithMany().HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(false);
        }
    }
}
