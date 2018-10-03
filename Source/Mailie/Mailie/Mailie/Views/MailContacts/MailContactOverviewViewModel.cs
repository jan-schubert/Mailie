using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Mailie.Views.MailContacts
{
  public class MailContactOverviewViewModel : OverviewViewModel<MailContact, MailContactView>
  {
    public MailContactOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}