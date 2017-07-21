
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

        //Server
        [Message("无模版数据.")]
        public readonly int NoPatternData = 12;

        [Message("请求超时,请稍后再试.")]
        public readonly int TimeOut = 22;

        [Message("对本地文件进行操作时出错.")]
        public readonly int IOError = 23;

        [Message("发生了未知错误.")]
        public readonly int UnknownError = 24;

        [Message("输入参数无效.")]
        public readonly int InvalidInput = 25;

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

        [Message("部分数据插入失败.")]
        public readonly int BatchInsertFailed = 36;

        [Message("部分数据更新失败.")]
        public readonly int BatchUpdateFailed = 37;

        [Message("部分数据删除失败.")]
        public readonly int BatchDeleteFailed = 38;

        //Account
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

        [Message("登录失败,该账户尚未被激活.")]
        public readonly int UserNotActivated = 508;

        [Message("注册失败,该用户名已存在.")]
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


        [Message("该联系人已存在")]
        public readonly int ContactExisted = 201;
    }
}