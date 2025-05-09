using CinemaApp.Domain;
using CinemaApp.UI.AdminForms;
using CinemaApp.UI.UserForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI.Manager
{
    public class FormManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SessionContext _sessionContext;
        public SessionContext Session => _sessionContext;

        public FormManager(IServiceProvider serviceProvider, SessionContext sessionContext)
        {
            _serviceProvider = serviceProvider;
            _sessionContext = sessionContext;
        }

        public void SwitchToForm<T>(Form? currentForm = null) where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();

            currentForm?.Hide();
            form.FormClosing += (s, e) => currentForm?.Show(); 
            form.Show();
        }

        public T Resolve<T>() where T : Form => _serviceProvider.GetRequiredService<T>();

        
    }
}
