using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHelper
{
    public class Warning : Exception
    {
        public Warning(string message)
            : this(message, "")
        {
        }

        public Warning(string message, string code)
            : this(message, code, null)
        {
        }

        public Warning(Exception exception)
            : this("", "", exception)
        {
        }

        public Warning(string message, string code, Exception exception)
            : base(message ?? "", exception)
        {
            //Code = code;
            //_message = GetMessage();
        }


    }
}
