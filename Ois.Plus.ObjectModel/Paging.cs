using ProtoBuf;
using System.Xml.Serialization;

// 900 .. 949

namespace Ois.Plus.ObjectModel;

[Serializable, ProtoContract]
public class Paging : InteractionObject
{
    [XmlIgnore]
    public bool Enabled
    {
        get => !string.IsNullOrEmpty(enabled) && enabled.Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
        set
        {
            if (Enabled != value)
                enabled = value.ToString();
        }
    }

    [XmlIgnore]
    public int PageSize
    {
        get => !string.IsNullOrEmpty(pageSize) && int.TryParse(pageSize, out int result) ? result : 0;
        set
        {
            if (PageSize != value)
                pageSize = value.ToString();
        }
    }

    [XmlIgnore]
    public int PageNumber
    {
        get => !string.IsNullOrEmpty(pageNumber) && int.TryParse(pageNumber, out int result) ? result : 0;
        set
        {
            if (PageNumber != value)
                pageNumber = value.ToString();
        }
    }

    [XmlIgnore]
    public int ObjectLimit
    {
        get => !string.IsNullOrEmpty(objectLimit) && int.TryParse(objectLimit, out int result) ? result : 0;
        set
        {
            if (ObjectLimit != value)
                objectLimit = value.ToString();
        }
    }

    [XmlIgnore]
    public int PageCount
    {
        get => !string.IsNullOrEmpty(pageCount) && int.TryParse(pageCount, out int result) ? result : 0;
        set
        {
            if (PageCount != value)
                pageCount = value.ToString();
        }
    }
}