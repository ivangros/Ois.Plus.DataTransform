using ProtoBuf;
using System.Xml.Serialization;

// 300 ... 349

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
[ProtoInclude(340, typeof(Key))]
[ProtoInclude(341, typeof(Property))]
public class Item : InteractionObject
{
    [XmlIgnore]
    [ProtoIgnore]
    public ulong ID
    {
        get => !string.IsNullOrEmpty(id) && ulong.TryParse(id, out ulong result) ? result : 0;
        set => id = value.ToString();
    }

    [XmlIgnore]
    [ProtoIgnore]
    public ulong NS
    {
        get => !string.IsNullOrEmpty(ns) && ulong.TryParse(ns, out ulong result) ? result : 0;
        set => ns = value.ToString();
    }

    #region Items

    private ListEx<Item> _items;

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Item")]
    [ProtoMember(300)]
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
        set => _items = value;
    }

    #endregion

    #region Keys

    private ListEx<Key> _keys;

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Key")]
    [ProtoMember(301)]
    public Key[] KeysXml
    {
        get => _keys?.ToArray();
        set
        {
            if (value != null)
            {
                _keys ??= new(this);
                _keys.Clear();
                _keys.AddRange(value);
            }
            else
                _keys = null;
        }
    }

    [XmlIgnore]
    public ListEx<Key> Keys
    {
        get => _keys ??= new(this);
        set
        {
            if (_keys != value)
                _keys = value;
        }
    }

    #endregion

    #region Properties

    private List<Property> _properties;

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Property")]
    [ProtoMember(302)]
    public Property[] PropertiesXml
    {
        get => _properties?.ToArray();
        set
        {
            if (value != null)
            {
                _properties ??= [];
                _properties.Clear();
                _properties.AddRange(value);
            }
            else
                _properties = null;
        }
    }

    [XmlIgnore]
    public List<Property> Properties
    {
        get => _properties ??= [];
        set
        {
            if (_properties != value)
                _properties = value;
        }
    }

    #endregion

    #region Conditions

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Conditions")]
    [ProtoMember(303)]
    public Conditions ConditionsXml { get; set; }

    [XmlIgnore]
    public Conditions Conditions
    {
        get => ConditionsXml ??= new();
        set
        {
            if (ConditionsXml != value)
                ConditionsXml = value;
        }
    }

    #endregion

    #region TimeConstraint

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("TimeConstraint")]
    [ProtoMember(304)]
    public TimeConstraint TimeConstraintXml { get; set; }

    [XmlIgnore]
    public TimeConstraint TimeConstraint
    {
        get => TimeConstraintXml ??= new();
        set
        {
            if (TimeConstraintXml != value)
                TimeConstraintXml = value;
        }
    }

    #endregion

    #region Orders

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Orders")]
    [ProtoMember(305)]
    public Orders OrdersXml { get; set; }

    [XmlIgnore]
    public Orders Orders
    {
        get => OrdersXml ??= new();
        set
        {
            if (OrdersXml != value)
                OrdersXml = value;
        }
    }

    #endregion

    [XmlElement("Content")]
    [ProtoMember(306)]
    public string Content { get; set; }

    [XmlElement("Sql")]
    [ProtoMember(307)]
    public string Sql { get; set; }

    #region FuncParameters

    private ListEx<FuncParameter> _funcParameters;

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("FuncParameter")]
    [ProtoMember(308)]
    public FuncParameter[] FuncParametersXml
    {
        get => _funcParameters?.ToArray();
        set
        {
            if (value != null)
            {
                _funcParameters ??= new(this);
                _funcParameters.Clear();
                _funcParameters.AddRange(value);
            }
            else
                _funcParameters = null;
        }
    }

    [XmlIgnore]
    public ListEx<FuncParameter> FuncParameters
    {
        get => _funcParameters ??= new(this);
        set => _funcParameters = value;
    }

    #endregion

    #region AggInfo

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("AggInfo")]
    [ProtoMember(309)]
    public AggInfo AggInfoXml { get; set; }

    [XmlIgnore]
    public AggInfo AggInfo
    {
        get => AggInfoXml ??= new();
        set
        {
            if (AggInfoXml != value)
                AggInfoXml = value;
        }
    }

    #endregion

    #region ExceptionItem

    /// <summary>
    /// ������������ ��� ������������
    /// </summary>
    [XmlElement("Exception")]
    [ProtoMember(310)]
    public ExceptionItem ExceptionXml { get; set; }

    [XmlIgnore]
    public ExceptionItem Exception
    {
        get => ExceptionXml ??= new();
        set
        {
            if (ExceptionXml != value)
                ExceptionXml = value;
        }
    }

    #endregion

    #region QObject

    [XmlIgnore]
    [ProtoIgnore]
    public ItemSearch<Item> Search => new(this.Items);

    [XmlIgnore]
    [ProtoIgnore]
    public ChildSearch Child => new(this, this.Items);

    #endregion
}

[Serializable]
[ProtoContract]
public class AggInfo : InteractionObject
{
}