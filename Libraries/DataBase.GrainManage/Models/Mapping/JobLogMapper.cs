using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class JobLogMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Log.JobLog>
    {
        public JobLogMapper()
        {
            ToTable("log_job");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.JobName).IsRequired();
            Property(m => m.Remark).IsRequired();
        }
    }
}
