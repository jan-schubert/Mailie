using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailAccountSettings
{
  public class MailAccountViewModel : UnitOfWorkViewModelBase
  {
    private MailAccount _mailAccount;

    public MailAccountViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }

    public MailAccount MailAccount
    {
      get => _mailAccount;
      set
      {
        if (Equals(value, _mailAccount)) return;
        _mailAccount = value;
        InvokePropertyChanged();
      }
    }

    protected override Task OnLoadedAsync(object parameter)
    {
      if (parameter == null)
      {
        MailAccount = UnitOfWork.MailAccountRepository.CreateNew();
        UnitOfWork.MailAccountRepository.Add(MailAccount);
      }
      else
      {
        MailAccount = (MailAccount) parameter;
      }

      return Task.CompletedTask;
    }

    protected override Task OnUnloadedAsync()
    {
      MailAccount = null;
      return Task.CompletedTask;
    }

    protected override Task OnDoNotSaveChangesAsync()
    {
      UnitOfWork.ResetEntityState(MailAccount);
      return Task.CompletedTask;
    }
  }
}