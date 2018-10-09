using Mailie.DataAccessLayer;
using MimeKit;

namespace Mailie.Services
{
  public interface IMailMessageService
  {
    void MapMimeMessageToMailMessage(MimeMessage mimeMessage, MailMessage mailMessage);
  }
}