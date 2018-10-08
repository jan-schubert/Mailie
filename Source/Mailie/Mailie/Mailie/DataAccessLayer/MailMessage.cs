using System;

namespace Mailie.DataAccessLayer
{
  public class MailMessage : Entity
  {
    private string _bcc;
    private string _bodyText;
    private string _cc;
    private DateTime _date;
    private string _from;
    private string _htmlBody;
    private string _inReplyTo;
    private MailContact _mailContact;
    private string _messageId;
    private MessageImportance _messageImportance;
    private MessagePriority _messagePriority;
    private string _mimeVersion;
    private string _replyTo;
    private string _resentBcc;
    private string _resentCc;
    private DateTime _resentDate;
    private string _resentFrom;
    private string _resentMessageId;
    private string _resentReplyTo;
    private string _resentSender;
    private string _resentTo;
    private string _sender;
    private string _subject;
    private string _textBody;
    private XPriority _xPriority;

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

    public string Bcc
    {
      get => _bcc;
      set
      {
        if (value == _bcc) return;
        _bcc = value;
        InvokePropertyChanged();
      }
    }

    public string BodyText
    {
      get => _bodyText;
      set
      {
        if (value == _bodyText) return;
        _bodyText = value;
        InvokePropertyChanged();
      }
    }

    public string Cc
    {
      get => _cc;
      set
      {
        if (value == _cc) return;
        _cc = value;
        InvokePropertyChanged();
      }
    }

    public DateTime Date
    {
      get => _date;
      set
      {
        if (value.Equals(_date)) return;
        _date = value;
        InvokePropertyChanged();
      }
    }

    public string From
    {
      get => _from;
      set
      {
        if (value == _from) return;
        _from = value;
        InvokePropertyChanged();
      }
    }

    public string HtmlBody
    {
      get => _htmlBody;
      set
      {
        if (value == _htmlBody) return;
        _htmlBody = value;
        InvokePropertyChanged();
      }
    }

    public MessageImportance MessageImportance
    {
      get => _messageImportance;
      set
      {
        if (value == _messageImportance) return;
        _messageImportance = value;
        InvokePropertyChanged();
      }
    }

    public string InReplyTo
    {
      get => _inReplyTo;
      set
      {
        if (value == _inReplyTo) return;
        _inReplyTo = value;
        InvokePropertyChanged();
      }
    }

    public string MessageId
    {
      get => _messageId;
      set
      {
        if (value == _messageId) return;
        _messageId = value;
        InvokePropertyChanged();
      }
    }

    public string MimeVersion
    {
      get => _mimeVersion;
      set
      {
        if (value == _mimeVersion) return;
        _mimeVersion = value;
        InvokePropertyChanged();
      }
    }

    public MessagePriority MessagePriority
    {
      get => _messagePriority;
      set
      {
        if (value == _messagePriority) return;
        _messagePriority = value;
        InvokePropertyChanged();
      }
    }

    public string ReplyTo
    {
      get => _replyTo;
      set
      {
        if (value == _replyTo) return;
        _replyTo = value;
        InvokePropertyChanged();
      }
    }

    public string ResentBcc
    {
      get => _resentBcc;
      set
      {
        if (value == _resentBcc) return;
        _resentBcc = value;
        InvokePropertyChanged();
      }
    }

    public string ResentCc
    {
      get => _resentCc;
      set
      {
        if (value == _resentCc) return;
        _resentCc = value;
        InvokePropertyChanged();
      }
    }

    public DateTime ResentDate
    {
      get => _resentDate;
      set
      {
        if (value.Equals(_resentDate)) return;
        _resentDate = value;
        InvokePropertyChanged();
      }
    }

    public string ResentFrom
    {
      get => _resentFrom;
      set
      {
        if (value == _resentFrom) return;
        _resentFrom = value;
        InvokePropertyChanged();
      }
    }

    public string ResentMessageId
    {
      get => _resentMessageId;
      set
      {
        if (value == _resentMessageId) return;
        _resentMessageId = value;
        InvokePropertyChanged();
      }
    }

    public string ResentReplyTo
    {
      get => _resentReplyTo;
      set
      {
        if (value == _resentReplyTo) return;
        _resentReplyTo = value;
        InvokePropertyChanged();
      }
    }

    public string ResentSender
    {
      get => _resentSender;
      set
      {
        if (value == _resentSender) return;
        _resentSender = value;
        InvokePropertyChanged();
      }
    }

    public string ResentTo
    {
      get => _resentTo;
      set
      {
        if (value == _resentTo) return;
        _resentTo = value;
        InvokePropertyChanged();
      }
    }

    public string Sender
    {
      get => _sender;
      set
      {
        if (value == _sender) return;
        _sender = value;
        InvokePropertyChanged();
      }
    }

    public string Subject
    {
      get => _subject;
      set
      {
        if (value == _subject) return;
        _subject = value;
        InvokePropertyChanged();
      }
    }

    public string TextBody
    {
      get => _textBody;
      set
      {
        if (value == _textBody) return;
        _textBody = value;
        InvokePropertyChanged();
      }
    }

    public string To { get; set; }

    public XPriority XPriority
    {
      get => _xPriority;
      set
      {
        if (value == _xPriority) return;
        _xPriority = value;
        InvokePropertyChanged();
      }
    }
  }
}