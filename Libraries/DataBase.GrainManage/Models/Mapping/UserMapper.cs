﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Mapping
{
    public class UserMapper : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DataBase.GrainManage.Models.User>
    {
        public UserMapper()
        {
            ToTable("rm_user");
            HasKey(m => m.Id);
            Property(m => m.UserName).HasMaxLength(20).IsRequired();
            Property(m => m.Pwd).HasMaxLength(64).IsRequired();
            Property(m => m.RealName).HasMaxLength(40).IsRequired();
            Property(m => m.Mobile).HasMaxLength(11).IsRequired();
            Property(m => m.Email).HasMaxLength(64).IsRequired();
            Property(m => m.Weixin).HasMaxLength(60).IsRequired();
            Property(m => m.QQ).HasMaxLength(20).IsRequired();
            Property(m => m.Remark).HasMaxLength(200).IsRequired();
            Property(m => m.CreatedAt);
            Property(m => m.ModifiedAt);
            Property(m => m.Roles).IsRequired();
        }
    }
}
