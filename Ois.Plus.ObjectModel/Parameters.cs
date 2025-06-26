using ProtoBuf;
using System.Xml.Serialization;

// 550 .. 599

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Parameters : InteractionObject
{
    private ListEx<Parameter> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Parameter")]
    [ProtoMember(550)]
    public Parameter[] ItemsXml
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
    public ListEx<Parameter> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }

    [XmlIgnore]
    public new Parameter this[string name]
    {
        get
        {
            _items ??= new(this);

            name = name.ToLower().TrimStart(':');
            foreach (Parameter parameter in _items)
            {
                if (parameter.name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return parameter;
            }
            return null;
        }
    }
}

[Serializable, ProtoContract]
public class Parameter : InteractionObject
{
}