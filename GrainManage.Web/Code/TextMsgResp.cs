using GrainManage.Dal;
using Senparc.Weixin;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Code
{
    public class TextMsgResp
    {
        public string GetSaleShop(RequestMessageText requestMessage)
        {
            var db = new GrainManageDB();
            return string.Join('、', db.Select<string>("select Name from bm_company limit 50"));
        }
        public string Whoami(RequestMessageText requestMessage)
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
