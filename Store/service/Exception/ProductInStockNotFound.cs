using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.service.Exception
{
    internal class ProductInStockNotFound : ApplicationException

    {
        public override string Message => "Product There Isnt In The Stock";

    }
}
