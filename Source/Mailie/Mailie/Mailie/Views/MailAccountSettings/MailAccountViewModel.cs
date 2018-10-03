using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailAccountSettings
{
  public class MailAccountViewModel : UnitOfWorkViewModelBase
  {
    private MailAccount _mailAccount;

    public DelegateCommand<object, object> SaveCommand { get; }
    public DelegateCommand<object, object> DeleteCommand { get; }

    public MailAccountViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
      SaveCommand = new DelegateCommand<object, object>(OnSave);
      DeleteCommand = new DelegateCommand<object, object>(OnDelete);
    }

    private Task OnSave(object arg)
    {
      UnitOfWork.SaveChanges();
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(MailAccountOverviewView)));
    }

    private Task OnDelete(object arg)
    {
      UnitOfWork.MailAccountRepository.Delete(_mailAccount);
      UnitOfWork.SaveChanges();
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(MailAccountOverviewView)));
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