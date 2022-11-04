using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;
            using (StreamReader streamReader = new StreamReader("Products.json"))
            {
                jsonString = streamReader.ReadToEnd();  
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product productMaxCost = products[0];
            foreach (Product product in products)
            {
                if (productMaxCost.ProductPrice < product.ProductPrice)
                {
                    productMaxCost = product;   
                }   
            }
            Console.WriteLine($"Максимальная цена: {productMaxCost.ProductCode} {productMaxCost.ProductName} {productMaxCost.ProductPrice}");
            Console.ReadKey();
        }
    }
}
