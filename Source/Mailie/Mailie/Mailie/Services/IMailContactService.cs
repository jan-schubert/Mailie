using Mailie.DataAccessLayer;
using MimeKit;

namespace Mailie.Services
{
  public interface IMailContactService
  {
    MailContact GetMailContactBy(MimeMessage message);
  }
}