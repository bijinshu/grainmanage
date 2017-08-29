using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ContactMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Contact>
    {
        public ContactMapper()
        {
            ToTable("bm_contact");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.ContactName).HasMaxLength(40);
            Property(m => m.Gender).HasMaxLength(1);
            Property(m => m.BirthDate);
            Property(m => m.CellPhone).HasMaxLength(11);
            Property(m => m.QQ).HasMaxLength(20);
            Property(m => m.Weixin).HasMaxLength(60);
            Property(m => m.Email).HasMaxLength(11);
            Property(m => m.Address).HasMaxLength(255);
            Property(m => m.Remark).HasMaxLength(255);
            Property(m => m.CreatedAt);
            Property(m => m.ModifiedAt);
            HasRequired(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).WillCascadeOnDelete(false);
        }
    }
}
