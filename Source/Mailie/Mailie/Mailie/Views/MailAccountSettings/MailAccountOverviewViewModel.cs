using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Mailie.Views.MailAccountSettings
{
  public class MailAccountOverviewViewModel : UnitOfWorkViewModelBase
  {
    public ObservableCollection<MailAccount> MailAccounts { get; } = new ObservableCollection<MailAccount>();

    public DelegateCommand<object, object> NewMailAccount { get; }

    public MailAccountOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
      NewMailAccount = new DelegateCommand<object, object>(OnNewMailAccount);
    }

    protected override async Task OnLoadedAsync(object parameter)
    {
      foreach (var mailAccount in await UnitOfWork.MailAccountRepository.GetAllQuery().ToListAsync())
      {
        MailAccounts.Add(mailAccount);
      }
    }

    protected override Task OnUnloadedAsync()
    {
      MailAccounts.Clear();
      return Task.CompletedTask;
    }

    private Task OnNewMailAccount(object arg)
    {
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(MailAccountView)));
    }
  }
}