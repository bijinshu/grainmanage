using System.Net.Mail;

namespace GrainManage.Web.Util
{
    public class EmailUtil
    {

        private string from;//发件人地址
        private string password;//发件人密码  

        /// <summary>
        /// 使用发件人地址和密码实例化
        /// </summary>
        public EmailUtil(string from, string password)
        {
            this.from = from;
            this.password = password;
        }

        public SendCompletedEventHandler SendCompleted { get; set; }

        private SmtpClient GetSmtpClient(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(mailMessage.From.Address, password);//设置发件人身份的票据  
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Host = "smtp." + mailMessage.From.Host;
            return smtpClient;
        }

        private MailMessage GetMailMessage(string to, string body, string title)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.From = new System.Net.Mail.MailAddress(from);
            mailMessage.Subject = title;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
            return mailMessage;
        }

        /// <summary>
        /// 处审核后类的实例  
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="title"></param>
        public void SendMail(string to, string body, string title)
        {
            MailMessage mailMessage = GetMailMessage(to, body, title);
            SmtpClient smtpClient = GetSmtpClient(mailMessage);
            smtpClient.Send(mailMessage);
        }

        public void SendAsync(string to, string body, string title)
        {
            MailMessage mailMessage = GetMailMessage(to, body, title);
            SmtpClient smtpClient = GetSmtpClient(mailMessage);
            if (SendCompleted != null)
            {
                smtpClient.SendCompleted += SendCompleted;//注册异步发送邮件完成时的事件  
            }
            smtpClient.SendAsync(mailMessage, mailMessage.Body);
        }
    }
}