using dibk.digitek.veiviser.App_Start;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using CamundaClient;

namespace dibk.digitek.veiviser
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var culture = new CultureInfo("nb-NO");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected void Session_Start(object sender, EventArgs e)
        {



        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Console.WriteLine("\n\n" + "Deploying Models + Forms and start External Task Workers.\n\nPRESS ANY KEY TO STOP WORKERS.\n\n");
            CamundaEngineClient camunda = new CamundaEngineClient();
            try
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                camunda.Startup(assemblyName); // Deploys all models to Camunda and Start all found ExternalTask-Workers
                //bool serverOK = BranntekniskProsjektering.Program.runn();
            }
            catch (Exception exception)
            {
                Console.WriteLine("\n\n" + "Can't deploy to Server.\n\n");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }
}