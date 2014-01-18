using System;
using System.Web.Routing;

namespace bLOG.Core.Web.Routing
{
  public static class RouteCollectionExtentions
  {
    public static Route MapHttpHandlerRoute(this RouteCollection routes, string routeName, string routeUrl, string handlerPath, RouteValueDictionary defaults = null, RouteValueDictionary constraints = null, RouteValueDictionary dataTokens = null)
    {
      if (routeUrl == null) throw new ArgumentNullException("routeUrl");
      
      var route = new Route(routeUrl, defaults, constraints, dataTokens, new HttpHandlerRouteHandler(handlerPath));
      routes.Add(routeName, route);
      return route;
    }
  }
}
