using MailKit.Security;

namespace Mailie.DataAccessLayer
{
  public class MailAccount : Entity
  {
    private string _host;
    private int _port;
    private SecureSocketOptions _secureSocketOptions;
    private string _username;
    private string _password;

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

    public string Username
    {
      get => _username;
      set
      {
        if (value == _username) return;
        _username = value;
        InvokePropertyChanged();
      }
    }

    public string Password
    {
      get => _password;
      set
      {
        if (value == _password) return;
        _password = value;
        InvokePropertyChanged();
      }
    }

    public override string ToString()
    {
      return Host;
    }
  }
}