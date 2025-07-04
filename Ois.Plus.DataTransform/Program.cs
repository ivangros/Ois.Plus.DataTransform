using Newtonsoft.Json;
using Ois.Plus.ObjectModel;

public class Program
{
    public static void Main()
    {
        var jsonQuery = ToJsonQuery();
        var resList = QueryData(jsonQuery, true);
        Console.WriteLine(JsonConvert.SerializeObject(resList, Formatting.Indented));
    }

    public static string Main(string[] args)
    {
        var jsonQuery = ToJsonQuery();
        var resList = QueryData(jsonQuery, true);
        return JsonConvert.SerializeObject(resList, Formatting.Indented);
        //Console.WriteLine(JsonConvert.SerializeObject(resList, Formatting.Indented));
    }

    public static string ToJsonQuery()
    {
        var q = (QueryResult)InteractionObject.LoadFromXml(queryResult3);
        var settings = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        //todo: необходимо описать атрибуты сериализации на Query и всех классах для корректной сериализации,
        //чтобы результат был идентичен jsonQuery
        return JsonConvert.SerializeObject(q, settings);
    }

    public static List<Dictionary<string, string>> QueryData(string jsonQuery)
    {
        var qr = (QueryResult)InteractionObject.LoadFromXml(queryResult3);

        //тут код трансформации qr в массив объектов
        //.Необходимо описать класс строки с атрибутыми и алгоритм трансформации дерева в строки, ниже приведен пример

        var resultList = new List<Dictionary<string, string>>();

        foreach (var obj in qr.Objects.Items)
        {
            var dict = new Dictionary<string, string>();
            ProcessAllItems(obj.Items, dict);

            resultList.Add(dict);
        }

        return resultList;
    }

    public static Dictionary<string, List<Dictionary<string, string>>> QueryData(string jsonQuery, bool groupBySTime = true)
    {
        var qr = (QueryResult)InteractionObject.LoadFromXml(queryResult3);
        var resultDict = new Dictionary<string, List<Dictionary<string, string>>>();

        foreach (var obj in qr.Objects.Items)
        {
            ProcessWithTime(obj.Items, resultDict, new Dictionary<string, string>());
        }

        return resultDict;
    }


    public static void ProcessAllItems(IEnumerable<Item> items, Dictionary<string, string> dict, string parentKey = "")
    {
        foreach (var item in items)
        {
            if (item == null) continue;

            string currentKey;
            if (string.IsNullOrEmpty(parentKey))
            {
                currentKey = item.pName ?? "";
            }
            else if (!string.IsNullOrEmpty(item.pName))
            {
                currentKey = $"{parentKey}_{item.pName}";
            }
            else
            {
                currentKey = parentKey;
            }

            if (!string.IsNullOrEmpty(item.dv))
            {
                dict[currentKey] = item.dv;
            }

            if (item.Items != null)
            {
                ProcessAllItems(item.Items, dict, currentKey);
            }
        }
    }

    public static void ProcessWithTime(IEnumerable<Item> items, Dictionary<string, List<Dictionary<string, string>>> result, Dictionary<string, string> collectedInfo, string parentKey = "")
    {
        foreach (var item in items)
        {
            if (item == null) continue;

            string currentKey = string.IsNullOrEmpty(parentKey)
                ? item.pName ?? ""
                : !string.IsNullOrEmpty(item.pName) ? $"{parentKey}_{item.pName}" : parentKey;

            if (!string.IsNullOrEmpty(item.sTime))
            {
                var row = new Dictionary<string, string>(collectedInfo);

                if (!string.IsNullOrEmpty(item.dv))
                    row[currentKey] = item.dv;

                if (item.Items != null)
                    ProcessAllItems(item.Items, row, currentKey);

                if (!result.ContainsKey(item.sTime))
                    result[item.sTime] = new List<Dictionary<string, string>>();

                result[item.sTime].Add(row);
            }
            else
            {
                if (!string.IsNullOrEmpty(item.dv))
                {
                    collectedInfo[currentKey] = item.dv;
                }

                if (item.Items != null)
                {
                    ProcessWithTime(item.Items, result, collectedInfo, currentKey);
                }
            }
        }
    }


    //запрос
    const string query = @"<Query>
      <Objects>
        <Item LmName=""well"" NS=""1485"">
	      <Item LmName=""id"" />
	      <Item LmName=""name""  />
          <Item LmName=""pty_watering_vol_man_source"" />
          <Item LmName=""pty_flrate_vol_liquid_man_source"" />  
        </Item>
      </Objects>
      <Conditions>
        <Condition Operand1=""self.id"" Operator=""in"" Operand2=""31335464,31336438"" />
      </Conditions>
      <Options DataMode=""Simple"" NameMode=""True"" NoInfo=""True"" />
      <TimeConstraint UseDefault=""False"" IntervalType=""trpPoint"" StartTime=""15.06.2025 01:00:00"" />
    </Query>";

    const string jsonQuery = @"{
        ""objects: [
            {
                ""item"": { 
                    ""lmName"": ""well""
                    ""item"":[
                        { ""lmName"": ""id"" },
                        { ""lmName"": ""name"" },
                        { ""lmName"": ""pty_watering_vol_man_source"" },
                        { ""lmName"": ""pty_flrate_vol_liquid_man_source"" },
                    ]
                },
                ""ns"": ""1485""
            }
        ],
        ""conditions"":[
            { 
                ""operand1"": ""self.id"",
                ""operator"": ""in"",
                ""operand2"": ""31335464,31336438""
            }
        ],
        ""options"": { 
            ""dataMode"": ""Simple"",
            ""nameMode"": ""True"",
            ""noInfo"": ""True""
        },
        ""timeConstaint"": {
            ""useDefault"": ""False"",
            ""intervalType"": ""trpPoint"",
            ""startTime"": ""15.06.2025 01:00:00""
        }
    }";

    //результат xml
    const string queryResult = @"<QueryResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RC=""6"" Algorithm=""2"">
      <Objects RC=""1"">
        <Item ID=""31335464"" Name=""1"" F="""" CName=""well"">
          <Item PName=""name"" DV=""1"" NS=""1485"" />
          <Item PName=""id"" DV=""31335464"" />
          <Item PName=""pty_watering_vol_man_source"" RC=""1"">
            <Item ID=""1341248360040"" F="""" CName=""pty_watering_vol_man_source"" DV=""10"" STime=""13.05.2025 03:01:00"" ETime="""">
              <Item PName=""id"" DV=""1341248360040"" />
              <Item PName=""condition"" ID=""31346760"" Name=""кондиционный замер"" F="""" CName=""ref_value_condition"">
                <Item PName=""name"" DV=""кондиционный замер"" NS=""1485"" />
              </Item>
            </Item>
          </Item>
          <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""1"">
            <Item ID=""1341356900040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""1400"" STime=""14.05.2025 02:00:00"" ETime="""" Uom=""1600"" UName="""" />
          </Item>
        </Item>
      </Objects>
    </QueryResult>";

    const string queryResult2 = @"<QueryResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RC=""6"" Algorithm=""2"">
      <Objects RC=""1"">
        <Item ID=""31335464"" Name=""1"" F="""" CName=""well"">
          <Item PName=""name"" DV=""1"" NS=""1485"" />
          <Item PName=""id"" DV=""31335464"" />
          <Item PName=""pty_watering_vol_man_source"" RC=""1"">
            <Item ID=""1341248360040"" F="""" CName=""pty_watering_vol_man_source"" DV=""10"" STime=""13.05.2025 03:01:00"" ETime="""">
              <Item PName=""id"" DV=""1341248360040"" />
              <Item PName=""condition"" ID=""31346760"" Name=""кондиционный замер"" F="""" CName=""ref_value_condition"">
                <Item PName=""name"" DV=""кондиционный замер"" NS=""1485"" />
              </Item>
            </Item>
          </Item>
          <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""1"">
            <Item ID=""1341356900040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""1400"" STime=""14.05.2025 02:00:00"" ETime="""" Uom=""1600"" UName="""" />
          </Item>
        </Item>
      </Objects>
    </QueryResult>";

    const string queryResult3 = @"<QueryResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RC=""8"" Algorithm=""2"">
    <Objects RC=""2"">
    <Item ID=""493220999"" Name=""5В1"" F="""" CName=""well"">
    <Item PName=""name"" DV=""5В1"" NS=""1485""/>
    <Item PName=""id"" DV=""493220999""/>
    <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""2"">
    <Item ID=""1351084020040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""120"" STime=""11.06.2025 00:00:00"" ETime=""18.06.2025 00:00:00"" Uom=""1600"" UName=""""/>
    <Item ID=""1351084210040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""150"" STime=""18.06.2025 00:00:00"" ETime="""" Uom=""1600"" UName=""""/>
    </Item>
    <Item PName=""pty_flrate_vol_oilgas_man_source"" RC=""2"">
    <Item ID=""1351084070040"" F="""" CName=""pty_flrate_vol_oilgas_man_source"" DV=""3391.9158"" STime=""11.06.2025 00:00:00"" ETime=""19.06.2025 00:00:00"" Uom=""2172600011"" UName=""""/>
    <Item ID=""1351084400040"" F="""" CName=""pty_flrate_vol_oilgas_man_source"" DV=""4669.6923"" STime=""19.06.2025 00:00:00"" ETime="""" Uom=""1600"" UName=""""/>
    </Item>
    </Item>
    <Item ID=""492600999"" Name=""1120"" F="""" CName=""well"">
    <Item PName=""name"" DV=""1120"" NS=""1485""/>
    <Item PName=""id"" DV=""492600999""/>
    <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""1"">
    <Item ID=""1348541140040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""20"" STime=""09.06.2025 00:00:00"" ETime="""" Uom=""1600"" UName=""""/>
    </Item>
    <Item PName=""pty_flrate_vol_oilgas_man_source"" RC=""1"">
    <Item ID=""1348541310040"" F="""" CName=""pty_flrate_vol_oilgas_man_source"" DV=""42.818880"" STime=""09.06.2025 00:00:00"" ETime="""" Uom=""1600"" UName=""""/>
    </Item>
    </Item>
    </Objects>
    <Options NS=""1485"" NameMode=""True""/>
    <TimeConstraint UseDefault=""False"" IntervalType=""133647"" StartTime=""10.05.2025 01:00:00"" EndTime=""20.06.2025"" TimeZone=""+03:00""/>
    </QueryResult>";

    const string query1 = @"<Query>
      <Objects>
        <Item LmName=""well"" NS=""1485"">
          <Item LmName=""id"" />
          <Item LmName=""name"" />
          <Item LmName=""pty_watering_vol_man_source"">
            <Item LmName=""id"" />
            <Item LmName=""condition"">
              <Item LmName=""name"" />
            </Item>
          </Item>
          <Item LmName=""pty_flrate_vol_liquid_man_source"" />
        </Item>
      </Objects>
      <Conditions>
        <Condition Operand1=""self.id"" Operator=""in"" Operand2=""31335464,31336438"" />
      </Conditions>
      <Options DataMode=""Simple"" NameMode=""True"" NoInfo=""True"" />
      <TimeConstraint UseDefault=""False"" IntervalType=""trpPoint"" StartTime=""15.05.2025 01:00:00"" TimeZone=""+03:00"" />
    </Query>";
}

public class XMLConv
{
    public static string Convert(string xml)
    {
        var jsonQuery = ToJsonQuery(xml);
        var resList = QueryData(jsonQuery, xml);
        return JsonConvert.SerializeObject(resList, Formatting.Indented);
    }

    public static List<Dictionary<string, string>> ConvertToList(string xml)
    {
        var jsonQuery = ToJsonQuery(xml);
        var resList = QueryData(jsonQuery, xml);
        return resList;
    }

    public static string ToJsonQuery(string queryResult)
    {
        var q = (QueryResult)InteractionObject.LoadFromXml(queryResult);
        var settings = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        //todo: необходимо описать атрибуты сериализации на Query и всех классах для корректной сериализации,
        //чтобы результат был идентичен jsonQuery
        return JsonConvert.SerializeObject(q, settings);
    }

    public static List<Dictionary<string, string>> QueryData(string jsonQuery, string queryResult)
    {
        var qr = (QueryResult)InteractionObject.LoadFromXml(queryResult);

        //тут код трансформации qr в массив объектов
        //.Необходимо описать класс строки с атрибутыми и алгоритм трансформации дерева в строки, ниже приведен пример

        var resultList = new List<Dictionary<string, string>>();

        foreach (var obj in qr.Objects.Items)
        {
            var dict = new Dictionary<string, string>();
            ProcessAllItems(obj.Items, dict);

            resultList.Add(dict);
        }

        return resultList;


        /*string jsonResult = @"[{
            ""id"": ""31335464"",
            ""name"": ""1"",
            ""pty_watering_vol_man_source"": ""10"",
            ""pty_flrate_vol_liquid_man_source"": ""1400""
            },
            {
            ""id"": ""31336438"",
            ""name"": ""3"",
            ""pty_watering_vol_man_source"": ""43.8"",
            ""pty_flrate_vol_liquid_man_source"": ""15.15""
            }]";

        return jsonResult;*/
    }

    public static void ProcessAllItems(IEnumerable<Item> items, Dictionary<string, string> dict)
    {

        foreach (var item in items)
        {
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.pName) && !string.IsNullOrEmpty(item.dv))
                {
                    dict[item.pName] = item.dv;
                }
                else if (!string.IsNullOrEmpty(item.cName) && !string.IsNullOrEmpty(item.dv))
                {
                    dict[item.cName] = item.dv;
                }
            }

            if (item.Items != null)
            {
                ProcessAllItems(item.Items, dict);
            }
        }
    }
}