using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Common.Exceptions
{
    public class AppException(string message): Exception(message)
    {

    }
}
