using ProtoBuf;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

// 3000 .. 3049

namespace Ois.Plus.ObjectModel
{
    [Serializable, ProtoContract]
    public class Options : InteractionObject
    {
        [XmlElement("ViewFlags")]
        [ProtoMember(3000)]
        public ViewFlags ViewFlagsXml { get; set; }

        [XmlIgnore]
        public ViewFlags ViewFlags
        {
            get => ViewFlagsXml ??= new();
            set
            {
                if (ViewFlagsXml != value)
                    ViewFlagsXml = value;
            }
        }
    }

    [Serializable, ProtoContract]
    public class ViewFlags : InteractionObject
    {

    }
}