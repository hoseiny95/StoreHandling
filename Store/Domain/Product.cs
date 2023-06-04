using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public long Barcode { get; set; }

        public override string ToString()
        {
            return  this.Name + "," + this.Barcode + "," + this.ProductId;
    }
    }
}
   
    
