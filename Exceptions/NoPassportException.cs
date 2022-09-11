using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NoPassportException : Exception
    {
        public NoPassportException(string message) : base(message)
        { }
    }
}
