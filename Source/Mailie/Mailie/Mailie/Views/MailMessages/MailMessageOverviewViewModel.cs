using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailMessages
{
  public class MailMessageOverviewViewModel : OverviewViewModel<MailMessage, MailMessageView>
  {
    public MailMessageOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}