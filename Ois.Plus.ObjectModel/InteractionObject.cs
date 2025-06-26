using Newtonsoft.Json;
using ProtoBuf;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// 250 .. 299

namespace Ois.Plus.ObjectModel;

[DebuggerDisplay("{GetType()}")]
[Serializable]
[ProtoContract]
[ProtoInclude(250, typeof(Query))]
[ProtoInclude(251, typeof(Objects))]
[ProtoInclude(252, typeof(Item))]
[ProtoInclude(253, typeof(Parameters))]
[ProtoInclude(254, typeof(Parameter))]
[ProtoInclude(255, typeof(Condition))]
[ProtoInclude(256, typeof(Options))]
[ProtoInclude(257, typeof(Paging))]
[ProtoInclude(258, typeof(SystemOptions))]
[ProtoInclude(259, typeof(ExceptionItem))]
[ProtoInclude(260, typeof(CInfo))]
[ProtoInclude(261, typeof(PInfo))]
[ProtoInclude(262, typeof(Classes))]
[ProtoInclude(263, typeof(Properties))]
[ProtoInclude(264, typeof(Uom))]
[ProtoInclude(265, typeof(Group))]
[ProtoInclude(266, typeof(TimeConstraint))]
[ProtoInclude(267, typeof(StatRow))]
[ProtoInclude(268, typeof(Transfer))]
[ProtoInclude(269, typeof(Keys))]
[ProtoInclude(270, typeof(TimeConstraints))]
[ProtoInclude(271, typeof(RawData))]
[ProtoInclude(272, typeof(IntervalData))]
[ProtoInclude(273, typeof(WorkTables))]
[ProtoInclude(274, typeof(MetaInformation))]
[ProtoInclude(275, typeof(ParamQuery))]
[ProtoInclude(276, typeof(Format))]
[ProtoInclude(277, typeof(PropInfo))]
[ProtoInclude(278, typeof(Order))]
[ProtoInclude(279, typeof(Orders))]
[ProtoInclude(280, typeof(ViewFlags))]
[ProtoInclude(281, typeof(FuncParameter))]
[ProtoInclude(282, typeof(ValueItem))]
[ProtoInclude(283, typeof(AggInfo))]
[ProtoInclude(284, typeof(WorkResult))]
[ProtoInclude(285, typeof(ProcessItem))]
[ProtoInclude(286, typeof(ModifiedRes))]
public class InteractionObject : Attributes, IParent
{
    private static string ChangeEncoding(string xml)
    {
        int pos = xml.IndexOf("encoding=\"", StringComparison.OrdinalIgnoreCase);
        int pos2 = 0;
        if (pos < 0)
        {
            pos = xml.IndexOf("encoding='", StringComparison.OrdinalIgnoreCase);
            if (pos > 0)
                pos2 = xml.IndexOf('\'', pos + "encoding='".Length);
        }
        else
            pos2 = xml.IndexOf('"', pos + "encoding=\"".Length);
        if (pos > 0 && pos2 > pos)
        {
            pos += "encoding='".Length;
            xml = xml.Remove(pos, pos2 - pos);
            xml = xml.Insert(pos, "utf-8");
        }
        return xml;
    }

    private static object LoadStream(Stream ms, Type type)
    {
        XmlSerializer sr = new(type);
        return sr.Deserialize(ms);
    }

    /// <summary>
    /// Кодировка по умолчанию
    /// </summary>
    private static Encoding EncodingDefault => Encoding.UTF8;

    #region Десериализация объекта

    /// <summary>
    /// Загрузить объектную модель из Xml
    /// </summary>
    public static T LoadFrom<T>(string xml)
    {
        xml = ChangeEncoding(xml);
        return (T)Deserialize(xml, typeof(T), EncodingDefault);
    }

    /// <summary>
    /// Десериализация объекта в указанной кодировке с приведением к нужному типу
    /// </summary>
    public static T LoadFrom<T>(string xml, Encoding encoding) => (T)Deserialize(xml, typeof(T), encoding);

    /// <summary>
    /// Загрузить объектную модель из потока
    /// </summary>
    public static T LoadFrom<T>(Stream stream)
    {
        stream.Position = 0;
        return Serializer.Deserialize<T>(stream);
    }

    /// <summary>
    /// Загрузить объектную модель из массива байтов
    /// </summary>
    public static T LoadFrom<T>(byte[] bytes)
    {
        using MemoryStream ms = new(bytes, 0, bytes.Length);
        return Serializer.Deserialize<T>(ms);
    }

    /// <summary>
    /// Загрузить объектную модель из Xml
    /// </summary>
    public static T LoadFromFile<T>(string fileName, Encoding encoding)
    {
        string xml = File.ReadAllText(fileName, encoding);
        xml = ChangeEncoding(xml);
        return (T)Deserialize(xml, typeof(T), EncodingDefault);
    }

    /// <summary>
    /// Десериализация объекта с приведением к нужному типу.
    /// </summary>
    public static bool TryLoadFrom<T>(string xml, out T result)
    {
        try
        {
            xml = ChangeEncoding(xml);
            result = (T)Deserialize(xml, typeof(T), EncodingDefault);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Десериализация объекта в указанной кодировке
    /// </summary>
    private static object Deserialize(string xml, Type type, Encoding encoding)
    {
        using MemoryStream ms = new();
        byte[] buf = encoding.GetBytes(xml);
        ms.Write(buf, 0, buf.Length);
        ms.Position = 0;
        return LoadStream(ms, type);
    }

    #endregion

    #region Сериализация объекта в строку

    /// <summary>
    /// Сериализация объекта
    /// </summary>
    public string ToString(Encoding encoding) => Serialize(encoding);

    /// <summary>
    /// Преобразовать объект в Xml
    /// </summary>
    public override string ToString() => Serialize(Encoding.GetEncoding("windows-1251"));

    /// <summary>
    /// Сериализация объекта в указанной кодировке
    /// </summary>
    private string Serialize(Encoding encoding)
    {
        if (encoding == null)
            return string.Empty;

        XmlSerializer sr = new(GetType());
        using MemoryStream ms = new();
        using XmlTextWriter writer = new(ms, encoding);
        sr.Serialize(writer, this);
        byte[] bytes = ms.ToArray();
        return encoding.GetString(bytes, 0, bytes.Length);
    }

    #endregion

    /// <summary>
    /// Преобразовать в поток
    /// </summary>
    public void ToStream(Stream stream) => Serializer.Serialize(stream, this);

    /// <summary>
    /// Преобразовать объект в массив байтов
    /// </summary>
    public byte[] ToBytes()
    {
        using MemoryStream ms = new();
        Serializer.Serialize(ms, this);
        return ms.ToArray();
    }

    /// <summary>
    /// Преобразовать в массив байтов со сжатием
    /// </summary>
    public byte[] ToBytesCompress()
    {
        using MemoryStream ms = new();
        using GZipStream gz = new(ms, CompressionMode.Compress);
        Serializer.Serialize(ms, this);
        gz.Close();
        return ms.ToArray();
    }

    /// <summary>
    /// Загрузить объектную модель из массива байтов со сжатием
    /// </summary>
    public static T LoadFromCompress<T>(byte[] bytes)
    {
        using MemoryStream ms = new(bytes);
        using GZipStream gz = new(ms, CompressionMode.Decompress);
        T result = Serializer.Deserialize<T>(ms);
        gz.Close();
        return result;
    }

    /// <summary>
    /// Клонирование объекта
    /// </summary>
    public T Clone<T>() => LoadFrom<T>(ToString());

    private static void Find<T>(HashSet<T> list, Func<T, bool> Selector, Func<object, IEnumerable<object>> Provider,
                         object context) where T : class
    {
        IEnumerable<object> objects = Provider(context);
        if (objects != null && objects.Any())
            foreach (object obj in objects)
            {
                if (obj is T @t && Selector(@t) && !list.Contains(@t))
                {
                    list.Add(@t);
                }
                Find(list, Selector, Provider, obj);
            }
    }

    public IEnumerable<T> Find<T>(Func<object, IEnumerable<object>> Provider, Func<T, bool> Selector)
        where T : class
    {
        if (Selector == null || Provider == null) return null;
        HashSet<T> list = [];
        if (this is T @t && Selector(@t) && !list.Contains(@t))
        {
            list.Add(@t);
        }
        Find(list, Selector, Provider, this);
        return list;
    }

    #region Parent Objects

    /// <summary>
    /// Обновить у дочерних объектов родителей
    /// </summary>
    public void RefreshParents() => SetParent(this);

    /// <summary>
    /// Установить родителя всем дочерним объектам
    /// </summary>
    private static void SetParent(object parent)
    {
        var queryResult = FindProvider.FindAllObjects(parent);
        foreach (object obj in queryResult)
        {
            if (obj is IParent child)
            {
                child.Parent = (InteractionObject)parent;
                SetParent(obj);
            }
        }
    }

    #endregion

    #region Implementation of IParent

    private InteractionObject _parent;

    [JsonIgnore]
    [XmlIgnore]
    public InteractionObject Parent
    {
        get => _parent;
        set
        {
            if (_parent != value)
                _parent = value;
        }
    }

    #endregion

    /// <summary>
    /// Несериализуемый объект, содержащий данные любого типа
    /// </summary>
    [XmlIgnore]
    public object Data { get; set; }

    /// <summary>
    /// Загрузить объектную модель из Xml
    /// </summary>
    public static InteractionObject LoadFromXml(string xml)
    {
        XmlSerializer2 xmlSerializer2 = new();
        InteractionObject result = xmlSerializer2.ParseXml(xml);
        return result;
    }

    public string SaveToXml()
    {
        XmlSerializer2 xmlSerializer2 = new();
        return xmlSerializer2.CreateXml(this, Encoding.GetEncoding("windows-1251"));
    }

    public string SaveToXml(Encoding encoding)
    {
        XmlSerializer2 xmlSerializer2 = new();
        return xmlSerializer2.CreateXml(this, encoding);
    }
}
