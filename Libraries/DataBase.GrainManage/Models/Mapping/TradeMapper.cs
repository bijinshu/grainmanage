﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.GrainManage.Models.Mapping
{
    public class TradeMapper : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("bm_trade");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id);
            builder.HasOne(m => m.Contact).WithMany().HasForeignKey(c => c.ContactId).OnDelete(DeleteBehavior.SetNull);
            builder.Property(m => m.Grain).HasMaxLength(40);
            builder.Property(m => m.Price);
            builder.Property(m => m.Weight);
            builder.Property(m => m.ActualMoney);
            builder.Property(m => m.Remark).HasMaxLength(600);
            builder.HasOne(m => m.Owner).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.SetNull);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
        }
    }
}
