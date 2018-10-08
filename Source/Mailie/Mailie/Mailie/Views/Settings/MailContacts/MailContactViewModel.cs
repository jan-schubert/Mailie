using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;

namespace Mailie.Views.Settings.MailContacts
{
  public class MailContactViewModel
    : DetailViewModelBase<MailContact, MailContactOverviewView>
  {
    private MailAddress _selectedAddress;
    public DelegateCommand<object, object> AddAddressCommand { get; }
    public DelegateCommand<object, object> DeleteSelectedAddressCommand { get; }

    public MailAddress SelectedAddress
    {
      get => _selectedAddress;
      set
      {
        if (Equals(value, _selectedAddress)) return;
        _selectedAddress = value;
        InvokePropertyChanged();
        DeleteSelectedAddressCommand.InvokeCanExecuteChanged();
      }
    }

    public MailContactViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
      AddAddressCommand = new DelegateCommand<object, object>(OnAddAddress);
      DeleteSelectedAddressCommand = new DelegateCommand<object, object>(OnDeleteSelectedAddress, x => _selectedAddress != null);
    }

    private Task OnDeleteSelectedAddress(object arg)
    {
      if (_selectedAddress == null)
        return Task.CompletedTask;

      UnitOfWork.MailAddressRepository.Delete(_selectedAddress);
      Item.MailAddresses.Remove(_selectedAddress);
      return Task.CompletedTask;
    }

    private Task OnAddAddress(object arg)
    {
      var mailAddress = UnitOfWork.MailAddressRepository.CreateNew();
      mailAddress.MailContact = Item;
      Item.MailAddresses.Add(mailAddress);
      return Task.CompletedTask;
    }

    public override MailContact OnSetItemFromParameter(object parameter)
    {
      var mailContact = (MailContact)parameter;
      UnitOfWork.MailContactRepository.LoadCollection(mailContact, x => x.MailAddresses);
      return mailContact;
    }
  }
}