using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ImageMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Image>
    {
        public ImageMapper()
        {
            ToTable("bm_image");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.ImageName).HasMaxLength(64);
            Property(m => m.Guid).HasMaxLength(36);
            Property(m => m.Remark).HasMaxLength(200);
            Property(m => m.Created);
            Property(m => m.Modified);
            HasRequired(m => m.Owner).WithMany().HasForeignKey(c => c.Creator).WillCascadeOnDelete();

        }
    }
}
