using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service
{
    public class ServiceException(string message) : Exception(message)
    {
    }
}
