using ProtoBuf;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

// 800 .. 850

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Classes : InteractionObject
{
    [XmlElement("CInfo")]
    [ProtoMember(800)]
    public List<CInfo> ItemsXml { get; set; }

    [XmlIgnore]
    public List<CInfo> Items
    {
        get => ItemsXml ??= [];
        set
        {
            if (ItemsXml != value)
                ItemsXml = value;
        }
    }
}

[Serializable, ProtoContract]
public class Properties : InteractionObject
{
    [XmlElement("PInfo")]
    [ProtoMember(801)]
    public List<PInfo> ItemsXml { get; set; }

    [XmlIgnore]
    public List<PInfo> Items
    {
        get => ItemsXml ??= [];
        set
        {
            if (ItemsXml != value)
                ItemsXml = value;
        }
    }
}

[Serializable, ProtoContract]
public class PInfo : InteractionObject
{
    [XmlElement("Uom")]
    [ProtoMember(802)]
    public List<Uom> UomsXml { get; set; }

    [XmlIgnore]
    public List<Uom> Uoms
    {
        get => UomsXml ??= [];
        set
        {
            if (UomsXml != value)
                UomsXml = value;
        }
    }
}

[Serializable, ProtoContract]
public class CInfo : InteractionObject
{
    [XmlElement("Uom")]
    [ProtoMember(803)]
    public List<Uom> UomsXml { get; set; }

    [XmlIgnore]
    public List<Uom> Uoms
    {
        get => UomsXml ??= [];
        set
        {
            if (UomsXml != value)
                UomsXml = value;
        }
    }
}

[Serializable, ProtoContract]
public class Uom : InteractionObject
{
}

[Serializable, ProtoContract]
public class MetaInformation : InteractionObject
{

    [XmlElement("ParamQuery")]
    [ProtoMember(804)]
    public ParamQuery ParamQueryXml { get; set; }

    [XmlIgnore]
    public ParamQuery ParamQuery
    {
        get => ParamQueryXml ??= new();
        set
        {
            if (ParamQueryXml != value)
                ParamQueryXml = value;
        }
    }

    private List<PropInfo> _propInfos;

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [XmlElement("PropInfo")]
    [ProtoMember(805)]
    public PropInfo[] PropInfosXml
    {
        get => _propInfos?.ToArray();
        set
        {
            if (value != null)
            {
                _propInfos ??= [];
                _propInfos.Clear();
                _propInfos.AddRange(value);
            }
            else
                _propInfos = null;
        }
    }

    [XmlIgnore]
    public List<PropInfo> PropInfos
    {
        get => _propInfos ??= [];
        set
        {
            if (_propInfos != value)
                _propInfos = value;
        }
    }
}

[Serializable, ProtoContract]
public class ParamQuery : InteractionObject
{
}

[Serializable, ProtoContract]
public class Format : InteractionObject
{
}

[Serializable, ProtoContract]
public class PropInfo : InteractionObject
{
    [XmlElement("Format")]
    [ProtoMember(806)]
    public Format FormatXml { get; set; }

    [XmlIgnore]
    public Format Format
    {
        get => FormatXml ??= new();
        set
        {
            if (FormatXml != value)
                FormatXml = value;
        }
    }
}
