using ProtoBuf;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

// ProtoBuf 350 .. 399

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Exceptions : ExceptionItem
{
    private ListEx<ExceptionItem> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Exception")]
    [ProtoMember(350)]
    public ExceptionItem[] ItemsXml
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
    public ListEx<ExceptionItem> Items
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
[ProtoInclude(351, typeof(Exceptions))]
public class ExceptionItem : InteractionObject
{
    [XmlText]
    [ProtoMember(352)]
    public string Body { get; set; }
}