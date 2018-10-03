using System.Collections.Generic;

namespace Mailie.DataAccessLayer
{
  public class MailContact : Entity
  {
    private string _name;
    private ICollection<MailAddress> _mailAddresses;

    public string Name
    {
      get => _name;
      set
      {
        if (value == _name) return;
        _name = value;
        InvokePropertyChanged();
      }
    }

    public ICollection<MailAddress> MailAddresses
    {
      get => _mailAddresses;
      set
      {
        if (Equals(value, _mailAddresses)) return;
        _mailAddresses = value;
        InvokePropertyChanged();
      }
    }

    public override string ToString()
    {
      return Name;
    }
  }
}