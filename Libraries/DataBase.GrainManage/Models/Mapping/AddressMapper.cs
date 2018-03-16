using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.Mapping
{
    public class AddressMapper : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("rm_address");
            builder.HasKey(m => m.Path);
            builder.Property(p => p.Path).IsRequired();
            builder.Property(p => p.Remark).IsRequired();
        }
    }
}
