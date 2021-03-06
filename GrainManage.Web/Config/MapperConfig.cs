﻿using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Company;
using GrainManage.Web.Models.Contact;
using GrainManage.Web.Models.MetaData;
using GrainManage.Web.Models.Order;
using GrainManage.Web.Models.Product;
using GrainManage.Web.Models.Role;
using GrainManage.Web.Models.Trade;
using GrainManage.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainManage.Web
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RoleDto, Role>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).
                ForMember(d => d.Auths, s => s.MapFrom(p => p.Auths == null || !p.Auths.Any() ? string.Empty : string.Join(",", p.Auths))).ReverseMap().
                ForMember(d => d.Auths, s => s.MapFrom(p => string.IsNullOrEmpty(p.Auths) ? new string[0] : p.Auths.Split(',', StringSplitOptions.None)));

                cfg.CreateMap<UserDto, User>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).
                ForMember(d => d.Roles, s => s.MapFrom(p => p.Roles == null || !p.Roles.Any() ? string.Empty : string.Join(",", p.Roles))).ReverseMap().
                ForMember(d => d.Roles, s => s.MapFrom(p => string.IsNullOrEmpty(p.Roles) ? new List<int>(0) : p.Roles.Split(',', StringSplitOptions.None).Select(i => int.Parse(i)).ToList()));

                cfg.CreateMap<ContactDto, Contact>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();

                cfg.CreateMap<MetaDataDto, MetaData>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();

                cfg.CreateMap<TradeDto, Trade>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
                cfg.CreateMap<TradeDetailDto, TradeDetail>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
                cfg.CreateMap<ProductDto, Product>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
                cfg.CreateMap<CompanyDto, Company>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
                cfg.CreateMap<OrderDto, Order>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
                cfg.CreateMap<OrderDetailDto, OrderDetail>().ForMember(d => d.CreatedAt, s => s.AddTransform((f) => DateTime.Now)).ReverseMap();
            });
        }
    }
}