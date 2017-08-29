using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Account;
using GrainManage.Web.Models.Contact;
using GrainManage.Web.Models.Image;
using GrainManage.Web.Models.MetaData;
using GrainManage.Web.Models.Price;
using GrainManage.Web.Models.Role;
using GrainManage.Web.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GrainManage.Web
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RoleDto, Role>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).
                ForMember(d => d.Auths, s => s.MapFrom(p => p.Auths == null || !p.Auths.Any() ? string.Empty : string.Join(",", p.Auths))).ReverseMap().
                ForMember(d => d.Auths, s => s.MapFrom(p => string.IsNullOrEmpty(p.Auths) ? new string[0] : p.Auths.Split(',')));

                cfg.CreateMap<UserDto, User>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<ContactDto, Contact>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<ImageDto, Image>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<MetaDataDto, MetaData>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<PriceDto, Price>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<TradeDto, Trade>().ForMember(d => d.CreatedAt, s => s.UseValue(DateTime.Now)).ReverseMap();

            });
        }
    }
}