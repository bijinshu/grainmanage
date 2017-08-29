using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class PriceMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Price>
    {
        public PriceMapper()
        {
            ToTable("bm_price");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Grain).HasMaxLength(40);
            Property(m => m.UnitPrice);
            Property(m => m.PriceType).HasMaxLength(20);
            Property(m => m.Remark).HasMaxLength(200);
            Property(m => m.CreatedAt);
            Property(m => m.ModifiedAt);
            HasRequired(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).WillCascadeOnDelete(false);
        }
    }
}
