using CinemaApp.UI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI
{
    public interface IHasSessionContext
    {
        void SetSessionContext(SessionContext sessionContext);
    }
}
