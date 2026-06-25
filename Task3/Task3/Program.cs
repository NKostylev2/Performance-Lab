using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System;


namespace Task3
{
    class Program
    {
        static void FillTestValues(List<Test> tests, List<TestValue> values)
        {
            foreach (var test in tests)
            {
                var matchingValue = values.Find(v => v.Id == test.Id);
                if (matchingValue != null)
                {
                    test.Value = matchingValue.Value;
                }

                if (test.Values != null)
                {
                    FillTestValues(test.Values, values);
                }
                else
                {
                    test.Values = null;
                }
            }
        }
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Пропишите пути к файлам values.json tests.json report.json");
                return;
            }

            string valuesJsonPath = args[0];
            string testsJsonPath = args[1];
            string reportJsonPath = args[2];

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,                                      
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true                          
                };

                string valuesJson = File.ReadAllText(valuesJsonPath);
                string testsJson = File.ReadAllText(testsJsonPath);

                ValuesData valuesData = JsonSerializer.Deserialize<ValuesData>(valuesJson, options);
                TestsData testsData = JsonSerializer.Deserialize<TestsData>(testsJson, options);

                FillTestValues(testsData.Tests, valuesData.Values);

                string reportJson = JsonSerializer.Serialize(testsData, options);
                File.WriteAllText(reportJsonPath, reportJson);

                Console.WriteLine("report.json составлен успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }


    }
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public List<Test> Values { get; set; }
    }

    public class TestsData
    {
        public List<Test> Tests { get; set; }
    }

    public class TestValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class ValuesData
    {
        public List<TestValue> Values { get; set; }
    }
}

