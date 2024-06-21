using System;
using OrderClasses.Converters;
using OrderClasses.DataTransfer;
using Newtonsoft.Json;
using OrderClasses;
using System.IO;
using AutoBogus; 
namespace Lab_4_OOP
{
    internal class Program // тут відбувається створення файлу рандом значеннями
    {
        static void Main(string[] args)
        {
            var faker = AutoFaker.Create();
            var orderBuro = faker.Generate<OrderBuro>();
            SerializeOrderBuroToJson(orderBuro, "orderBuro.json");
            var deserializedOrderBuro = DeserializeOrderBuroFromJson("orderBuro.json");
            Console.WriteLine(deserializedOrderBuro.ToString());
        }
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
    }
}
