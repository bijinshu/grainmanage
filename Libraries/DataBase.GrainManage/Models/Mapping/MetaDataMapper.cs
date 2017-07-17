using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class MetaDataMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.MetaData>
    {
        public MetaDataMapper()
        {
            ToTable("sys_metadata");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Content).HasMaxLength(60);
            Property(m => m.TypeCode).HasMaxLength(20);
            Property(m => m.Remark).HasMaxLength(60);
        }
    }
}
