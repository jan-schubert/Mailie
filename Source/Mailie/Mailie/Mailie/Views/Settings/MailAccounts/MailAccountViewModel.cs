using Mailie.Cryptography;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.Settings.MailAccounts
{
  public class MailAccountViewModel
    : DetailViewModelBase<MailAccount, MailAccountOverviewView>
  {
    private readonly ICryptographyService _cryptographyService;

    public MailAccountViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator,
      ICryptographyService cryptographyService)
      : base(unitOfWork, eventAggregator)
    {
      _cryptographyService = cryptographyService;
    }

    public string Password
    {
      set
      {
        if (string.IsNullOrEmpty(value))
          return;

        Item.Password = _cryptographyService.Encrypt(value);
        InvokePropertyChanged();
      }
    }
  }
}