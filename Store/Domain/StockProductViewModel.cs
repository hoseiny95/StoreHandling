using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class StockProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public long Barcode { get; set; }
        public int StockId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public override string ToString()
        {
            return this.Name+ "," + this.Barcode + "," + this.StockId + ","
                + this.ProductId + ","
                + this.ProductQuantity + "," + this.ProductPrice;
        }
    }
}
