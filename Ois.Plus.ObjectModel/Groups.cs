using ProtoBuf;
using System.Xml.Serialization;

// 650 .. 699

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Groups : Group
{
}

[Serializable, ProtoContract]
[ProtoInclude(652, typeof(Groups))]
public class Group : InteractionObject
{
    private ListEx<Group> _items;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("Group")]
    [ProtoMember(651)]
    public Group[] ItemsXml
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
    public ListEx<Group> Items
    {
        get => _items ??= new(this);
        set
        {
            if (_items != value)
                _items = value;
        }
    }
}