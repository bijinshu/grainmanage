using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.Mapping
{
    public class OrderMapper : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("bm_order");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.Mobile).IsRequired();
            builder.Property(m => m.Address).IsRequired();
        }
    }
}
