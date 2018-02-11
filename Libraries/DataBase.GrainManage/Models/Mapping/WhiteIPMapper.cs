using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.Mapping
{
    public class WhiteIPMapper : IEntityTypeConfiguration<WhiteIP>
    {
        public void Configure(EntityTypeBuilder<WhiteIP> builder)
        {
            builder.ToTable("rm_white_ip");
            builder.HasKey(m => m.Id);
        }
    }
}
