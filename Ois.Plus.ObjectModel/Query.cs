using Newtonsoft.Json;
using ProtoBuf;
using System.Xml.Serialization;

// 200 .. 249

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
[ProtoInclude(240, typeof(QueryResult))]
public class Query : InteractionObject
{
    #region Objects

    [JsonIgnore]
    [XmlElement("Objects")]
    [ProtoMember(200)]
    public Objects ObjectsXml { get; set; }

    [XmlIgnore]
    [JsonProperty("objects")]
    public Objects Objects
    {
        get => ObjectsXml ??= new();
        set
        {
            ObjectsXml = value;
            if (ObjectsXml != null)
                ObjectsXml.Parent = this;
        }
    }

    #endregion

    #region Keys

    [JsonIgnore]
    [XmlElement("Keys")]
    [ProtoMember(201)]
    public Keys KeysXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Keys Keys
    {
        get => KeysXml ??= new();
        set
        {
            KeysXml = value;
            if (KeysXml != null)
                KeysXml.Parent = this;
        }
    }

    #endregion

    #region Conditions

    [JsonIgnore]
    [XmlElement("Conditions")]
    [ProtoMember(202)]
    public Conditions ConditionsXml { get; set; }

    [XmlIgnore]
    [JsonProperty("conditions")]
    public Conditions Conditions
    {
        get => ConditionsXml ??= new();
        set
        {
            ConditionsXml = value;
            if (ConditionsXml != null)
                ConditionsXml.Parent = this;
        }
    }

    #endregion

    #region Parameters

    [JsonIgnore]
    [XmlElement("Parameters")]
    [ProtoMember(203)]
    public Parameters ParametersXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Parameters Parameters
    {
        get => ParametersXml ??= new();
        set
        {
            ParametersXml = value;
            if (ParametersXml != null)
                ParametersXml.Parent = this;
        }
    }

    #endregion

    #region Options

    [JsonIgnore]
    [XmlElement("Options")]
    [ProtoMember(204)]
    public Options OptionsXml { get; set; }

    [XmlIgnore]
    [JsonProperty("options")]
    public Options Options
    {
        get => OptionsXml ??= new();
        set
        {
            OptionsXml = value;
            if (OptionsXml != null)
                OptionsXml.Parent = this;
        }
    }

    #endregion

    #region TimeConstraints

    [JsonIgnore]
    [XmlElement("TimeConstraints")]
    [ProtoMember(205)]
    public TimeConstraints TimeConstraintsXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public TimeConstraints TimeConstraints
    {
        get => TimeConstraintsXml ??= new();
        set
        {
            TimeConstraintsXml = value;
            if (TimeConstraintsXml != null)
                TimeConstraintsXml.Parent = this;
        }
    }

    #endregion

    #region TimeConstraint

    [JsonIgnore]
    [XmlElement("TimeConstraint")]
    [ProtoMember(206)]
    public TimeConstraint TimeConstraintXml { get; set; }

    [XmlIgnore]
    [JsonProperty("timeConstaint")]
    public TimeConstraint TimeConstraint
    {
        get => TimeConstraintXml ??= new();
        set
        {
            TimeConstraintXml = value;
            if (TimeConstraintXml != null)
                TimeConstraintXml.Parent = this;
        }
    }

    #endregion

    #region Orders

    [JsonIgnore]
    [XmlElement("Orders")]
    [ProtoMember(207)]
    public Orders OrdersXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Orders Orders
    {
        get => OrdersXml ??= new();
        set
        {

            OrdersXml = value;
            if (OrdersXml != null)
                OrdersXml.Parent = this;
        }
    }

    #endregion

    #region Groups

    [JsonIgnore]
    [XmlElement("Groups")]
    [ProtoMember(208)]
    public Groups GroupsXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Groups Groups
    {
        get => GroupsXml ??= new();
        set
        {
            GroupsXml = value;
            if (GroupsXml != null)
                GroupsXml.Parent = this;
        }
    }

    #endregion

    #region Paging

    [JsonIgnore]
    [XmlElement("Paging")]
    [ProtoMember(209)]
    public Paging PagingXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Paging Paging
    {
        get => PagingXml ??= new();
        set
        {
            PagingXml = value;
            if (PagingXml != null)
                PagingXml.Parent = value;
        }
    }

    #endregion

    #region SystemOptions

    [JsonIgnore]
    [XmlElement("System")]
    [ProtoMember(210)]
    public SystemOptions SystemOptionsXml { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public SystemOptions SystemOptions
    {
        get => SystemOptionsXml ??= new();
        set
        {
            SystemOptionsXml = value;
            if (SystemOptionsXml != null)
                SystemOptionsXml.Parent = this;
        }
    }

    #endregion

    #region Transfer

    [JsonIgnore]
    [XmlElement("Transfer")]
    [ProtoMember(211)]
    public Transfer TransferXml { get; set; }


    [JsonIgnore]
    [XmlIgnore]
    public Transfer Transfer
    {
        get => TransferXml ??= new();
        set
        {
            TransferXml = value;
            if (TransferXml != null)
                TransferXml.Parent = this;
        }
    }

    #endregion
}