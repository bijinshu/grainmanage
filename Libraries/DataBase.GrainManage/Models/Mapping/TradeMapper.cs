using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class TradeMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.Trade>
    {
        public TradeMapper()
        {
            ToTable("bm_trade");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(m => m.Contact).WithMany().HasForeignKey(c => c.ContactId).WillCascadeOnDelete(false);
            Property(m => m.Grain).HasMaxLength(40);
            Property(m => m.Price);
            Property(m => m.Weight);
            Property(m => m.ActualMoney);
            Property(m => m.Remark).HasMaxLength(600);
            HasRequired(m => m.Owner).WithMany().HasForeignKey(c => c.Creator).WillCascadeOnDelete(false);
            Property(m => m.Created);
            Property(m => m.Modified);
        }
    }
}
