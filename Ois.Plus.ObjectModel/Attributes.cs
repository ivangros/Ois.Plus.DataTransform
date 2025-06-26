using ProtoBuf;
using System.Xml;
using System.Xml.Serialization;

// ProtoBuf 1 ... 199

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
[ProtoInclude(90, typeof(InteractionObject))]
public class Attributes : IAttributeIndexer
{
    /// <summary>
    /// Для Xml-сериализации fff не нужны, значение не имеет миллисекунд
    /// </summary>
    private const string DateFormat = "dd.MM.yyyy HH:mm:ss";


    /// <summary>
    /// Для этой даты в возвращается пустое значение аттрибута при Xml сериализации
    /// </summary>
    private readonly DateTime EmptyDate = new(9, 9, 9);

    #region Attributes

    #region DataManager 100 - 200

    [XmlAttribute("PName")]
    [ProtoMember(100)]
    public string pName { get; set; }

    [XmlAttribute("PID")]
    [ProtoMember(101)]
    public string pId { get; set; }

    [XmlAttribute("ID")]
    public string id { get; set; }

    [XmlIgnore]
    [ProtoMember(102)]
    public ulong? Id
    {
        get
        {
            if (id == null)
                return null;
            if (id == string.Empty)
                return ulong.MinValue;
            _ = ulong.TryParse(id, out ulong t);
            return t;
        }
        set
        {
            if (value == null)
                id = null;
            else if (value == ulong.MinValue)
                id = string.Empty;
            else
            {
                id = value.ToString();
            }
        }
    }

    [ProtoMember(103)]
    [XmlAttribute("LmName")]
    public string lmName { get; set; }

    [XmlAttribute("Name")]
    [ProtoMember(104)]
    public string name { get; set; }

    [XmlAttribute("F")]
    [ProtoMember(105)]
    public string f { get; set; }

    [XmlAttribute("Alias")]
    [ProtoMember(106)]
    public string alias { get; set; }

    [XmlAttribute("CName")]
    [ProtoMember(107)]
    public string cName { get; set; }

    [XmlAttribute("CID")]
    [ProtoMember(108)]
    public string cId { get; set; }

    [XmlAttribute("ShortName")]
    [ProtoMember(109)]
    public string shortName { get; set; }

    [XmlAttribute("IsObject")]
    [ProtoMember(110)]
    public string isObject { get; set; }

    [XmlAttribute("DType")]
    [ProtoMember(111)]
    public string dType { get; set; }

    [XmlAttribute("Kind")]
    [ProtoMember(112)]
    public string kind { get; set; }

    [XmlAttribute("CKind")]
    [ProtoMember(113)]
    public string cKind { get; set; }

    [XmlAttribute("ParentClassID")]
    [ProtoMember(114)]
    public string parentClassID { get; set; }

    [XmlAttribute("Source")]
    [ProtoMember(115)]
    public string source { get; set; }

    [XmlAttribute("DefUom")]
    [ProtoMember(116)]
    public string defUom { get; set; }

    [XmlAttribute("DefUName")]
    [ProtoMember(117)]
    public string defUName { get; set; }

    [XmlAttribute("Error")]
    [ProtoMember(118)]
    public string error { get; set; }

    [XmlAttribute("HasData")]
    [ProtoMember(119)]
    public string hasData { get; set; }

    [XmlAttribute("DataMode")]
    [ProtoMember(120)]
    public string dataMode { get; set; }

    [XmlAttribute("OldID")]
    [ProtoMember(121)]
    public string oldId { get; set; }

    [XmlAttribute("Enabled")]
    [ProtoMember(122)]
    public string enabled { get; set; }

    [XmlAttribute("DV")]
    [ProtoMember(123)]
    public string dv { get; set; }

    [XmlAttribute("NS")]
    [ProtoMember(124)]
    public string ns { get; set; }

    [XmlAttribute("Value")]
    [ProtoMember(125)]
    public string value { get; set; }

    [XmlAttribute("UseDefault")]
    [ProtoMember(126)]
    public string useDefault { get; set; }

    [XmlAttribute("IntervalType")]
    [ProtoMember(127)]
    public string intervalType { get; set; }

    [XmlAttribute("StartTime")]
    [ProtoMember(128)]
    public string startTime { get; set; }

    [XmlAttribute("EndTime")]
    [ProtoMember(129)]
    public string endTime { get; set; }

    [ProtoMember(130)]
    [XmlIgnore]
    public DateTime? STime { get; set; }

    [XmlAttribute("STime")]
    public string sTime
    {
        get
        {
            if (STime.HasValue)
            {
                if (STime == EmptyDate)
                    return string.Empty;
                return STime.Value.ToString(DateFormat);
            }
            return null;
        }
        set
        {
            if (value == string.Empty)
                STime = EmptyDate;
            else
            {
                if (DateTime.TryParse(value, out DateTime d))
                    STime = d;
            }
        }
    }

    [XmlIgnore]
    [ProtoMember(131)]
    public DateTime? ETime { get; set; }

    [XmlAttribute("ETime")]
    public string eTime
    {
        get
        {
            if (ETime.HasValue)
            {
                if (ETime == EmptyDate)
                    return string.Empty;
                return ETime.Value.ToString(DateFormat);
            }
            return null;
        }
        set
        {
            if (value == string.Empty)
                ETime = EmptyDate;
            else
            {
                if (DateTime.TryParse(value, out DateTime d))
                    ETime = d;
            }
        }
    }

    [XmlAttribute("Uom")]
    [ProtoMember(132)]
    public string uom { get; set; }

    [XmlAttribute("UName")]
    [ProtoMember(133)]
    public string uName { get; set; }

    [XmlAttribute("OldF")]
    [ProtoMember(134)]
    public string oldF { get; set; }

    [XmlAttribute("Distinct")]
    [ProtoMember(135)]
    public string distinct { get; set; }

    [XmlAttribute("RegisteredValue")]
    [ProtoMember(136)]
    public string registeredValue { get; set; }

    [XmlAttribute("Stat")]
    [ProtoMember(137)]
    public string stat { get; set; }

    [XmlAttribute("NameMode")]
    [ProtoMember(138)]
    public string nameMode { get; set; }

    [XmlAttribute("Properties")]
    [ProtoMember(139)]
    public string prop { get; set; }

    [XmlAttribute("DoCount")]
    [ProtoMember(140)]
    public string doCount { get; set; }

    [XmlAttribute("ParamType")]
    [ProtoMember(141)]
    public string paramType { get; set; }

    [XmlAttribute("Time")]
    [ProtoMember(142)]
    public string time { get; set; }

    [XmlAttribute("NumberSorting")]
    [ProtoMember(143)]
    public string numberSorting { get; set; }

    [XmlAttribute("ForInsert")]
    [ProtoMember(144)]
    public string forInsert { get; set; }

    [XmlAttribute("NoRows")]
    [ProtoMember(145)]
    public string noRows { get; set; }

    [XmlAttribute("InfoNS")]
    [ProtoMember(146)]
    public string infoNS { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("ProtectedMode")]
    [ProtoMember(147)]
    public string protectedMode { get; set; }

    [XmlAttribute("NoInfo")]
    [ProtoMember(148)]
    public string noInfo { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("AutoBinding")]
    [ProtoMember(149)]
    public string autoBinding { get; set; }

    [XmlAttribute("Hint")]
    [ProtoMember(150)]
    public string hint { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("UseInTable")]
    [ProtoMember(151)]
    public string useInTable { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("NotMarkClass2")]
    [ProtoMember(152)]
    public string notMarkClass2 { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("NotMarkClass")]
    [ProtoMember(153)]
    public string notMarkClass { get; set; }

    [XmlAttribute("TimeZone")]
    [ProtoMember(154)]
    public string timeZone { get; set; }

    [XmlAttribute("RC")]
    [ProtoMember(155)]
    public string rc { get; set; }

    [XmlAttribute("Algorithm")]
    [ProtoMember(156)]
    public string algorithm { get; set; }

    [XmlAttribute("Item")]
    [ProtoMember(157)]
    public string item { get; set; }

    [XmlAttribute("Desc")]
    [ProtoMember(158)]
    public string desc { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("IsNull")]
    [ProtoMember(159)]
    public string isNull { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("PropertyMark")]
    [ProtoMember(160)]
    public string propertyMark { get; set; }

    /// <summary>
    /// Подлежит удалению
    /// </summary>
    [XmlAttribute("NotMarkClass1")]
    [ProtoMember(161)]
    public string notMarkClass1 { get; set; }

    [XmlAttribute("RefName")]
    [ProtoMember(162)]
    public string refName { get; set; }

    [XmlAttribute("Acronym")]
    [ProtoMember(163)]
    public string acronym { get; set; }

    [XmlAttribute("IsRefCode")]
    [ProtoMember(164)]
    public string isRefCode { get; set; }

    [XmlAttribute("Description")]
    [ProtoMember(165)]
    public string description { get; set; }

    [XmlAttribute("ExceptForItem")]
    [ProtoMember(166)]
    public string exceptForItem { get; set; }

    [XmlAttribute("ElementRule")]
    [ProtoMember(167)]
    public string elementRule { get; set; }

    [XmlAttribute("SupEnabled")]
    [ProtoMember(168)]
    public string supEnabled { get; set; }

    [XmlAttribute("SecurityEnabled")]
    [ProtoMember(169)]
    public string securityEnabled { get; set; }

    [XmlAttribute("OptionsString")]
    [ProtoMember(170)]
    public string optionsString { get; set; }

    [XmlAttribute("SecurityRoles")]
    [ProtoMember(171)]
    public string securityRoles { get; set; }

    [XmlAttribute("UseSysRole")]
    [ProtoMember(172)]
    public string useSysRole { get; set; }

    [XmlAttribute("Path")]
    [ProtoMember(173)]
    public string path { get; set; }

    [XmlAttribute("Pattern")]
    [ProtoMember(174)]
    public string pattern { get; set; }

    [XmlAttribute("Alignment")]
    [ProtoMember(175)]
    public string alignment { get; set; }

    [XmlAttribute("RowOrder")]
    [ProtoMember(176)]
    public string rowOrder { get; set; }

    [XmlAttribute("RowNumber")]
    [ProtoMember(177)]
    public string rowNumber { get; set; }

    [XmlAttribute("AliasWithEntity")]
    [ProtoMember(178)]
    public string aliasWithEntity { get; set; }

    [XmlAttribute("Logic")]
    [ProtoMember(179)]
    public string logic { get; set; }

    [XmlAttribute("Operand1")]
    [ProtoMember(180)]
    public string operand1 { get; set; }

    [XmlAttribute("Operator")]
    [ProtoMember(181)]
    public string @operator { get; set; }

    [XmlAttribute("Operand2")]
    [ProtoMember(182)]
    public string operand2 { get; set; }

    [XmlAttribute("PageNumber")]
    [ProtoMember(183)]
    public string pageNumber { get; set; }

    [XmlAttribute("PageSize")]
    [ProtoMember(184)]
    public string pageSize { get; set; }

    [XmlAttribute("ObjectLimit")]
    [ProtoMember(185)]
    public string objectLimit { get; set; }

    [XmlAttribute("ObjectCount")]
    [ProtoMember(186)]
    public string objectCount { get; set; }

    [XmlAttribute("PageCount")]
    [ProtoMember(187)]
    public string pageCount { get; set; }

    [XmlAttribute("QueryLevel")]
    [ProtoMember(188)]
    public string queryLevel { get; set; }

    [XmlAttribute("QueryID")]
    [ProtoMember(189)]
    public string queryID { get; set; }

    [XmlAttribute("Direction")]
    [ProtoMember(190)]
    public string direction { get; set; }

    [XmlAttribute("Level")]
    [ProtoMember(191)]
    public string level { get; set; }

    [XmlAttribute("Rule")]
    [ProtoMember(192)]
    public string rule { get; set; }

    [XmlAttribute("ViewName")]
    [ProtoMember(193)]
    public string viewName { get; set; }

    [XmlAttribute("CardinalityKind")]
    [ProtoMember(194)]
    public string cardinalityKind { get; set; }

    [XmlAttribute("ClassA")]
    [ProtoMember(195)]
    public string classA { get; set; }

    [XmlAttribute("ClassB")]
    [ProtoMember(196)]
    public string classB { get; set; }

    [XmlAttribute("Association")]
    [ProtoMember(197)]
    public string association { get; set; }

    [XmlAttribute("A1")]
    [ProtoMember(198)]
    public string a1 { get; set; }

    [XmlAttribute("A2")]
    [ProtoMember(199)]
    public string a2 { get; set; }

    #endregion

    #region DataManager 70 - 99

    [XmlAttribute("Func")]
    [ProtoMember(70)]
    public string func { get; set; }

    [XmlAttribute("Func1")]
    [ProtoMember(71)]
    public string func1 { get; set; }

    [XmlAttribute("Func2")]
    [ProtoMember(72)]
    public string func2 { get; set; }

    [XmlAttribute("Func3")]
    [ProtoMember(73)]
    public string func3 { get; set; }

    #endregion

    #region QueryManager 1 - 35

    [XmlAttribute("duaName")]
    [ProtoMember(1)]
    public string duaName { get; set; }

    [XmlAttribute("OBJName")]
    [ProtoMember(2)]
    public string objName { get; set; }

    [XmlAttribute("SourceSystemName")]
    [ProtoMember(3)]
    public string sourceSystemName { get; set; }

    [XmlAttribute("DestinationSystemName")]
    [ProtoMember(4)]
    public string destinationSystemName { get; set; }

    [XmlIgnore]
    [ProtoMember(5)]
    public DateTime? RealSTime { get; set; }

    [XmlAttribute("RealSTime")]
    public string realSTime
    {
        get
        {
            if (RealSTime.HasValue)
            {
                if (RealSTime == EmptyDate)
                    return string.Empty;
                return RealSTime.Value.ToString(DateFormat);
            }
            return null;
        }
        set
        {
            if (value == string.Empty)
                RealSTime = EmptyDate;
            else
            {
                if (DateTime.TryParse(value, out DateTime d))
                    RealSTime = d;
            }
        }
    }

    [XmlIgnore]
    [ProtoMember(6)]
    public DateTime? RealETime { get; set; }

    [XmlAttribute("RealETime")]
    public string realETime
    {
        get
        {
            if (RealETime.HasValue)
            {
                if (RealETime == EmptyDate)
                    return string.Empty;
                return RealETime.Value.ToString(DateFormat);
            }
            return null;
        }
        set
        {
            if (value == string.Empty)
                RealETime = EmptyDate;
            else
            {
                if (DateTime.TryParse(value, out DateTime d))
                    RealETime = d;
            }
        }
    }

    [XmlAttribute("UID")]
    [ProtoMember(7)]
    public string uid { get; set; }

    [XmlAttribute("ObjCount")]
    [ProtoMember(8)]
    public string objCount { get; set; }

    [XmlAttribute("ItemCount")]
    [ProtoMember(9)]
    public string itemCount { get; set; }

    [XmlAttribute("DestItemName")]
    [ProtoMember(10)]
    public string destItemName { get; set; }

    [XmlAttribute("duaFuncName")]
    [ProtoMember(11)]
    public string duaFuncName { get; set; }

    [XmlAttribute("UomAcronim")]
    [ProtoMember(12)]
    public string uomAcronim { get; set; }

    [XmlAttribute("Recoded")]
    [ProtoMember(13)]
    public string recoded { get; set; }

    [XmlAttribute("Visible")]
    [ProtoMember(14)]
    public string visible { get; set; }

    [XmlAttribute("CheckNS")]
    [ProtoMember(15)]
    public string checkNS { get; set; }

    [XmlAttribute("stepName")]
    [ProtoMember(16)]
    public string stepName { get; set; }

    [XmlAttribute("stepCount")]
    [ProtoMember(17)]
    public string stepCount { get; set; }

    [XmlAttribute("stepAverage")]
    [ProtoMember(18)]
    public string stepAverage { get; set; }

    [XmlAttribute("stepSummaryTime")]
    [ProtoMember(19)]
    public string stepSummaryTime { get; set; }

    [XmlAttribute("PropHash")]
    [ProtoMember(20)]
    public string propHash { get; set; }

    [XmlAttribute("Type")]
    [ProtoMember(21)]
    public string queryType { get; set; }

    [XmlAttribute("DataType")]
    [ProtoMember(22)]
    public string dataType { get; set; }

    [XmlAttribute("Length")]
    [ProtoMember(23)]
    public string length { get; set; }

    [XmlAttribute("Precision")]
    [ProtoMember(24)]
    public string precision { get; set; }

    [XmlAttribute("IsKey")]
    [ProtoMember(25)]
    public string isKey { get; set; }

    [XmlAttribute("Order")]
    [ProtoMember(26)]
    public string order { get; set; }

    [XmlAttribute("Intervals")]
    [ProtoMember(27)]
    public string intervals { get; set; }

    [XmlAttribute("RawData")]
    [ProtoMember(28)]
    public string rawData { get; set; }

    [XmlAttribute("WorkTables")]
    [ProtoMember(29)]
    public string workTables { get; set; }

    [XmlAttribute("GroupID")]
    [ProtoMember(30)]
    public string groupId { get; set; }

    [XmlAttribute("Out")]
    [ProtoMember(31)]
    public string @out { get; set; }

    [XmlAttribute("AggType")]
    [ProtoMember(32)]
    public string aggType { get; set; }

    [XmlAttribute("AggTypeClassName")]
    [ProtoMember(33)]
    public string aggTypeClassName { get; set; }

    [XmlAttribute("AggFromQuery")]
    [ProtoMember(34)]
    public string aggFromQuery { get; set; }

    [XmlAttribute("ID_Value")]
    [ProtoMember(35)]
    public string idValue { get; set; }

    #endregion

    #region UpdateManager 50 - 55

    [XmlAttribute("PtyName")]
    [ProtoMember(50)]
    public string ptyName { get; set; }

    [XmlAttribute("HasValue")]
    [ProtoMember(51)]
    public string hasValue { get; set; }

    [XmlAttribute("ResourceRequired")]
    [ProtoMember(52)]
    public string resourceRequired { get; set; }

    [XmlAttribute("Flag")]
    [ProtoMember(53)]
    public string flag { get; set; }

    [XmlAttribute("Result")]
    [ProtoMember(54)]
    public string result { get; set; }

    [XmlAttribute("ProcessName")]
    [ProtoMember(55)]
    public string processName { get; set; }

    #endregion

    #region ProcessManager 60 - 63

    [XmlAttribute("STConstraint")]
    [ProtoMember(60)]
    public string stConstraint { get; set; }

    [XmlAttribute("ResName")]
    [ProtoMember(61)]
    public string resName { get; set; }

    [XmlAttribute("ProcName")]
    [ProtoMember(62)]
    public string procName { get; set; }

    [XmlAttribute("ResId")]
    [ProtoMember(63)]
    public string resId { get; set; }

    #endregion

    #endregion

    private QueryAttribute _attribute;

    [XmlIgnore]
    public QueryAttribute Attribute => _attribute ??= new(attribute);

    [XmlAnyAttribute]
    [NonSerialized]
    public List<XmlAttribute> attribute;

    public string this[string attributeName]
    {
        get
        {
            attributeName = ToLower(attributeName);

            string r;
            switch (attributeName)
            {
                #region DataManager

                case "pname":
                    r = pName;
                    break;
                case "pid":
                    r = pId;
                    break;
                case "id":
                    r = id;
                    break;
                case "lmname":
                    r = lmName;
                    break;
                case "name":
                    r = name;
                    break;
                case "f":
                    r = f;
                    break;
                case "alias":
                    r = alias;
                    break;
                case "cname":
                    r = cName;
                    break;
                case "cid":
                    r = cId;
                    break;
                case "shortname":
                    r = shortName;
                    break;
                case "isobject":
                    r = isObject;
                    break;
                case "dtype":
                    r = dType;
                    break;
                case "kind":
                    r = kind;
                    break;
                case "ckind":
                    r = cKind;
                    break;
                case "parentclassid":
                    r = parentClassID;
                    break;
                case "source":
                    r = source;
                    break;
                case "defuom":
                    r = defUom;
                    break;
                case "defuname":
                    r = defUName;
                    break;
                case "error":
                    r = error;
                    break;
                case "hasdata":
                    r = hasData;
                    break;
                case "datamode":
                    r = dataMode;
                    break;
                case "oldid":
                    r = oldId;
                    break;
                case "enabled":
                    r = enabled;
                    break;
                case "dv":
                    r = dv;
                    break;
                case "ns":
                    r = ns;
                    break;
                case "value":
                    r = value;
                    break;
                case "id_value":
                    r = idValue;
                    break;
                case "usedefault":
                    r = useDefault;
                    break;
                case "intervaltype":
                    r = intervalType;
                    break;
                case "starttime":
                    r = startTime;
                    break;
                case "endtime":
                    r = endTime;
                    break;
                case "stime":
                    r = sTime;
                    break;
                case "etime":
                    r = eTime;
                    break;
                case "uom":
                    r = uom;
                    break;
                case "uname":
                    r = uName;
                    break;
                case "oldf":
                    r = oldF;
                    break;
                case "distinct":
                    r = distinct;
                    break;
                case "registeredvalue":
                    r = registeredValue;
                    break;
                case "stat":
                    r = stat;
                    break;
                case "namemode":
                    r = nameMode;
                    break;
                case "properties":
                    r = prop;
                    break;
                case "docount":
                    r = doCount;
                    break;
                case "paramtype":
                    r = paramType;
                    break;
                case "time":
                    r = time;
                    break;
                case "numbersorting":
                    r = numberSorting;
                    break;
                case "forinsert":
                    r = forInsert;
                    break;
                case "norows":
                    r = noRows;
                    break;
                case "infons":
                    r = infoNS;
                    break;
                case "protectedmode":
                    r = protectedMode;
                    break;
                case "noinfo":
                    r = noInfo;
                    break;
                case "autobinding":
                    r = autoBinding;
                    break;
                case "hint":
                    r = hint;
                    break;
                case "useintable":
                    r = useInTable;
                    break;
                case "notmarkclass2":
                    r = notMarkClass2;
                    break;
                case "notmarkclass":
                    r = notMarkClass;
                    break;
                case "timezone":
                    r = timeZone;
                    break;
                case "rc":
                    r = rc;
                    break;
                case "algorithm":
                    r = algorithm;
                    break;
                case "item":
                    r = item;
                    break;
                case "desc":
                    r = desc;
                    break;
                case "isnull":
                    r = isNull;
                    break;
                case "propertymark":
                    r = propertyMark;
                    break;
                case "notmarkclass1":
                    r = notMarkClass1;
                    break;
                case "refname":
                    r = refName;
                    break;
                case "acronym":
                    r = acronym;
                    break;
                case "isrefcode":
                    r = isRefCode;
                    break;
                case "path":
                    r = path;
                    break;
                case "pattern":
                    r = pattern;
                    break;
                case "alignment":
                    r = alignment;
                    break;
                case "roworder":
                    r = rowOrder;
                    break;
                case "rownumber":
                    r = rowNumber;
                    break;
                case "logic":
                    r = logic;
                    break;
                case "operand1":
                    r = operand1;
                    break;
                case "operator":
                    r = @operator;
                    break;
                case "operand2":
                    r = operand2;
                    break;
                case "pagenumber":
                    r = pageNumber;
                    break;
                case "pagesize":
                    r = pageSize;
                    break;
                case "objectlimit":
                    r = objectLimit;
                    break;
                case "objectcount":
                    r = objectCount;
                    break;
                case "pagecount":
                    r = pageCount;
                    break;
                case "querylevel":
                    r = queryLevel;
                    break;
                case "description":
                    r = description;
                    break;
                case "elementrule":
                    r = elementRule;
                    break;
                case "exceptforitem":
                    r = exceptForItem;
                    break;
                case "queryid":
                    r = queryID;
                    break;
                case "optionsstring":
                    r = optionsString;
                    break;
                case "supenabled":
                    r = supEnabled;
                    break;
                case "direction":
                    r = direction;
                    break;
                case "level":
                    r = level;
                    break;
                case "securityroles":
                    r = securityRoles;
                    break;
                case "usesysrole":
                    r = useSysRole;
                    break;
                case "securityenabled":
                    r = securityEnabled;
                    break;
                case "rule":
                    r = rule;
                    break;
                case "viewname":
                    r = viewName;
                    break;
                case "cardinalitykind":
                    r = cardinalityKind;
                    break;
                case "classa":
                    r = classB;
                    break;
                case "classb":
                    r = classB;
                    break;
                case "association":
                    r = association;
                    break;
                case "a1":
                    r = a1;
                    break;
                case "a2":
                    r = a2;
                    break;
                case "func":
                    r = func;
                    break;
                case "func1":
                    r = func1;
                    break;
                case "func2":
                    r = func2;
                    break;
                case "func3":
                    r = func3;
                    break;

                #endregion

                #region QueryManager

                case "duaname":
                    r = duaName;
                    break;
                case "objname":
                    r = objName;
                    break;
                case "sourcesystemname":
                    r = sourceSystemName;
                    break;
                case "destinationsystemname":
                    r = destinationSystemName;
                    break;
                case "realstime":
                    r = realSTime;
                    break;
                case "realetime":
                    r = realETime;
                    break;
                case "uid":
                    r = uid;
                    break;
                case "objcount":
                    r = objCount;
                    break;
                case "itemcount":
                    r = itemCount;
                    break;
                case "destitemname":
                    r = destItemName;
                    break;
                case "duafuncname":
                    r = duaFuncName;
                    break;
                case "uomacronim":
                    r = uomAcronim;
                    break;
                case "recoded":
                    r = recoded;
                    break;
                case "visible":
                    r = visible;
                    break;
                case "checkns":
                    r = checkNS;
                    break;
                case "stepname":
                    r = stepName;
                    break;
                case "stepcount":
                    r = stepCount;
                    break;
                case "stepaverage":
                    r = stepAverage;
                    break;
                case "stepsummarytime":
                    r = stepSummaryTime;
                    break;
                case "prophash":
                    r = propHash;
                    break;
                case "type":
                    r = queryType;
                    break;
                case "datatype":
                    r = dataType;
                    break;
                case "length":
                    r = length;
                    break;
                case "precision":
                    r = precision;
                    break;
                case "iskey":
                    r = isKey;
                    break;
                case "order":
                    r = order;
                    break;
                case "groupid":
                    r = groupId;
                    break;
                case "out":
                    r = @out;
                    break;
                case "aggtype":
                    r = aggType;
                    break;
                case "aggtypeclassname":
                    r = aggTypeClassName;
                    break;
                case "aggfromquery":
                    r = aggFromQuery;
                    break;

                #endregion

                default:
                    return Attribute[attributeName];
            }

            if (string.IsNullOrEmpty(r))
                return Attribute[attributeName];
            return r;
        }
        set
        {
            attributeName = ToLower(attributeName);

            switch (attributeName)
            {
                #region DataManager

                case "pname":
                    pName = value;
                    break;
                case "pid":
                    pId = value;
                    break;
                case "id":
                    id = value;
                    break;
                case "lmname":
                    lmName = value;
                    break;
                case "name":
                    name = value;
                    break;
                case "f":
                    f = value;
                    break;
                case "alias":
                    alias = value;
                    break;
                case "cname":
                    cName = value;
                    break;
                case "cid":
                    cId = value;
                    break;
                case "shortname":
                    shortName = value;
                    break;
                case "isobject":
                    isObject = value;
                    break;
                case "dtype":
                    dType = value;
                    break;
                case "kind":
                    kind = value;
                    break;
                case "ckind":
                    cKind = value;
                    break;
                case "parentclassid":
                    parentClassID = value;
                    break;
                case "source":
                    source = value;
                    break;
                case "defuom":
                    defUom = value;
                    break;
                case "defuname":
                    defUName = value;
                    break;
                case "error":
                    error = value;
                    break;
                case "hasdata":
                    hasData = value;
                    break;
                case "datamode":
                    dataMode = value;
                    break;
                case "oldid":
                    oldId = value;
                    break;
                case "enabled":
                    enabled = value;
                    break;
                case "dv":
                    dv = value;
                    break;
                case "ns":
                    ns = value;
                    break;
                case "value":
                    this.value = value;
                    break;
                case "id_value":
                    this.idValue = value;
                    break;
                case "usedefault":
                    useDefault = value;
                    break;
                case "intervaltype":
                    intervalType = value;
                    break;
                case "starttime":
                    startTime = value;
                    break;
                case "endtime":
                    endTime = value;
                    break;
                case "stime":
                    sTime = value;
                    break;
                case "etime":
                    eTime = value;
                    break;
                case "uom":
                    uom = value;
                    break;
                case "uname":
                    uName = value;
                    break;
                case "oldf":
                    oldF = value;
                    break;
                case "distinct":
                    distinct = value;
                    break;
                case "registeredvalue":
                    registeredValue = value;
                    break;
                case "stat":
                    stat = value;
                    break;
                case "namemode":
                    nameMode = value;
                    break;
                case "properties":
                    prop = value;
                    break;
                case "docount":
                    doCount = value;
                    break;
                case "paramtype":
                    paramType = value;
                    break;
                case "time":
                    time = value;
                    break;
                case "numbersorting":
                    numberSorting = value;
                    break;
                case "forinsert":
                    forInsert = value;
                    break;
                case "norows":
                    noRows = value;
                    break;
                case "infons":
                    infoNS = value;
                    break;
                case "protectedmode":
                    protectedMode = value;
                    break;
                case "noinfo":
                    noInfo = value;
                    break;
                case "autobinding":
                    autoBinding = value;
                    break;
                case "hint":
                    hint = value;
                    break;
                case "useintable":
                    useInTable = value;
                    break;
                case "notmarkclass2":
                    notMarkClass2 = value;
                    break;
                case "notmarkclass":
                    notMarkClass = value;
                    break;
                case "timezone":
                    timeZone = value;
                    break;
                case "rc":
                    rc = value;
                    break;
                case "algorithm":
                    algorithm = value;
                    break;
                case "item":
                    item = value;
                    break;
                case "desc":
                    desc = value;
                    break;
                case "isnull":
                    isNull = value;
                    break;
                case "propertymark":
                    propertyMark = value;
                    break;
                case "nommarkclass1":
                    notMarkClass1 = value;
                    break;
                case "refname":
                    refName = value;
                    break;
                case "acronym":
                    acronym = value;
                    break;
                case "isrefcode":
                    isRefCode = value;
                    break;
                case "path":
                    path = value;
                    break;
                case "pattern":
                    pattern = value;
                    break;
                case "alignment":
                    alignment = value;
                    break;
                case "roworder":
                    rowOrder = value;
                    break;
                case "rownumber":
                    rowNumber = value;
                    break;
                case "logic":
                    logic = value;
                    break;
                case "operand1":
                    operand1 = value;
                    break;
                case "operator":
                    @operator = value;
                    break;
                case "operand2":
                    operand2 = value;
                    break;
                case "pagenumber":
                    pageNumber = value;
                    break;
                case "pagesize":
                    pageSize = value;
                    break;
                case "objectlimit":
                    objectLimit = value;
                    break;
                case "objectcount":
                    objectCount = value;
                    break;
                case "pagecount":
                    pageCount = value;
                    break;
                case "querylevel":
                    queryLevel = value;
                    break;
                case "description":
                    description = value;
                    break;
                case "elementrule":
                    elementRule = value;
                    break;
                case "exceptforitem":
                    exceptForItem = value;
                    break;
                case "queryid":
                    queryID = value;
                    break;
                case "optionsstring":
                    optionsString = value;
                    break;
                case "supenabled":
                    supEnabled = value;
                    break;
                case "direction":
                    direction = value;
                    break;
                case "level":
                    level = value;
                    break;
                case "securityroles":
                    securityRoles = value;
                    break;
                case "usesysrole":
                    useSysRole = value;
                    break;
                case "securityenabled":
                    securityEnabled = value;
                    break;
                case "rule":
                    rule = value;
                    break;
                case "viewname":
                    viewName = value;
                    break;
                case "cardinalitykind":
                    cardinalityKind = value;
                    break;
                case "classa":
                    classA = value;
                    break;
                case "classb":
                    classB = value;
                    break;
                case "association":
                    association = value;
                    break;
                case "a1":
                    a1 = value;
                    break;
                case "a2":
                    a2 = value;
                    break;
                case "func":
                    func = value;
                    break;
                case "func1":
                    func1 = value;
                    break;
                case "func2":
                    func2 = value;
                    break;
                case "func3":
                    func3 = value;
                    break;
                #endregion

                #region QueryManager

                case "duaname":
                    duaName = value;
                    break;
                case "objname":
                    objName = value;
                    break;
                case "sourcesystemname":
                    sourceSystemName = value;
                    break;
                case "destinationsystemname":
                    destinationSystemName = value;
                    break;
                case "realstime":
                    realSTime = value;
                    break;
                case "realetime":
                    realETime = value;
                    break;
                case "uid":
                    uid = value;
                    break;
                case "objcount":
                    objCount = value;
                    break;
                case "itemcount":
                    itemCount = value;
                    break;
                case "destitemname":
                    destItemName = value;
                    break;
                case "duafuncname":
                    duaFuncName = value;
                    break;
                case "uomacronim":
                    uomAcronim = value;
                    break;
                case "recoded":
                    recoded = value;
                    break;
                case "visible":
                    visible = value;
                    break;
                case "checkns":
                    checkNS = value;
                    break;
                case "stepname":
                    stepName = value;
                    break;
                case "stepcount":
                    stepCount = value;
                    break;
                case "stepaverage":
                    stepAverage = value;
                    break;
                case "stepsummarytime":
                    stepSummaryTime = value;
                    break;
                case "prophash":
                    propHash = value;
                    break;
                case "type":
                    queryType = value;
                    break;
                case "datatype":
                    dataType = value;
                    break;
                case "length":
                    length = value;
                    break;
                case "precision":
                    precision = value;
                    break;
                case "iskey":
                    isKey = value;
                    break;
                case "order":
                    order = value;
                    break;
                case "groupid":
                    groupId = value;
                    break;
                case "out":
                    @out = value;
                    break;
                case "aggtype":
                    aggType = value;
                    break;
                case "aggtypeclassname":
                    aggTypeClassName = value;
                    break;
                case "aggfromquery":
                    aggFromQuery = value;
                    break;

                    #endregion

            }
            if (attribute != null)
                foreach (XmlAttribute xmlAttribute in attribute)
                    if (xmlAttribute.Name.Equals(attributeName, StringComparison.OrdinalIgnoreCase))
                    {
                        xmlAttribute.Value = value;
                        return;
                    }
        }
    }

    internal static string ToLower(string attributeName)
    {
        int l = attributeName.Length;
        if (l == 0) return attributeName;
        if (attributeName[l - 1] == '\xffff')
            return attributeName.Remove(l - 1, 1);
        return Tolower(attributeName, l);
    }

    internal static string Low(string attributeName)
    {
        if (attributeName[^1] == '\xffff') return attributeName;
        return ToLower(attributeName) + '\xffff';
    }

    private static string Tolower(string attributeName, int l)
    {
        char[] t = new char[l];
        for (int i = 0; i < l; i++)
        {
            var t2 = attributeName[i] switch
            {
                'D' => 'd',
                'V' => 'v',
                'A' => 'a',
                'L' => 'l',
                'I' => 'i',
                'S' => 's',
                'E' => 'e',
                'T' => 't',
                'M' => 'm',
                'N' => 'n',
                'F' => 'f',
                'O' => 'o',
                'C' => 'c',
                'P' => 'p',
                'R' => 'r',
                'U' => 'u',
                'Q' => 'q',
                'W' => 'w',
                'Y' => 'y',
                'G' => 'g',
                'H' => 'h',
                'J' => 'j',
                'K' => 'k',
                'Z' => 'z',
                'X' => 'x',
                'B' => 'b',
                _ => attributeName[i],
            };
            t[i] = t2;
        }
        return new string(t);
    }

    [XmlIgnore]
    public DateTime StartTime
    {
        get
        {
            return ToDateTime(startTime);
        }
        set
        {
            try
            {
                startTime = value.ToString("dd.MM.yyyy");
                if (value.TimeOfDay.TotalSeconds > 0)
                    startTime += " " + value.ToString("HH:mm:ss");
            }
            catch { startTime = null; }
        }
    }

    [XmlIgnore]
    public DateTime EndTime
    {
        get
        {
            return ToDateTime(endTime);
        }
        set
        {
            try
            {
                endTime = value.ToString("dd.MM.yyyy");
                if (value.TimeOfDay.TotalSeconds > 0)
                    endTime += " " + value.ToString("HH:mm:ss");
            }
            catch { endTime = null; }
        }
    }


    public static DateTime ToDateTime(string dateTime)
    {
        if (string.IsNullOrEmpty(dateTime))
            return DateTime.MinValue;

        dateTime = dateTime.Trim();
        if (DateTime.TryParse(dateTime, out DateTime d)) return d;
        if (dateTime.Contains(' '))
        {
            string[] ss = dateTime.Split(" ".ToCharArray());
            dateTime = ss[0];
            DateTime p = DateTime.MinValue;
            if (DateTime.TryParse(dateTime, out d))
            {
                p = d;
                if (ss.Length > 1 && DateTime.TryParse(ss[1], out d))
                    p += d.TimeOfDay;
            }
            return p;

        }
        return DateTime.MinValue;
    }

}

[Serializable]
public class QueryAttribute
{
    private readonly Dictionary<string, XmlAttribute> dic = [];

    public QueryAttribute(IEnumerable<XmlAttribute> attribute)
    {
        if (attribute == null) return;
        foreach (XmlAttribute att in attribute)
            dic[Attributes.ToLower(att.Name)] = att;
    }

    public string this[string name]
    {
        get
        {
            name = name.ToLower();
            if (dic.TryGetValue(name, out XmlAttribute attr))
                return attr.Value;
            return string.Empty;
        }
        set
        {
            name = name.ToLower();
            if (dic.TryGetValue(name, out XmlAttribute attr))
                attr.Value = value;
        }
    }

    public bool ContainsKey(string name)
    {
        return dic.ContainsKey(name);
    }
}
