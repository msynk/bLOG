using System;
using bLOG.Core.Domain;
using bLOG.Core.Web.ViewEngines;
using bLOG.Web.Framework.Startup;

namespace bLOG.Web
{
  public class Global : System.Web.HttpApplication
  {

    protected void Application_Start(object sender, EventArgs e)
    {
      AppStarter.Start();
    }

    protected void Session_Start(object sender, EventArgs e)
    {

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
      Views.Reset();
      System.Threading.Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {

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