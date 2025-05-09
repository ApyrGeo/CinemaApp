using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI
{
    public interface IScopedForm
    {
        void SetScope(IServiceScope scope);
    }
}
