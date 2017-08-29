using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ActionLogMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Log.ActionLog>
    {
        public ActionLogMapper()
        {
            ToTable("log_action");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Path).IsRequired();
        }
    }
}
