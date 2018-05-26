using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using RedSocial_Programacionlll.App_Start;

namespace RedSocial_Programacionlll
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}