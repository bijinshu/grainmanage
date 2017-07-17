using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.ChinaMap.Models.Mapping
{
    public class DistrictMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<District>
    {
        public DistrictMapper()
        {
            ToTable("sys_district");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(m => m.Name).HasMaxLength(50);
            Property(m => m.Level);
            Property(m => m.UpID);
            HasRequired(c => c.Owner).WithMany(m => m.Children).HasForeignKey(f => f.UpID);
        }
    }
}
