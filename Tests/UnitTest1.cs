using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var xml = @"<?xml version=""1.0"" encoding=""windows-1251""?>
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

            var res1 = XMLConv.ConvertToList(xml);
            var expected = @"[{
            ""name"": ""1"",
            ""id"": ""31335464"",
            ""pty_watering_vol_man_source"": ""10"",
            ""pty_flrate_vol_liquid_man_source"": ""1400""
            },
            {
            ""name"": ""3"",
            ""id"": ""31336438"",
            ""pty_watering_vol_man_source"": ""43.8"",
            ""pty_flrate_vol_liquid_man_source"": ""15.15""
            }]";
            var obj = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(expected);
            Assert.AreEqual(obj, res1);
        }
        [Test]
        public void Test2()
        {
            var xml = @"<?xml version=""1.0"" encoding=""windows-1251""?>
<QueryResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RC=""6"" Algorithm=""2"">
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

            var res1 = XMLConv.ConvertToList(xml);
            var expected = @"[{
    ""name"": ""1"",
    ""id"": ""31335464"",
    ""pty_watering_vol_man_source"": ""10""
    ""pty_watering_vol_man_source__id"": ""1341248360040"",
    ""pty_watering_vol_man_source__condition__name"": ""кондиционный замер"",
    ""pty_flrate_vol_liquid_man_source"": ""1400""
  }]";
            var obj = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(expected);
            Assert.AreEqual(obj, res1);
        }
    }
}