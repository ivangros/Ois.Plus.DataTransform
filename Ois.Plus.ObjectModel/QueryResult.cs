using Newtonsoft.Json;
using ProtoBuf;
using System.Xml.Serialization;

// 500 .. 549

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class QueryResult : Query
{
    #region Classes

    [JsonIgnore]
    [XmlElement("Classes")]
    [ProtoMember(500)]
    public Classes ClassesXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Classes Classes
    {
        get => ClassesXml ??= new();
        set
        {
            ClassesXml = value;
            if (ClassesXml != null)
                ClassesXml.Parent = this;
        }
    }

    #endregion

    #region Properties

    [JsonIgnore]
    [XmlElement("Properties")]
    [ProtoMember(501)]
    public Properties PropertiesXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Properties Properties
    {
        get => PropertiesXml ??= new();
        set
        {
            PropertiesXml = value;
            if (PropertiesXml != null)
                PropertiesXml.Parent = this;
        }
    }

    #endregion

    #region Statistics

    /// <summary>
    /// Используется для сериализации
    /// </summary>
    [JsonIgnore]
    [XmlElement("Statistics")]
    [ProtoMember(502)]
    public Statistics StatisticsXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Statistics Statistics
    {
        get => StatisticsXml ??= new();
        set
        {
            StatisticsXml = value;
            if (StatisticsXml != null)
                StatisticsXml.Parent = this;
        }
    }

    #endregion

    #region RawData

    [JsonIgnore]
    [XmlElement("RawData")]
    [ProtoMember(503)]
    public RawData RawDataXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public RawData RawData
    {
        get => RawDataXml ??= new();
        set
        {
            RawDataXml = value;
            if (RawDataXml != null)
                RawDataXml.Parent = this;
        }
    }

    #endregion

    #region IntervalData

    [JsonIgnore]
    [XmlElement("IntervalData")]
    [ProtoMember(504)]
    public IntervalData IntervalDataXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public IntervalData IntervalData
    {
        get => IntervalDataXml ??= new();
        set
        {
            IntervalDataXml = value;
            if (IntervalDataXml != null)
                IntervalDataXml.Parent = this;
        }
    }

    #endregion

    #region WorkTables

    [JsonIgnore]
    [XmlElement("WorkTables")]
    [ProtoMember(505)]
    public WorkTables WorkTablesXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public WorkTables WorkTables
    {
        get => WorkTablesXml ??= new();
        set
        {
            WorkTablesXml = value;
            if (WorkTablesXml != null)
                WorkTablesXml.Parent = this;
        }
    }

    #endregion

    #region MetaInformation

    [JsonIgnore]
    [XmlElement("Metainformation")]
    [ProtoMember(506)]
    public MetaInformation MetaInformationXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public MetaInformation MetaInformation
    {
        get => MetaInformationXml ??= new();
        set
        {
            MetaInformationXml = value;
            if (MetaInformationXml != null)
                MetaInformationXml.Parent = this;
        }
    }

    #endregion
}