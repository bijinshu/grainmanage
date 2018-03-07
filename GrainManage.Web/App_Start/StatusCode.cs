
using GrainManage.Message;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace GrainManage.Web
{
    public sealed class StatusCode
    {
        //Common
        [Message("失败")]
        public readonly int Failed = 0;
        [Message("成功")]
        public readonly int Success = 1;
        [Message("认证失败")]
        public readonly int IdentityFailed = 2;
        [Message("不允许Get方式访问")]
        public readonly int GetNotAllowed = 3;
        [Message("无数据")]
        public readonly int NoData = 9;
        [Message("插入失败.")]
        public readonly int InsertFailed = 26;
        [Message("更新失败.")]
        public readonly int UpdateFailed = 27;
        [Message("删除失败.")]
        public readonly int DeleteFailed = 28;
        [Message("该文件不存在.")]
        public readonly int FileNotExist = 29;
        [Message("该文件已存在.")]
        public readonly int FileHasExist = 30;

        //Role
        [Message("该角色已存在")]
        public readonly int RoleExisted = 401;
        [Message("不允许添加超过自己级别的角色")]
        public readonly int AddRoleLevelNotEnough = 402;
        [Message("不允许设置超过自己级别的角色")]
        public readonly int EditRoleLevelNotEnough = 403;
        [Message("不允许删除超过自己级别的角色")]
        public readonly int DelRoleLevelNotEnough = 404;

        //User
        [Message("用户名不能为空")]
        public readonly int NameEmpty = 502;
        [Message("用户名只能为手机号码或由2-20个英文字母、下划线及数字组成")]
        public readonly int NameNotValid = 502;
        [Message("密码不能为空!")]
        public readonly int PwdEmpty = 503;
        [Message("无效密码")]
        public readonly int PwdNotValid = 503;
        [Message("用户名不存在.")]
        public readonly int NameNotExist = 504;
        [Message("原始密码错误.")]
        public readonly int OldPwdNotMatch = 505;
        [Message("登录失败,用户名或密码错误.")]
        public readonly int NamePwdNotMatch = 506;
        [Message("登录失败,该账户被禁用.")]
        public readonly int UserForbidden = 507;
        [Message("登录失败,该账户尚未激活.")]
        public readonly int UserNotActivated = 508;
        [Message("该用户名已存在.")]
        public readonly int NameExist = 510;
        [Message("对不起,您没有权限进行此操作,请先登录.")]
        public readonly int NotLogin = 511;
        [Message("IP地址发生变化,请重新登录.")]
        public readonly int IPChanged = 512;
        [Message("邮箱不能为空.")]
        public readonly int EmailEmpty = 513;
        [Message("与初始邮箱地址不匹配.")]
        public readonly int EmailNotMatch = 514;
        [Message("邮箱格式不正确")]
        public readonly int EmailFormatNotMatch = 515;
        [Message("该用户不存在")]
        public readonly int UserNotExist = 518;

        //Contact
        [Message("该联系人已存在")]
        public readonly int ContactExisted = 201;

        //Company
        [Message("店铺名称不能为空")]
        public readonly int CompanyNameEmpty = 601;
        [Message("该店铺名称已存在")]
        public readonly int CompanyNameExisted = 602;
        [Message("该店铺不存在")]
        public readonly int CompanyNotExisted = 603;

        //Employee
        [Message("非店铺管理员不可添加店员")]
        public readonly int NotShopAdmin = 701;
        [Message("请先完善店铺信息")]
        public readonly int NotPerfectShopInfo = 702;

        //Product
        [Message("改产品不存在")]
        public readonly int ProductNotExisted = 801;
        [Message("产品名称不能为空")]
        public readonly int ProductNameEmpty = 802;
        [Message("产品已存在")]
        public readonly int ProductNameExisted = 803;

        //Price
        [Message("产品价格已存在")]
        public readonly int PriceExisted = 902;
        [Message("请先选择产品")]
        public readonly int ProductNotSelected = 903;
    }
}