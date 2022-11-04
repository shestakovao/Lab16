using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите код товара");
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя товара");
                string productName = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double productPrice = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product() { ProductCode = productCode, ProductName = productName, ProductPrice = productPrice };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true               
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter streamWriter = new StreamWriter("Products.json"))
            {
                streamWriter.WriteLine(jsonString);
            }



        }
    }
}
