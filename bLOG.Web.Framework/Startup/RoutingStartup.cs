using System.Web.Routing;
using bLOG.Core.Web.Routing;

namespace bLOG.Web.Framework.Startup
{
  class RoutingStartup
  {
    private static readonly RouteCollection Routes = RouteTable.Routes;
    public static void Start()
    {
      RegisterHandlers();
    }

    private static void RegisterHandlers()
    {
      Routes.MapHttpHandlerRoute("Home", "123", "~/Handlers/HomeHandler.ashx");
    }
  }
}
