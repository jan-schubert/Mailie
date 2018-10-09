using Mailie.DataAccessLayer;
using MimeKit;
using MessageImportance = Mailie.DataAccessLayer.MessageImportance;
using MessagePriority = Mailie.DataAccessLayer.MessagePriority;

namespace Mailie.Services
{
  public class MailMessageService : IMailMessageService
  {
    public void MapMimeMessageToMailMessage(MimeMessage mimeMessage, MailMessage mailMessage)
    {
      mailMessage.MessageId = mimeMessage.MessageId;
      mailMessage.ResentMessageId = mimeMessage.ResentMessageId;
      mailMessage.HtmlBody = mimeMessage.HtmlBody;
      mailMessage.InReplyTo = mimeMessage.InReplyTo;
      mailMessage.Subject = mimeMessage.Subject;
      mailMessage.TextBody = mimeMessage.TextBody;
      mailMessage.Bcc = mimeMessage.Bcc.ToString();
      mailMessage.Cc = mimeMessage.Cc.ToString();
      mailMessage.Date = mimeMessage.Date.DateTime;
      mailMessage.From = mimeMessage.From.ToString();
      mailMessage.MessageImportance = (MessageImportance) mimeMessage.Importance;
      mailMessage.MimeVersion = mimeMessage.MimeVersion.ToString();
      mailMessage.MessagePriority = (MessagePriority) mimeMessage.Priority;
      mailMessage.ReplyTo = mimeMessage.ReplyTo.ToString();
      mailMessage.ResentBcc = mimeMessage.ResentBcc.ToString();
      mailMessage.ResentCc = mimeMessage.ResentCc.ToString();
      mailMessage.ResentDate = mimeMessage.ResentDate.DateTime;
      mailMessage.ResentFrom = mimeMessage.ResentFrom.ToString();
      mailMessage.ResentReplyTo = mimeMessage.ResentReplyTo.ToString();
      mailMessage.ResentSender = mimeMessage.ResentSender?.ToString();
      mailMessage.ResentTo = mimeMessage.ResentTo.ToString();
      mailMessage.Sender = mimeMessage.Sender?.ToString();
      mailMessage.To = mimeMessage.To.ToString();
      mailMessage.XPriority = (XPriority) mimeMessage.XPriority;
    }
  }
}