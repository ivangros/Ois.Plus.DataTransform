using ProtoBuf;
using System.Xml.Serialization;

// 1000 .. 1050

namespace Ois.Plus.ObjectModel
{
    [Serializable, ProtoContract]
    public class Orders : InteractionObject
    {
        private ListEx<Order> _items;

        /// <summary>
        /// Используется для сериализации
        /// </summary>
        [XmlElement("Order")]
        [ProtoMember(1000)]
        public Order[] ItemsXml
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
        public ListEx<Order> Items
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
    public class Order : InteractionObject
    {
    }
}