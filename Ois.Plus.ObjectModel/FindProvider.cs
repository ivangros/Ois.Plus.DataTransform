namespace Ois.Plus.ObjectModel;

public static class FindProvider
{
    /// <summary>
    /// Выборка всех дочерних объектов
    /// </summary>
    public static List<object> FindAllObjects(object obj)
    {
        List<object> result = [];
        void addIfNotNull(object val)
        {
            if (val is not null)
                result.Add(val);
        }
        if (obj is QueryResult queryResult)
        {
            addIfNotNull(queryResult.ClassesXml);
            addIfNotNull(queryResult.PropertiesXml);
            addIfNotNull(queryResult.StatisticsXml);
            addIfNotNull(queryResult.OptionsXml);
            addIfNotNull(queryResult.PagingXml);
            addIfNotNull(queryResult.TimeConstraintXml);
            addIfNotNull(queryResult.TimeConstraintXml);
            addIfNotNull(queryResult.ObjectsXml);
            addIfNotNull(queryResult.GroupsXml);
            addIfNotNull(queryResult.ParametersXml);
            addIfNotNull(queryResult.ConditionsXml);
            addIfNotNull(queryResult.OrdersXml);
            addIfNotNull(queryResult.SystemOptionsXml);
            addIfNotNull(queryResult.KeysXml);
            addIfNotNull(queryResult.TimeConstraintsXml);
        }
        else if (obj is Query query)
        {
            addIfNotNull(query.OptionsXml);
            addIfNotNull(query.PagingXml);
            addIfNotNull(query.TimeConstraintXml);
            addIfNotNull(query.TimeConstraintXml);
            addIfNotNull(query.ObjectsXml);
            addIfNotNull(query.GroupsXml);
            addIfNotNull(query.ParametersXml);
            addIfNotNull(query.ConditionsXml);
            addIfNotNull(query.OrdersXml);
            addIfNotNull(query.SystemOptionsXml);
            addIfNotNull(query.KeysXml);
            addIfNotNull(query.TimeConstraintsXml);
        }
        else if (obj is Classes classes)
        {
            if (classes.ItemsXml != null)
                result.AddRange([.. classes.ItemsXml]);
        }
        else if (obj is Properties properties)
        {
            if (properties.ItemsXml != null)
                result.AddRange([.. properties.ItemsXml]);
        }
        else if (obj is Objects objects)
        {
            if (objects.ItemsXml != null)
                result.AddRange(objects.ItemsXml);
        }
        else if (obj is Item item)
        {
            if (item.ItemsXml != null)
                result.AddRange(item.ItemsXml);
            if (item.KeysXml != null)
                result.AddRange(item.KeysXml);
            if (item.PropertiesXml != null)
                result.AddRange(item.PropertiesXml);
            addIfNotNull(item.ConditionsXml);
            addIfNotNull(item.TimeConstraintXml);
            addIfNotNull(item.OrdersXml);
        }
        return result;
    }
}
