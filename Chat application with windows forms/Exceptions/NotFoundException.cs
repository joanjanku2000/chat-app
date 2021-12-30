using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Exceptions
{
    class NotFoundException : Exception
    {
        public NotFoundException (string message) : base(message) { }
    }
}
