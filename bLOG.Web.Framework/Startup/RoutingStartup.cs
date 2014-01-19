using System.Web.Routing;
using bLOG.Core.Web;
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
      Routes.Ignore("metaweblog");
      Routes.MapHttpHandlerRoute("Global",
        string.Format("{{{0}}}/{{{1}}}/{{{2}}}/{{*pathInfo}}", WebConfig.HanlderRoute, WebConfig.ActionRoute, WebConfig.IdRoute),
        string.Format("~/Handlers/{{{0}}}Handler.ashx", WebConfig.HanlderRoute),
        new RouteValueDictionary { { WebConfig.HanlderRoute, "Home" }, { WebConfig.ActionRoute, "Index" }, { WebConfig.IdRoute, "" } });
    }
  }
}
