using System.Collections;

namespace Ois.Plus.ObjectModel;

/// <summary>
/// Интерфейс объявляющий индексатор
/// Индексатор должен возвращать значение аттрибута по его имени
/// Предполгается что объект реалиующий интерфейс отражает узел xml документа
/// </summary>
public interface IAttributeIndexer
{
    /// <summary>
    /// Возвращает значение аттрибута по его имени
    /// </summary>
    /// <param name="attributeName">Имя атрибута</param>
    /// <returns>Значение</returns>
    string this[string attributeName] { get; set; }
}

/// <summary>
/// Объект для поиска объекта по значению
/// определного аттрибута
/// </summary>
/// <typeparam name="T">Объект должен реализовать интерфейс IAttributeIndexer</typeparam>
public class AttributeSearch<T>(string attributeName, List<T> itemList) : IEnumerable<T> where T : IAttributeIndexer
{
    private readonly string attribute = Attributes.Low(attributeName);

    /// <summary>
    /// Находит первый объект из списка со значением аттрибута равным value
    /// </summary>
    /// <param name="value">Значение аттрибута которое нужно найти</param>
    /// <returns>Объект или null если он не найден</returns>
    public T this[string value]
    {
        get
        {
            if (itemList == null) return default;
            foreach (T item in this)
            {
                if (item[attribute] == value) return item;
            }
            return default;
        }
    }

    public List<T> FindAll(string value)
    {
        List<T> list = [];
        if (itemList == null) return list;
        foreach (T item in this)
        {
            if (item[attribute] == value)
                list.Add(item);
        }
        return list;
    }

    public T Find(string attributeName, string value)
    {
        if (itemList == null) return default;
        attributeName = Attributes.Low(attributeName);
        foreach (T item in this)
        {
            if (item[attributeName] == value) return item;
        }
        return default;
    }

    #region IEnumerable<T> Members

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return itemList.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        return itemList.GetEnumerator();
    }

    #endregion
}

/// <summary>
/// Интерфейс объявляющий индексатор
/// Индексатор должен возвращать объект способный находить
/// объекты по значениею определенного аттрибута
/// </summary>
public interface IAttributeSearch<T> where T : IAttributeIndexer
{
    AttributeSearch<T> SearchByAttribute(ItemAttribute itemAttribute);
}

public class ItemSearch<T>(List<T> items) where T : IAttributeIndexer
{
    /// <summary>
    /// Возвращает объект для поиска
    /// объектов по значениею аттрбута
    /// </summary>
    public AttributeSearch<T> this[string attributeName] => new(attributeName, items);
}

public class ChildSearch(Item item, List<Item> items)
{
    /// <summary>
    /// Поиск элемента по значениею аттрибута PID
    /// Обходит все элементы включая дочерние
    /// </summary>
    /// <param name="propertyID">Значениею аттрибута PID</param>
    /// <returns>Элемент для указанного свойства или null</returns>
    public Item this[string propertyID] => Find(item, items, (i) => i.pId == propertyID);

    /// <summary>
    /// Поиск элемента по указанному аттрибуту и его значениею
    /// Обходит все элементы включая дочерние
    /// </summary>
    /// <param name="attribute">Имя аттрибута</param>
    /// <param name="attributeValue">Значение аттрибута</param>
    /// <returns>Возвращает первый найденный объект</returns>
    public Item Find(string attribute, string attributeValue)
    {
        attribute = Attributes.Low(attribute);
        return Find(item, items, (i) => i[attribute] == attributeValue);
    }

    public Item Find(Predicate<Item> match) => Find(item, items, match);

    private static Item Find(Item item, IEnumerable<Item> items, Predicate<Item> match)
    {
        if (items == null) return null;

        foreach (Item i in items)
        {
            i.Parent = item;
            if (match(i)) return i;

            Item f = null;
            if (i.ItemsXml != null)
                f = Find(i, [.. i.ItemsXml], match);
            if (f != null) return f;
        }
        return null;
    }

    /// <summary>
    /// Обходит все элементы и возвращает список
    /// элементов для которых match вернул true
    /// </summary>
    /// <param name="match">Функция определяющает добавлять
    /// или нет элемент Item в результирующий список</param>
    /// <returns>Список найденных элементов</returns>
    /// <example>
    /// string attribute="CID", attributeValue="83";
    /// Item.FindAll((i) => i[attribute] == attributeValue);
    ///  </example>
    public List<Item> FindAll(Predicate<Item> match)
    {
        List<Item> res = [];
        FindAll(res, item, items, match);
        return res;
    }

    /// <summary>
    /// Обходит все элементы и возвращает список
    /// элементов у которых занчение аттрибута с именем
    /// attribute равно значению attributeValue
    /// </summary>
    /// <param name="attribute">Имя аттрибута</param>
    /// <param name="attributeValue">Значение аттрибута</param>
    /// <returns>Список найденных элементов</returns>
    public List<Item> FindAll(string attribute, string attributeValue)
    {
        List<Item> res = [];
        attribute = Attributes.Low(attribute);
        FindAll(res, item, items, (i) => ((IAttributeIndexer)i)[attribute] == attributeValue);

        return res;
    }

    private static void FindAll(ICollection<Item> res, Item item, IEnumerable<Item> items, Predicate<Item> match)
    {
        if (items == null) return;

        foreach (Item i in items)
        {
            i.Parent = item;
            if (match(i))
                res.Add(i);
            if (i.ItemsXml != null)
                FindAll(res, i, [.. i.ItemsXml], match);
        }
    }
}

public enum ItemAttribute
{
    LmName, CName, CID, PName, PID, F, ID, Name, OldF, RC, DV, Alias
}

internal enum ClassAttribute
{
    ID, LmName, Name, ParentClassID, Source
}

internal enum PropertyAttribute
{
    ID, LmName, Name, IsObject, DType, Kind, CKind, Source
}

internal enum AliasAttribute
{
    ID, Name, OrderBy, CID, PID
}

internal class LowString(char[] value)
{
    public string s = new(value);
}