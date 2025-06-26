using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ois.Plus.ObjectModel;

public class XmlSerializer2
{
    public InteractionObject ParseXml(string queryXml)
    {
        interactionObject = null;
        using StringReader reader = new(queryXml);
        using XmlTextReader xmlReader = new(reader);
        stack.Clear();
        Parse(xmlReader);
        return interactionObject;
    }

    public InteractionObject ParseXml(byte[] queryXml)
    {
        interactionObject = null;
        using MemoryStream memoryStream = new(queryXml);
        using XmlTextReader xmlReader = new(memoryStream);
        stack.Clear();
        Parse(xmlReader);
        return interactionObject;
    }

    public string CreateXml(InteractionObject queryResult, Encoding encoding)
    {
        using MemoryStream stream = new();
        using XmlTextWriter writer = new(stream, encoding);
        writer.WriteStartDocument();
        Write(writer, queryResult);
        writer.WriteEndDocument();
        writer.Close();
        byte[] bytes = stream.ToArray();
        return encoding.GetString(bytes, 0, bytes.Length);
    }

    private readonly Stack<object> stack = new();

    private InteractionObject interactionObject;

    private void Parse(XmlTextReader reader)
    {
        bool isNotRead = false;

        while (!reader.EOF)
        {
            if (!isNotRead)
                reader.Read();
            else
                isNotRead = false;

            bool isEmptyElement = reader.IsEmptyElement;
            string name = reader.Name.ToLower();

            switch (reader.NodeType)
            {
                case XmlNodeType.Element:

                    if (name == "query")
                    {
                        Query it = new();
                        CreateRootObject(it, reader, isEmptyElement);
                    }
                    else if (name == "queryresult")
                    {
                        QueryResult it = new();
                        CreateRootObject(it, reader, isEmptyElement);
                    }
                    else if (name == "objects")
                    {
                        Objects it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Objects = it;
                            if (!isEmptyElement)
                                stack.Push(it);

                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Objects = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "item")
                    {
                        Item it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Objects objects)
                        {
                            ReadAttributes(reader, it);
                            objects.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is Item item)
                        {
                            ReadAttributes(reader, it);
                            item.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "conditions")
                    {
                        Conditions it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Item item)
                        {
                            ReadAttributes(reader, it);
                            item.Conditions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Conditions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Conditions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "classes")
                    {
                        Classes it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Classes = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "cinfo")
                    {
                        CInfo it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Classes classes)
                        {
                            ReadAttributes(reader, it);
                            classes.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "properties")
                    {
                        Properties it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Properties = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "pinfo")
                    {
                        PInfo it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Properties properties)
                        {
                            ReadAttributes(reader, it);
                            properties.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "condition")
                    {
                        Condition it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Condition condition)
                        {
                            ReadAttributes(reader, it);
                            condition.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is Conditions conditions)
                        {
                            ReadAttributes(reader, it);
                            conditions.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "orders")
                    {
                        Orders it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Item item)
                        {
                            ReadAttributes(reader, it);
                            item.Orders = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Orders = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Orders = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "order")
                    {
                        Order it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Orders orders)
                        {
                            ReadAttributes(reader, it);
                            orders.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "paging")
                    {
                        Paging it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Paging = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Paging = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "parameters")
                    {
                        Parameters it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Parameters = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Parameters = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "parameter")
                    {
                        Parameter it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Parameters parameters)
                        {
                            ReadAttributes(reader, it);
                            parameters.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "options")
                    {
                        Options it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.Options = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.Options = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "system")
                    {
                        SystemOptions it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.SystemOptions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.SystemOptions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "timeconstraint")
                    {
                        TimeConstraint it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Item item)
                        {
                            ReadAttributes(reader, it);
                            item.TimeConstraint = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is Query query)
                        {
                            ReadAttributes(reader, it);
                            query.TimeConstraint = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            ReadAttributes(reader, it);
                            queryResult.TimeConstraint = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "exceptions")
                    {
                        Exceptions it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is TimeConstraint timeConstraint)
                        {
                            ReadAttributes(reader, it);
                            timeConstraint.Exceptions = it;
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "exception")
                    {
                        ExceptionItem it = new();
                        if (CreateRootObject(it, reader, isEmptyElement))
                            continue;
                        object obj = stack.Peek();
                        if (obj is Exceptions exceptions)
                        {
                            ReadAttributes(reader, it);
                            exceptions.Items.Add(it);
                            if (!isEmptyElement)
                                stack.Push(it);
                        }
                    }
                    else if (name == "content")
                    {
                        object obj = stack.Peek();
                        if (obj is Item item)
                        {
                            item.Content = reader.ReadElementString();
                            isNotRead = true;
                        }
                    }
                    else if (name == "transfer")
                    {
                        object obj = stack.Peek();
                        if (obj is Query query)
                        {
                            string transferSection = reader.ReadInnerXml();
                            isNotRead = true;
                            query.Transfer.Body = transferSection;
                        }
                        else if (obj is QueryResult queryResult)
                        {
                            string transferSection = reader.ReadInnerXml();
                            isNotRead = true;
                            queryResult.Transfer.Body = transferSection;
                        }
                    }
                    else if (name == "sql")
                    {
                        object obj = stack.Peek();
                        if (obj is Item item)
                        {
                            item.Sql = reader.ReadElementString();
                            isNotRead = true;
                        }
                    }
                    break;
                case XmlNodeType.EndElement:

                    if (name is "query" or "objects" or "item" or "conditions" or
                        "condition" or "orders" or "timeconstraint" or "parameters" or
                        "parameter" or "options" or "paging" or "system" or
                        "queryresult" or "exceptions" or "exception" or "classes" or
                        "properties" or "cinfo" or "pinfo")
                    {
                        ReadAttributes(reader, null);
                        stack.Pop();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Создание корневого объекта если он не существует
    /// </summary>
    private bool CreateRootObject(InteractionObject it, XmlTextReader reader, bool isEmptyElement)
    {
        if (interactionObject == null)
        {
            interactionObject = it;
            ReadAttributes(reader, it);
            if (!isEmptyElement)
                stack.Push(it);
            return true;
        }
        return false;
    }

    private static void ReadAttributes(XmlTextReader reader, InteractionObject obj)
    {
        if (!reader.HasAttributes)
            return;
        reader.MoveToFirstAttribute();

        Attributes attr = null;
        if (obj != null)
            attr = obj;
        for (int i = 0; i < reader.AttributeCount; i++)
        {
            string attrName = reader.Name.ToLower();
            string value = reader.GetAttribute(i);
            reader.MoveToNextAttribute();

            if (attr == null)
                continue;

            attr[attrName] = value;
        }
    }

    private void Write(XmlTextWriter writer, InteractionObject obj)
    {
        if (obj is QueryResult queryResult)
        {
            writer.WriteStartElement(nameof(QueryResult));
            writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            WriteAttributes(writer, queryResult);
            if (queryResult.TransferXml != null)
            {
                writer.WriteStartElement(nameof(Transfer));
                writer.WriteRaw(queryResult.Transfer.Body);
                writer.WriteEndElement();
            }
            if (queryResult.ObjectsXml != null)
                Write(writer, queryResult.Objects);
            if (queryResult.OptionsXml != null)
                Write(writer, queryResult.Options);
            if (queryResult.TimeConstraintXml != null)
                Write(writer, queryResult.TimeConstraint);
            if (queryResult.PagingXml != null)
                Write(writer, queryResult.Paging);
            if (queryResult.ClassesXml != null)
                Write(writer, queryResult.Classes);
            if (queryResult.PropertiesXml != null)
                Write(writer, queryResult.Properties);
            if (queryResult.StatisticsXml != null)
                Write(writer, queryResult.Statistics);
            writer.WriteEndElement();
        }
        else if (obj is Query query)
        {
            writer.WriteStartElement(nameof(Query));
            writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            WriteAttributes(writer, query);

            if (query.ObjectsXml != null)
                Write(writer, query.Objects);
            if (query.ConditionsXml != null)
                Write(writer, query.Conditions);
            if (query.ParametersXml != null)
                Write(writer, query.Parameters);
            if (query.OptionsXml != null)
                Write(writer, query.Options);
            if (query.TimeConstraintXml != null)
                Write(writer, query.TimeConstraint);
            if (query.OrdersXml != null)
                Write(writer, query.OrdersXml);
            if (query.PagingXml != null)
                Write(writer, query.Paging);
            if (query.SystemOptionsXml != null)
                Write(writer, query.SystemOptions);
            if (query.TransferXml != null)
            {
                writer.WriteStartElement(nameof(Transfer));
                writer.WriteRaw(query.Transfer.Body);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        else if (obj is Objects objects)
        {
            writer.WriteStartElement(nameof(Objects));
            WriteAttributes(writer, objects);
            foreach (Item item in objects.Items)
            {
                Write(writer, item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Item item)
        {
            writer.WriteStartElement(nameof(Item));
            WriteAttributes(writer, item);
            foreach (Item _item in item.Items)
            {
                Write(writer, _item);
            }
            if (item.ConditionsXml != null)
                Write(writer, item.Conditions);
            if (item.TimeConstraintXml != null)
                Write(writer, item.TimeConstraint);
            if (item.OrdersXml != null)
                Write(writer, item.Orders);
            if (item.Content != null)
                writer.WriteElementString(nameof(item.Content), item.Content);
            if (item.Sql != null)
            {
                writer.WriteStartElement(nameof(item.Sql));
                writer.WriteCData(item.Sql);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
        else if (obj is Options)
        {
            writer.WriteStartElement(nameof(Options));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is TimeConstraint timeConstraint)
        {
            writer.WriteStartElement(nameof(TimeConstraint));
            WriteAttributes(writer, timeConstraint);
            if (timeConstraint.ExceptionsXml != null)
                Write(writer, timeConstraint.Exceptions);
            writer.WriteEndElement();
        }
        else if (obj is Paging)
        {
            writer.WriteStartElement(nameof(Paging));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is Properties properties)
        {
            writer.WriteStartElement(nameof(Properties));
            WriteAttributes(writer, properties);
            foreach (PInfo _item in properties.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Classes classes)
        {
            writer.WriteStartElement(nameof(Classes));
            WriteAttributes(writer, classes);
            foreach (CInfo _item in classes.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is PInfo)
        {
            writer.WriteStartElement(nameof(PInfo));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is CInfo)
        {
            writer.WriteStartElement(nameof(CInfo));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is Conditions conditions)
        {
            writer.WriteStartElement(nameof(Conditions));
            WriteAttributes(writer, conditions);
            foreach (Condition _item in conditions.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Condition condition)
        {
            writer.WriteStartElement(nameof(Condition));
            WriteAttributes(writer, condition);
            foreach (Condition _item in condition.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Parameters parameters)
        {
            writer.WriteStartElement(nameof(Parameters));
            WriteAttributes(writer, obj);
            foreach (Parameter _item in parameters.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Parameter)
        {
            writer.WriteStartElement(nameof(Parameter));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is Orders orders)
        {
            writer.WriteStartElement(nameof(Orders));
            WriteAttributes(writer, obj);
            foreach (Order _item in orders.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is Order)
        {
            writer.WriteStartElement(nameof(Order));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is Exceptions exceptions)
        {
            writer.WriteStartElement(nameof(Exceptions));
            WriteAttributes(writer, exceptions);
            foreach (ExceptionItem _item in exceptions.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is ExceptionItem)
        {
            writer.WriteStartElement(nameof(Exception));
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is SystemOptions)
        {
            writer.WriteStartElement("System");
            WriteAttributes(writer, obj);
            writer.WriteEndElement();
        }
        else if (obj is Statistics statistics)
        {
            writer.WriteStartElement(nameof(Statistics));
            WriteAttributes(writer, statistics);
            foreach (StatRow _item in statistics.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
        else if (obj is StatRow statRow)
        {
            writer.WriteStartElement(nameof(StatRow));
            WriteAttributes(writer, statRow);
            foreach (StatRow _item in statRow.Items)
            {
                Write(writer, _item);
            }
            writer.WriteEndElement();
        }
    }

    private List<PropertyInfo> _propertyInfos = null;
    private List<XmlAttributeAttribute> _xmlAttributes = null;

    private void WriteAttributes(XmlTextWriter writer, InteractionObject obj)
    {
        if (_propertyInfos == null)
        {
            _propertyInfos = [];
            _xmlAttributes = [];
            Type type = typeof(InteractionObject);
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                foreach (var attr in info.GetCustomAttributes(typeof(XmlAttributeAttribute), false).Cast<XmlAttributeAttribute>())
                {
                    _xmlAttributes.Add(attr);
                    _propertyInfos.Add(info);
                }
            }
        }

        for (int i = 0; i < _propertyInfos.Count; i++)
        {
            PropertyInfo pi = _propertyInfos[i];
            object value = pi.GetValue(obj, null);
            if (value != null)
            {
                string attrName = _xmlAttributes[i].AttributeName;
                writer.WriteAttributeString(attrName, value.ToString());
            }
        }
    }
}
