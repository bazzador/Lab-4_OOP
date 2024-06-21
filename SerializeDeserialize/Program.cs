using OrderClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserialize
{
    internal class Program
    {
        static void SerializeOrderBuroToJson(OrderBuro orderBuro, string filePath)
        {
            var dtoObj = OrderBuroConverter.ToDTO(orderBuro);
            var jsonFile = JsonConvert.SerializeObject(dtoObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonFile);
        }
        static OrderBuro DeserializeOrderBuroFromJson(string filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            var dtoObj = JsonConvert.DeserializeObject<OrderBuroDTO>(jsonFile);
            return OrderBuroConverter.FromDTO(dtoObj);
        }
        static void Main(string[] args)
        {
            var faker = new AutoFaker<OrderBuro>().RuleFor(o => o.Name, f => "Бюро_#1");
            var orderBuro = faker.Generate();
            SerializeOrderBuroToJson(orderBuro, "orderBuro.json");
            var deserializedOrderBuro = DeserializeOrderBuroFromJson("orderBuro.json");
            Console.WriteLine(deserializedOrderBuro.ToString());
        }
    }
}
