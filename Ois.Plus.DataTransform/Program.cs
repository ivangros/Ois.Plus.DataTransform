using Newtonsoft.Json;
using Ois.Plus.ObjectModel;

internal class Program
{
    private static void Main(string[] args)
    {
        var jsonQuery = ToJsonQuery();
        var resList = QueryData(jsonQuery);
        Console.WriteLine(JsonConvert.SerializeObject(resList, Formatting.Indented));
    }

    public static string ToJsonQuery()
    {
        var q = (Query)InteractionObject.LoadFromXml(queryResult);
        var settings = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        //todo: необходимо описать атрибуты сериализации на Query и всех классах для корректной сериализации,
        //чтобы результат был идентичен jsonQuery
        return JsonConvert.SerializeObject(q,settings);
    }

    public static List<Dictionary<string, string>> QueryData(string jsonQuery)
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
    const string queryResult = @"<?xml version=""1.0"" encoding=""windows-1251""?>
<QueryResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RC=""6"" Algorithm=""2"">
  <Objects RC=""2"">
    <Item ID=""31335464"" Name=""1"" F="""" CName=""well"">
      <Item PName=""name"" DV=""1"" NS=""1486"" />
      <Item PName=""id"" DV=""31335464"" />
      <Item PName=""pty_watering_vol_man_source"" RC=""1"">
        <Item ID=""1341248360040"" F="""" CName=""pty_watering_vol_man_source"" DV=""10"" STime=""13.05.2025 04:01:00"" ETime="""" />
      </Item>
      <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""1"">
        <Item ID=""1341356900040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""1400"" STime=""14.05.2025 03:00:00"" ETime="""" Uom=""1600"" UName="""" />
      </Item>
    </Item>
    <Item ID=""31336438"" Name=""3"" F="""" CName=""well"">
      <Item PName=""name"" DV=""3"" NS=""1486"" />
      <Item PName=""id"" DV=""31336438"" />
      <Item PName=""pty_watering_vol_man_source"" RC=""1"">
        <Item ID=""1343117280040"" F="""" CName=""pty_watering_vol_man_source"" DV=""43.8"" STime=""29.05.2025 03:00:00"" ETime="""" />
      </Item>
      <Item PName=""pty_flrate_vol_liquid_man_source"" RC=""1"">
        <Item ID=""1343116910040"" F="""" CName=""pty_flrate_vol_liquid_man_source"" DV=""15.15"" STime=""29.05.2025 03:00:00"" ETime="""" Uom=""1600"" UName="""" />
      </Item>
    </Item>
  </Objects>
  <Options NS=""1485"" NameMode=""True"" />
  <TimeConstraint UseDefault=""False"" IntervalType=""133648"" StartTime=""15.06.2025 01:00:00"" EndTime=""15.06.2025 01:00:00"" TimeZone=""+04:00"" />
</QueryResult>";
}