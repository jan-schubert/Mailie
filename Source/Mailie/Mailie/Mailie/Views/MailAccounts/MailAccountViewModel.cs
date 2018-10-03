using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailAccounts
{
  public class MailAccountViewModel
    : DetailViewModelBase<MailAccount, MailAccountOverviewView>
  {
    public MailAccountViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}