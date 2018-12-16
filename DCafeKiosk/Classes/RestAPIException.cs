using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCafeKiosk
{
    class RestAPIException : Exception
    {
        public RestAPIException()
        {
        }

        public RestAPIException(string message):base(message)
        {
        }

        public RestAPIException(string message, Exception inner):base(message, inner)
        {
        }
    }
}
