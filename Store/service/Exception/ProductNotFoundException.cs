using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exeption
{
    public class ProductNotFoundException : ApplicationException
    {
        public override string Message => "Product Not Found";

    }
}
