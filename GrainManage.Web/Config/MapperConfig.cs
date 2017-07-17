using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Account;
using GrainManage.Web.Models.Contact;
using GrainManage.Web.Models.Image;
using GrainManage.Web.Models.MetaData;
using GrainManage.Web.Models.Price;
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
                cfg.CreateMap<UserDto, User>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<ContactDto, Contact>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<ImageDto, Image>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<MetaDataDto, MetaData>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<PriceDto, Price>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

                cfg.CreateMap<TradeDto, Trade>().ForMember(d => d.Created, s => s.UseValue(DateTime.Now)).ReverseMap();

            });
        }
    }
}