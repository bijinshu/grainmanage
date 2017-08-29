using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ExceptionLogMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Log.ExceptionLog>
    {
        public ExceptionLogMapper()
        {
            ToTable("log_exception");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Path).IsRequired();
            Property(m => m.Message).IsRequired();
        }
    }
}
