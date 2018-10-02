using MailKit.Security;

namespace Mailie.DataAccessLayer
{
  public class MailAccount : Entity
  {
    private string _host;
    private int _port;
    private SecureSocketOptions _secureSocketOptions;

    public string Host
    {
      get => _host;
      set
      {
        if (value == _host) return;
        _host = value;
        InvokePropertyChanged();
      }
    }

    public int Port
    {
      get => _port;
      set
      {
        if (value == _port) return;
        _port = value;
        InvokePropertyChanged();
      }
    }

    public SecureSocketOptions SecureSocketOptions
    {
      get => _secureSocketOptions;
      set
      {
        if (value == _secureSocketOptions) return;
        _secureSocketOptions = value;
        InvokePropertyChanged();
      }
    }
  }
}