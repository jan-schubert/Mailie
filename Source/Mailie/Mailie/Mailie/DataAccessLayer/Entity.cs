using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mailie.Annotations;

namespace Mailie.DataAccessLayer
{
  public class Entity : INotifyPropertyChanged
  {
    private DateTime _creationDateTime;
    private int _id;
    private DateTime _lastModifiedDateTime;

    public int Id
    {
      get => _id;
      set
      {
        if (value == _id) return;
        _id = value;
        InvokePropertyChanged();
      }
    }

    public DateTime CreationDateTime
    {
      get => _creationDateTime;
      set
      {
        if (value.Equals(_creationDateTime)) return;
        _creationDateTime = value;
        InvokePropertyChanged();
      }
    }

    public DateTime LastModifiedDateTime
    {
      get => _lastModifiedDateTime;
      set
      {
        if (value.Equals(_lastModifiedDateTime)) return;
        _lastModifiedDateTime = value;
        InvokePropertyChanged();
      }
    }

    public static IEqualityComparer<Entity> IdComparer { get; } = new IdEqualityComparer();

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void InvokePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool Equals(Entity other)
    {
      return _id == other._id;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((Entity) obj);
    }

    public override int GetHashCode()
    {
      return _id;
    }

    private sealed class IdEqualityComparer : IEqualityComparer<Entity>
    {
      public bool Equals(Entity x, Entity y)
      {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x._id == y._id;
      }

      public int GetHashCode(Entity obj)
      {
        return obj._id;
      }
    }
  }
}