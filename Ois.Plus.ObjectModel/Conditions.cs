using ProtoBuf;
using System.Xml.Serialization;

// ProtoBuf 450 .. 499

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Conditions : Condition
{
}

[Serializable, ProtoContract]
[ProtoInclude(490, typeof(Conditions))]
public class Condition : InteractionObject
{
    private ListEx<Condition> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Condition")]
    [ProtoMember(454)]
    public Condition[] ItemsXml
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
    public ListEx<Condition> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}
