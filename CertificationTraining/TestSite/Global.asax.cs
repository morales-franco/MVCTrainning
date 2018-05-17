using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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
        }
    }
}
