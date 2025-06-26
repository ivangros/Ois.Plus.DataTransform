using ProtoBuf;
using System.Xml.Serialization;

namespace Ois.Plus.ObjectModel
{
    [Serializable, ProtoContract]
    public class WorkResult : InteractionObject
    {
        [XmlElement("ProcessItem")]
        public ProcessItem xmlProcessItem;

        [XmlIgnore]
        public ProcessItem ProcessItem
        {
            get => xmlProcessItem ??= new();
            set => xmlProcessItem = value;
        }
    }

    [Serializable, ProtoContract]
    public class ProcessItem : InteractionObject
    {
        /// <summary>
        /// Используется для сериализации
        /// </summary>
        [XmlElement("ModifiedRes")]
        public ModifiedRes xmlModifiedRes;

        [XmlIgnore]
        public ModifiedRes ModifiedRes
        {
            get => xmlModifiedRes ??= new();
            set => xmlModifiedRes = value;
        }
    }

    [Serializable, ProtoContract]
    public class ModifiedRes : InteractionObject
    {
        /// <summary>
        /// Используется для сериализации
        /// </summary>
        [XmlElement("Objects")]
        public List<Objects> xmlObjects;

        [XmlIgnore]
        public List<Objects> Objects
        {
            get => xmlObjects ??= [];
            set
            {
                if (xmlObjects != value)
                    xmlObjects = value;
            }
        }
    }
}