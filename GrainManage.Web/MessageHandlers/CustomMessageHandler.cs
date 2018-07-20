using GrainManage.Web.Services;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.MessageHandlers
{
    public class CustomMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        public CustomMessageHandler(Stream stream, PostModel postModel)
            : base(stream, postModel)
        {

        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            var model = SysMapService.Get(requestMessage.Content);
            if (model != null && !string.IsNullOrEmpty(model.Value))
            {
                switch (model.Action)
                {
                    case "method":
                        responseMessage.Content = Exec<string>(requestMessage, model.Value);
                        break;
                    default:
                        responseMessage.Content = model.Value;
                        break;
                }
            }
            else
            {
                model = SysMapService.Get("default");
                responseMessage.Content = model?.Value;
            }
            return responseMessage;
        }
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = $"语音识别结果：{Environment.NewLine}{requestMessage.Recognition}";
            return responseMessage;
        }


        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "亲，暂时只支持响应文本消息哦";
            return responseMessage;
        }

        public static T Exec<T>(RequestMessageText requestMessage, string value)
        {
            try
            {
                var classType = value.Substring(0, value.LastIndexOf('.'));
                var type = Type.GetType(classType);
                var method = type.GetMethod(value.Substring(value.LastIndexOf('.') + 1));
                var obj = Activator.CreateInstance(type);
                return (T)method.Invoke(obj, new object[] { requestMessage });
            }
            catch (Exception)
            {
            }
            return default(T);
        }
    }
}
