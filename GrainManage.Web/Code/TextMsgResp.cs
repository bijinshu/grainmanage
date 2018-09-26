using GrainManage.Web.Services;
using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.MessageHandlers;
using System;

namespace GrainManage.Web.Code
{
    public class TextMsgResp
    {
        private readonly MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>> handler;
        public TextMsgResp(MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>> handler)
        {
            this.handler = handler;
        }
        public string GetSaleShop()
        {
            return string.Join('、', CompanyService.GetCompanyNames());
        }
        public string Whoami()
        {
            try
            {
                var result = UserApi.Info(Config.SenparcWeixinSetting.WeixinAppId, handler.OpenId);
                if (result.ErrorCodeValue != 0)
                {
                    return result.errmsg;
                }
                return $"你是：{result.nickname}";
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
        }
    }
}
