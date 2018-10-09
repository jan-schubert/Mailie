using System;
using System.Linq;
using System.Threading.Tasks;
using Mailie.Cryptography;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;
using Mailie.Services;
using Mailie.Views.MailMessages;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;

namespace Mailie.Views.MailContacts
{
  public class MailContactOverviewViewModel : OverviewViewModel<MailContact, MailMessageOverviewView>
  {
    private readonly ICryptographyService _cryptographyService;
    private readonly IMailContactService _mailContactService;
    private readonly IMailMessageService _mailMessageService;

    public MailContactOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator,
      ICryptographyService cryptographyService, IMailMessageService mailMessageService,
      IMailContactService mailContactService)
      : base(unitOfWork, eventAggregator)
    {
      _cryptographyService = cryptographyService;
      _mailMessageService = mailMessageService;
      _mailContactService = mailContactService;
      RefreshCommand = new DelegateCommand<object, object>(OnRefresh);
    }

    public DelegateCommand<object, object> RefreshCommand { get; }

    private async Task OnRefresh(object arg)
    {
      foreach (var mailAccount in await UnitOfWork.MailAccountRepository.GetAllQuery().ToListAsync())
      {
        using (var client = new ImapClient())
        {
          //TODO use secure socket options
          await client.ConnectAsync(mailAccount.Host, mailAccount.Port, true);

          await client.AuthenticateAsync(mailAccount.Username, _cryptographyService.Decrypt(mailAccount.Password));
          var inbox = client.Inbox;
          await inbox.OpenAsync(FolderAccess.ReadOnly);

          var query = SearchQuery.DeliveredAfter(DateTime.Now - TimeSpan.FromDays(30));
          var i = 0;
          foreach (var uid in inbox.Search(query))
          {
            var message = inbox.GetMessage(uid);
            var mailMessage = UnitOfWork.MailMessageRepository.GetAllQuery().FirstOrDefault(x => x.MessageId == message.MessageId);
            if (mailMessage == null)
            {
              mailMessage = UnitOfWork.MailMessageRepository.CreateNew();
              _mailMessageService.MapMimeMessageToMailMessage(message, mailMessage);
              mailMessage.MailContact = _mailContactService.GetMailContactBy(message);
              UnitOfWork.MailMessageRepository.Add(mailMessage);
            }
            else
            {
              if (mailMessage.MailContact == null)
              {
                mailMessage.MailContact = _mailContactService.GetMailContactBy(message);
                UnitOfWork.MailMessageRepository.Update(mailMessage);
              }
            }

            if (i++ % 50 == 0 && UnitOfWork.HasChanges()) await UnitOfWork.SaveChangesAsync();
          }

          await client.DisconnectAsync(true);
        }

        if (UnitOfWork.HasChanges())
          await UnitOfWork.SaveChangesAsync();
      }

      Items.Clear();
      await OnLoadedAsync(null);
    }

    protected override async Task OnLoadedAsync(object parameter)
    {
      foreach (var item in await UnitOfWork.GetRepository<MailMessage>().GetAllQuery().Include(x => x.MailContact)
        .GroupBy(x => x.MailContact)
        .Select(x => x.Key)
        .ToListAsync())
        Items.Add(item);
    }
  }
}