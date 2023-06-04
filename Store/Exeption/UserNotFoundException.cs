using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exeption
{
    public class UserNotFoundException : ApplicationException
    {
        public override string Message => "User Not Found";

    }
}
