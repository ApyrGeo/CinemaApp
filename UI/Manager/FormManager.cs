using CinemaApp.Domain;
using CinemaApp.Service.Observer;
using CinemaApp.UI.AdminForms;
using CinemaApp.UI.UserForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Forms;

namespace CinemaApp.UI.Manager
{
    public enum FormBehavior
    {
        HideAndShowNext,
        StayAndShowNext
    }
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

        public void SwitchToForm<T>(Form? currentForm, FormBehavior formBehavior, bool isSeparateThread = false, IServiceScope? externalScope = null) where T : Form
        {
            if (isSeparateThread)
            {
                var scope = externalScope ?? _serviceProvider.CreateScope();

                var thread = new Thread(() =>
                {
                    var scopedProvider = scope.ServiceProvider;

                    var sessionContext = scopedProvider.GetRequiredService<SessionContext>();
                    var notifier = scopedProvider.GetRequiredService<Notifier>();
                    var form = scopedProvider.GetRequiredService<T>();

                    if (form is IHasSessionContext ctx)
                        ctx.SetSessionContext(sessionContext);

                    if (form is IScopedForm scopedForm)
                        scopedForm.SetScope(scope);


                    form.FormClosed += (s, e) =>
                    {
                        if (form is Service.Observer.IObserver<ChangeEvent> obs)
                            notifier.Unsubscribe(obs);

                        if (externalScope == null)
                            scope.Dispose();
                    };

                    Application.Run(form);
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                return;
            }

            // Use scope if provided; otherwise fallback to root
            var scopedProvider = externalScope?.ServiceProvider ?? _serviceProvider;

            var sessionContext = scopedProvider.GetRequiredService<SessionContext>();
            var notifier = scopedProvider.GetRequiredService<Notifier>();
            var formInstance = scopedProvider.GetRequiredService<T>();

            if (formInstance is IHasSessionContext ctxInline)
                ctxInline.SetSessionContext(sessionContext);

            if (formInstance is IScopedForm scopedFormInline)
                scopedFormInline.SetScope(externalScope!);

            if (formInstance is Service.Observer.IObserver<ChangeEvent> observerInline)
                notifier.Subscribe(observerInline);

            if (formBehavior == FormBehavior.HideAndShowNext)
            {
                currentForm?.Hide();
                formInstance.FormClosing += (s, e) => currentForm?.Show();
            }

            formInstance.Show();
        }

        public T Resolve<T>() where T : Form => _serviceProvider.GetRequiredService<T>();

        
    }
}
