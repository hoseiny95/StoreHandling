using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Database;
using Store.Domain;
using Store.Interface;

namespace Store.service
{
    public class Menu
    {


        private DbContext dbContext;
        private ProductRepository productRepository;
        private StockRepository stockRepository;


        public Menu(DbContext dbContext, ProductRepository productRepository,
            StockRepository stockRepository)
        {
            this.dbContext = dbContext;
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;


        }
        public void options()
        {
            bool check = true;

            do
            {
                Console.WriteLine("select your mode:\n 1- add product \n 2- getlist of products" +
                    "\n 3- get one product \n 4- bye product \n 5- sale product \n 6- stockproductviwe model" +
                    "\n 0- exit");
                int mode = int.Parse(Console.ReadLine());

                switch (mode)
                {
                    case 1:
                        Console.WriteLine("enter your product name,product Id,barcode");
                        var productname = Console.ReadLine();
                        string[] newProduct = productname.Split(',');
                        while (true)
                            if (productRepository.CheckProductName(newProduct[0]))
                            {
                                var product = new Product
                                {
                                    Name = newProduct[0],
                                    ProductId = int.Parse(newProduct[1]),
                                    Barcode = long.Parse(newProduct[2])
                                };
                                productRepository.AddProduct(product);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("enter a correct name");
                                newProduct[0] = Console.ReadLine();

                            }
                        Console.Clear();
                        break;
                    case 2:
                        var products = productRepository.GetProductList();
                        Console.Clear();
                        foreach (var item in products)
                        {
                            Console.WriteLine(item.ToString());

                        }
                        Console.WriteLine("*********************");

                        break;
                    case 3:
                        Console.WriteLine("enter id of product");
                        Console.Clear();
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine(productRepository.GetProductById(id));
                        Console.WriteLine("*********************");
                        break;
                    case 4:
                        Console.WriteLine("enter your product in stock name,productid,stockid,prosuctquantity,productprice");
                        var producStocktname = Console.ReadLine();
                        string[] newProducStocktname = producStocktname.Split(',');
                        var stock = new Stock()
                        {
                            Name = newProducStocktname[0],
                            ProductId = int.Parse(newProducStocktname[1]),
                            StockId = int.Parse(newProducStocktname[2]),
                            ProductQuantity = int.Parse(newProducStocktname[3]),
                            ProductPrice = decimal.Parse(newProducStocktname[4]),

                        };
                        stockRepository.BuyProduct(stock);
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("enter id of product and number of order: id,number");
                        string[] num = Console.ReadLine().Split(',');

                        Console.WriteLine(stockRepository.SaleProduct(int.Parse(num[0]), int.Parse(num[1])));
                        Console.WriteLine("*********************");
                        Console.Clear();
                        break;
                    case 6:
                        var allProducts = stockRepository.GetSalesProductList();
                        Console.Clear();
                        foreach (var item in allProducts)
                            Console.WriteLine(item.ToString());
                        Console.WriteLine("*********************");
                        break;
                    case 0:
                        check = false;
                        break;
                }

            }
            while (check);

        }


    }
}
