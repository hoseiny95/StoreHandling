using Store.Database;
using Store.Domain;
using Store.Exeption;
using Store.Interface;
using Store.service;

var dbContext = new DbContext();
var productRepository = new ProductRepository(dbContext);
var stockRepository = new StockRepository(dbContext, productRepository);
var menu = new Menu(dbContext, productRepository, stockRepository);
try
{
    menu.options();

}
catch (ProductNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}