using ProtoBuf;
using System.Xml.Serialization;

// 400 .. 449

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Objects : InteractionObject
{
    private ListEx<Item> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Item")]
    [ProtoMember(400)]
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

    [XmlIgnore]
    [ProtoIgnore]
    public ItemSearch<Item> Search => _items == null ? null : new(_items);

    [XmlIgnore]
    [ProtoIgnore]
    public ChildSearch Child => _items == null ? null : new(null, _items);
}
