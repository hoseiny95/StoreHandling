using Store.Database;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Interface
{
    public class StockRepository : IStockRepository
    {
        private readonly DbContext db;
        private readonly ProductRepository productrepository;
        public StockRepository(DbContext db, ProductRepository productrepository)
        {
            this.db = db;
            this.productrepository = productrepository;

        }
        public string BuyProduct(Stock productInStock)
        {
            if (db.stocks.Any(x => x.ProductId == productInStock.ProductId))
            {
                Stock productold = (Stock)db.stocks.Select(x => x.ProductId = productInStock.ProductId);
                Stock productnew = new Stock();
                productnew.ProductId = productInStock.ProductId;
                productnew.ProductQuantity = productInStock.ProductQuantity + productold.ProductQuantity;
                productnew.StockId = productInStock.StockId;
                productnew.Name = productInStock.Name;
                productnew.ProductPrice = (productInStock.ProductPrice * productInStock.ProductQuantity
                    + productold.ProductPrice * productold.ProductQuantity) / productnew.ProductQuantity;
                db.stocks.RemoveAll(x => x.ProductId == productInStock.ProductId);
                db.stocks.Add(productnew);
                db.StockSaveChanges();
                return productrepository.GetProductById(productInStock.ProductId);


            }
            else
            {
                db.stocks.Add(productInStock);
                db.StockSaveChanges();
                return productrepository.GetProductById(productInStock.ProductId);
            }
        }

   
        public string SaleProduct(int productId, int cnt)
        {
            if (GetProductQuantity(productId) >= cnt)
            {
                Stock productinstock = (Stock)db.stocks.Select(x => x.ProductId = productId);
                var productinstocknew = productinstock;
                productinstocknew.ProductQuantity = GetProductQuantity(productId) - cnt;
                db.stocks.RemoveAll(x => x.ProductId == productId);
                db.stocks.Add(productinstocknew);

                db.StockSaveChanges();
                return "product sold to you \n" + productrepository.GetProductById(productId);

            }
            else
            {
                return "product is lower than number of your order \n" + productrepository.GetProductById(productId);

            }
        }

        public int GetProductQuantity(int productId)
        {
            Stock productinstock = (Stock)db.stocks.Select(x => x.ProductId = productId);
            return productinstock.ProductQuantity;



        }

        public List<StockProductViewModel> GetSalesProductList()
        {
            List<StockProductViewModel> stocks;
            stocks = (from p in db.stocks
                                join c in db.Products on p.ProductId equals c.ProductId
                                select new StockProductViewModel
                                {
                                    ProductId = p.ProductId,
                                    Name = c.Name,
                                    Barcode = c.Barcode,
                                    StockId = p.StockId,
                                    ProductPrice = p.ProductPrice,
                                    ProductQuantity = p.ProductQuantity,

                                }).ToList();
            var writetxt = new StreamWriter(Path.Combine(db.ProjectDirectory,@"alllist.txt"));
            foreach (var s in stocks)
                writetxt.WriteLine(s);

            writetxt.Close();

            return stocks;

        }
    }
}
