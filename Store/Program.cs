﻿using Store.Database;
using Store.Domain;
using Store.Interface;

var dbContext = new DbContext();
var productRepository = new ProductRepository(dbContext);
var stockRepository = new StockRepository(dbContext, productRepository);

//try
//{
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
            Console.WriteLine("enter your product name,prosuctid,barcode");
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
            break;
        case 2:
            var products = productRepository.GetProductList();
            foreach (var product in products)
            {
                Console.WriteLine(products.ToString());

            }

            break;
        case 3:
            Console.WriteLine("enter id of producr");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(productRepository.GetProductById(id));
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
            break;
        case 5:
            Console.WriteLine("enter id of product and number of order: id,number");
            string[] num = Console.ReadLine().Split(',');

            Console.WriteLine(stockRepository.SaleProduct(int.Parse(num[0]), int.Parse(num[1])));
            break;
        case 6:
            Console.WriteLine(stockRepository.GetSalesProductList());
            break;
        case 0:
            check = false;
            break;
    }

}
while (check);

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}