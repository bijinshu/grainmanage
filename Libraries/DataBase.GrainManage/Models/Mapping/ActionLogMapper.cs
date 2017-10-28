using DataBase.GrainManage.Models.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ActionLogMapper : IEntityTypeConfiguration<ActionLog>
    {

        public void Configure(EntityTypeBuilder<ActionLog> builder)
        {
            builder.ToTable("log_action");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.Path).IsRequired();
        }
    }
}
