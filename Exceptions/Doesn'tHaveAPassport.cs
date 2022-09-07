using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Exceptions
{
    public class Doesn_tHaveAPassport : Exception
    {
        public Doesn_tHaveAPassport(string message) : base(message)
        { }
    }
}
