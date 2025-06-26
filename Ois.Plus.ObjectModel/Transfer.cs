using ProtoBuf;
using System.Xml.Serialization;

// 850 .. 899

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Transfer : InteractionObject
{
    [XmlText]
    [ProtoMember(850)]
    public string Body { get; set; }
}