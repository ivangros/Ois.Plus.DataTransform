using ProtoBuf;
using System.Xml.Serialization;

// ProtoBuf 2050 .. 2100

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class IntervalData : InteractionObject
{
    private ListEx<Item> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Item")]
    [ProtoMember(2050)]
    public Item[] ItemsXml
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
    public ListEx<Item> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}