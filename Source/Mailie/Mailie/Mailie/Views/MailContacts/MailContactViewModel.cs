using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.MailContacts
{
  public class MailContactViewModel
    : DetailViewModelBase<MailContact, MailContactOverviewView>
  {
    public MailContactViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }
  }
}