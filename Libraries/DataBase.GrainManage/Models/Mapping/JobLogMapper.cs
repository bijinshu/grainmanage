using DataBase.GrainManage.Models.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class JobLogMapper : IEntityTypeConfiguration<JobLog>
    {
        public void Configure(EntityTypeBuilder<JobLog> builder)
        {
            builder.ToTable("log_job");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.JobName).IsRequired();
            builder.Property(m => m.Remark).IsRequired();
        }
    }
}
