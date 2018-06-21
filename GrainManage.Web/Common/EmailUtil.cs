using GrainManage.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Linq;

namespace GrainManage.Web.Common
{
    public class EmailUtil
    {

        private SmtpClient smtpClient = new SmtpClient();
        private MailAddress from = null;
        /// <summary>
        /// 使用发件人地址和密码实例化
        /// </summary>
        public EmailUtil(string host, string userName, string password, string displayName = "", int port = 25)
        {
            from = new MailAddress(userName, displayName, Encoding.UTF8);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.Credentials = new NetworkCredential(userName, password);//设置发件人身份的票据  
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public SendCompletedEventHandler SendCompleted { get; set; }

        private MailMessage GetMailMessage(IDictionary<string, string> tos, IDictionary<string, string> ccs, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            foreach (var to in tos)
            {
                mailMessage.To.Add(new MailAddress(to.Key, to.Value, Encoding.UTF8));
            }
            if (ccs != null && ccs.Any())
            {
                foreach (var cc in ccs)
                {
                    mailMessage.CC.Add(new MailAddress(cc.Key, cc.Value, Encoding.UTF8));
                }
            }
            mailMessage.From = from;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            return mailMessage;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">正文</param>
        public bool SendMail(IDictionary<string, string> to, IDictionary<string, string> cc, string subject, string body)
        {
            var random = new Random();
            var retryCount = AppConfig.GetValue<int>("retryCount");
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    Thread.Sleep(random.Next(200, 1000));
                    MailMessage mailMessage = GetMailMessage(to, cc, subject, body);
                    smtpClient.Send(mailMessage);
                    return true;
                }
                catch (Exception e)
                {
                    var logger = NLog.LogManager.GetCurrentClassLogger();
                    logger.Info(e, $"【发送失败】{subject}，进行第{i + 1}次重试");
                    Thread.Sleep(random.Next(1000, 5000));
                }
            }
            return false;
        }
    }
}