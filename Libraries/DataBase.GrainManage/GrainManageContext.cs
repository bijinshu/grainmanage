﻿using GrainManage.Core;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;
using System;
using DataBase.GrainManage.Models.Mapping;
using DataBase.GrainManage.Models.Log;

namespace DataBase.GrainManage
{
    public class GrainManageContext : BaseUnitOfWork
    {
        static GrainManageContext()
        {
            //Database.SetInitializer<GrainManageContext>(null);
        }
        public GrainManageContext()
            : base("DefaultConnection")
        {
        }

        protected override void AddConfiguations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionLogMapper());
            modelBuilder.ApplyConfiguration(new ContactMapper());
            modelBuilder.ApplyConfiguration(new ExceptionLogMapper());
            modelBuilder.ApplyConfiguration(new ImageMapper());
            modelBuilder.ApplyConfiguration(new JobLogMapper());
            modelBuilder.ApplyConfiguration(new LoginLogMapper());
            modelBuilder.ApplyConfiguration(new PriceMapper());
            modelBuilder.ApplyConfiguration(new RoleMapper());
            modelBuilder.ApplyConfiguration(new TradeMapper());
            modelBuilder.ApplyConfiguration(new UserMapper());
        }
    }
}
