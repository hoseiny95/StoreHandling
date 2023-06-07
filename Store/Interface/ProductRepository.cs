using Store.Database;
using Store.Domain;
using Store.Exeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store.Interface
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext dbContext;
        private int num;

        public ProductRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string AddProduct(Product product)
        {
            try 
            {
                dbContext.Products.Add(product);
                dbContext.productSaveChanges();
                return "your product added";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetProductById(int id)
        {

            var product = dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                throw new ProductNotFoundException() ;
            return product.ToString();



        }

        public List<Product> GetProductList()
        {
            return dbContext.Products;
        }

        public bool CheckProductName(string productName)
        {
            if (productName.Length !=9)
                return false;
            if (Char.IsUpper(productName[0]) && Char.IsLower(productName[1])
                && Char.IsLower(productName[2]) && Char.IsLower(productName[3])
                && Regex.IsMatch(Convert.ToString(productName[5]), "_")
                && int.TryParse(productName[6].ToString(),out num)
                && int.TryParse(productName[7].ToString(), out num)
                && int.TryParse(productName[8].ToString(), out num))
            {
                return true;
            }
            return false;


        }
    }
}
