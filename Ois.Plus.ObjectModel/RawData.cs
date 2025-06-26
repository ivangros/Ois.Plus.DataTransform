using ProtoBuf;
using System.Xml.Serialization;

// ProtoBuf 2000 .. 2049

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class RawData : InteractionObject
{
    private ListEx<Item> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Item")]
    [ProtoMember(2000)]
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