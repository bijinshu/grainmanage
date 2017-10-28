using DataBase.GrainManage.Models.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class ExceptionLogMapper : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder. ToTable("log_exception");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.Path).IsRequired();
            builder.Property(m => m.Message).IsRequired();
        }
    }
}
