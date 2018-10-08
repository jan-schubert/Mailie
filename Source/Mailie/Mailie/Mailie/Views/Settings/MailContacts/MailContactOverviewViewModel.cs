using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.Settings.MailContacts
{
  public class MailContactOverviewViewModel : OverviewViewModel<MailContact, MailContactView>
  {
    public MailContactOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}