using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Exceptions
{
    class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
            
        }

    }
}
