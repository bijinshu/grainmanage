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
using System.Text.RegularExpressions;
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
            var result = GetResult(requestMessage, requestMessage.Content);
            if (result == null)
            {
                var responseMessage = CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = $"请尝试如下关键字：{Environment.NewLine}{string.Join('、', MsgService.GetKeywords())}";
                return responseMessage;
            }
            return result;
        }
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            if (string.IsNullOrWhiteSpace(requestMessage.Recognition))
            {
                var responseMessage = CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = $"未能识别语音输入";
                return responseMessage;
            }
            var filter = Regex.Replace(requestMessage.Recognition, @"\W+", string.Empty) ?? string.Empty;
            var result = GetResult(requestMessage, filter);
            if (result == null)
            {
                var responseMessage = CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = $"语音识别结果：{Environment.NewLine}{requestMessage.Recognition}{Environment.NewLine}过滤后结果：{Environment.NewLine}{filter}";
                return responseMessage;
            }
            return result;
        }


        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "亲，暂时只支持响应文本消息哦";
            return responseMessage;
        }

        public IResponseMessageBase GetResult(RequestMessageBase requestMessage, string keyword)
        {
            var model = SysMapService.Get(keyword);
            if (model != null && !string.IsNullOrEmpty(model.Value))
            {
                var resp = CreateResponseMessage<ResponseMessageText>();
                switch (model.Action)
                {
                    case "method":
                        try
                        {
                            var classType = model.Value.Substring(0, model.Value.LastIndexOf('.'));
                            var type = Type.GetType(classType);
                            var method = type.GetMethod(model.Value.Substring(model.Value.LastIndexOf('.') + 1));
                            var instance = Activator.CreateInstance(type, new object[] { this });
                            var result = method.Invoke(instance, new object[] { requestMessage });
                            if (result is string)
                            {
                                resp.Content = result as string;
                            }
                            else
                            {
                                return result as IResponseMessageBase;
                            }
                        }
                        catch (Exception e)
                        {
                            resp.Content = e.Message;
                        }
                        break;
                    default:
                        resp.Content = model.Value;
                        break;
                }
                return resp;
            }
            return null;
        }
    }
}
