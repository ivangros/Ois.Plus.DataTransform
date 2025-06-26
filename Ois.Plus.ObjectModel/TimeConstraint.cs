using ProtoBuf;
using System.Xml.Serialization;

// ProtoBuf 700 ... 749

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class TimeConstraint : InteractionObject
{
    [XmlIgnore]
    public bool Enabled
    {
        get => string.IsNullOrEmpty(enabled) || enabled.Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
        set
        {
            if (Enabled != value)
                enabled = value.ToString();
        }
    }

    [XmlIgnore]
    public bool RegisteredValue
    {
        get => !string.IsNullOrEmpty(registeredValue) && registeredValue.Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
        set
        {
            if (RegisteredValue != value)
                registeredValue = value.ToString();
        }
    }

    [XmlElement("Exceptions")]
    [ProtoMember(700)]
    public Exceptions ExceptionsXml { get; set; }

    [XmlIgnore]
    public Exceptions Exceptions
    {
        get => ExceptionsXml ??= new();
        set
        {
            if (ExceptionsXml != value)
                ExceptionsXml = value;
        }
    }
}

[Serializable, ProtoContract]
public class TimeConstraints : InteractionObject
{
    private ListEx<TimeConstraint> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("TimeConstraint")]
    [ProtoMember(701)]
    public TimeConstraint[] ItemsXml
    {
        get => _items?.ToArray();
        set
        {
            if (value != null)
            {
                _items ??= new(this);
                _items.Clear();
                _items.AddRange(value);
            }
            else
                _items = null;
        }
    }

    [XmlIgnore]
    public ListEx<TimeConstraint> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}