using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.Mapping
{
    public class OrderDetailMapper : IEntityTypeConfiguration<OrderDetail>
    {

        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("bm_order_detail");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.Property(m => m.ProductName).IsRequired();
        }
    }
}
