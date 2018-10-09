using System;
using Mailie.DataAccessLayer;
using MimeKit;

namespace Mailie.Services
{
  public class MailContactService : IMailContactService
  {
    private static readonly Guid UnassignedMailContactGuid = Guid.Parse("2DB9530C-345E-4B00-BE55-C80C909E30EE");
    private readonly IUnitOfWork _unitOfWork;
    private MailContact _unassignedMailContact;

    public MailContactService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public MailContact GetMailContactBy(MimeMessage message)
    {
      if (_unassignedMailContact != null)
        return _unassignedMailContact;

      return _unassignedMailContact = _unitOfWork.MailContactRepository.TryGetBy(UnassignedMailContactGuid) ?? CreateUnassignedContact();
    }

    private MailContact CreateUnassignedContact()
    {
      var mailContact = _unitOfWork.MailContactRepository.CreateNew();
      mailContact.Guid = UnassignedMailContactGuid;
      mailContact.Name = "Unassigned";
      return mailContact;
    }
  }
}