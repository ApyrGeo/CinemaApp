using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI.Manager
{
    public class SessionContext
    {
        public User? LoggedInUser { get; private set; }
        public Admin? LoggedInAdmin { get; private set; }

        public bool IsUser => LoggedInUser != null;
        public bool IsAdmin => LoggedInAdmin != null;

        public void SetUser(User user)
        {
            LoggedInUser = user;
            LoggedInAdmin = null;
        }

        public void SetAdmin(Admin admin)
        {
            LoggedInAdmin = admin;
            LoggedInUser = null;
        }

        public void Clear()
        {
            LoggedInUser = null;
            LoggedInAdmin = null;
        }
    }
}
