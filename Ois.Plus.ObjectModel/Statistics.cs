using ProtoBuf;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

// 600 .. 649

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Statistics : StatRow
{
}

[Serializable, ProtoContract]
[ProtoInclude(640, typeof(Statistics))]
public class StatRow : InteractionObject
{
    private ListEx<StatRow> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("StatRow")]
    [ProtoMember(600)]
    public StatRow[] ItemsXml
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
    public ListEx<StatRow> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}