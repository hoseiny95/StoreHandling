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
    internal class ProductRepository : IProductRepository
    {
        private readonly DbContext dbContext;
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

            var product = dbContext.Products.SingleOrDefault(x => x.ProductId == id);
            if (product == null)
                throw new UserNotFoundException() ;
            return product.ToString();



        }

        public List<Product> GetProductList()
        {
            return dbContext.Products.ToList();
        }

        public bool CheckProductName(string productName)
        {
            if (Char.IsUpper(productName[0]) && Char.IsLower(productName[1])
                && Char.IsLower(productName[2]) && Char.IsLower(productName[3])
                && Regex.IsMatch(Convert.ToString(productName[4]), "_"))
            {
                return true;
            }
            return false;


        }
    }
}
