using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Database
{
    public class DbContext
    {
        private string workingDirectory;
        private string projectDirectory;
        private string directory;

       

        public DbContext()
        {
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            FileStream Productjsonfile = File.Open($"{projectDirectory}/../Database/ProductJson.json", FileMode.OpenOrCreate);
            FileStream stockjsonfile = File.Open($"{projectDirectory}/../Database/StockJason.json", FileMode.OpenOrCreate);
            directory = projectDirectory + @"/../Database";
            var Products = JsonSerializer.Deserialize<Product>(Productjsonfile);
            var stocks = JsonSerializer.Deserialize<Product>(stockjsonfile);


            Productjsonfile.Close();
            stockjsonfile.Close();
        }

        public List<Product> Products { get; set; }
        public string ProjectDirectory { get { return directory; } }

        public List<Stock> stocks { get; set; }

        public void productSaveChanges()
        {
            var productJsonString = JsonSerializer.Serialize(Products);
            File.WriteAllText(@$"{projectDirectory}/../Database/ProductJson.json", productJsonString);
        } public void StockSaveChanges()
        {
            var stockJsonString = JsonSerializer.Serialize(stocks);
            File.WriteAllText(@$"{projectDirectory}/../Database/StockJason.json", stockJsonString);
        }
    }
}
