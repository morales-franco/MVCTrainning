using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using TestSite.Binders;
using TestSite.Models;

namespace TestSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Sino declaramos el customModelBinder el framework no lo toma
            // for AlumnoVM type, bind with the AlumnoVMModelBinder
            ModelBinders.Binders.Add(typeof(AlumnoTestBinderVM), new AlumnoVMModelBinder());
            ModelBinders.Binders.Add(typeof(EscuelaTestBinderVM), new EscuelaVMModelBinder());

            //Configuramos DisplayModes
            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("WinP")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                .IndexOf("Windows Phone OS", StringComparison.OrdinalIgnoreCase) > 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                .IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) > 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("Android")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                .IndexOf("Android", StringComparison.OrdinalIgnoreCase) > 0)
            });

        }
    }
}
