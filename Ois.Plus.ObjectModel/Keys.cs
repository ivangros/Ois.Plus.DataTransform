using ProtoBuf;
using System.Xml.Serialization;

// ProtoBuf 750 .. 799

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Keys : InteractionObject
{
    private ListEx<Key> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Key")]
    [ProtoMember(750)]
    public Key[] ItemsXml
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
    public ListEx<Key> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}

[Serializable, ProtoContract]
public class Key : Item
{
}

[Serializable, ProtoContract]
public class FuncParameter : InteractionObject
{
    private ListEx<ValueItem> _valueItems;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Item")]
    [ProtoMember(752)]
    public ValueItem[] ValueItemsXml
    {
        get => _valueItems?.ToArray();
        set
        {
            if (value != null)
            {
                _valueItems ??= new(this);
                _valueItems.Clear();
                _valueItems.AddRange(value);
            }
            else
                _valueItems = null;
        }
    }

    [XmlIgnore]
    public ListEx<ValueItem> ValueItems
    {
        get => _valueItems ??= new(this);
        set => _valueItems = value;
    }
}

[Serializable, ProtoContract]
public class ValueItem : InteractionObject
{
}