using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailMessages
{
  public class MailMessageViewModel : DetailViewModelBase<MailMessage, MailMessageOverviewView>
  {
    public MailMessageViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}