namespace Mailie.DataAccessLayer
{
  public class MailAddress : Entity
  {
    private string _address;
    private int _mailContactId;
    private MailContact _mailContact;

    public string Address
    {
      get => _address;
      set
      {
        if (value == _address) return;
        _address = value;
        InvokePropertyChanged();
      }
    }

    public int MailContactId
    {
      get => _mailContactId;
      set
      {
        if (value == _mailContactId) return;
        _mailContactId = value;
        InvokePropertyChanged();
      }
    }

    public MailContact MailContact
    {
      get => _mailContact;
      set
      {
        if (Equals(value, _mailContact)) return;
        _mailContact = value;
        InvokePropertyChanged();
      }
    }
  }
}