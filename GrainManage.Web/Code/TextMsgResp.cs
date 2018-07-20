using GrainManage.Dal;
using GrainManage.Web.Services;
using Senparc.Weixin;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Code
{
    public class TextMsgResp
    {
        private readonly MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>> handler;
        public TextMsgResp(MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>> handler)
        {
            this.handler = handler;
        }
        public string GetSaleShop(RequestMessageBase requestMessage)
        {
            return string.Join('、', CompanyService.GetCompanyNames());
        }
        public string Whoami(RequestMessageBase requestMessage)
        {
            try
            {
                var result = CommonApi.GetUserInfo(Config.SenparcWeixinSetting.WeixinAppId, requestMessage.FromUserName);
                if (result.ErrorCodeValue != 0)
                {
                    return result.errmsg;
                }
                return $"你是：{result.nickname}";
            }
            catch (Exception e)
            {
                return $"异常:{e.Message}";
            }
        }
    }
}
