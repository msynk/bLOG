using System.Web;
using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web.Handlers
{
  public abstract class BaseHandler : IHttpHandler
  {
    protected HttpContext Context;

    #region IHttpHandler

    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
      Context = context;
      var view = ProcessRequestInternal() ?? Views.UnknownRequestView;
      view.Render(context);
    }

    #endregion

    protected abstract IView ProcessRequestInternal();
    protected abstract string ViewsFolder { get; }
    protected abstract string PageTitle { get; }

    protected string Handler { get { return Route(WebConfig.HanlderRoute).ToString(); } }
    protected string Action { get { return Route(WebConfig.ActionRoute).ToString(); } }
    protected string Id { get { return Route(WebConfig.IdRoute).ToString(); } }



    protected BasicViewEngine View(string viewName)
    {
      return Views.GetViewEngine(WebConfig.ViewPathProvider.GetPath(ViewsFolder, viewName));
    }

    protected object Route(string key)
    {
      return Context.Request.RequestContext.RouteData.Values[key];
    }

    protected BasicViewEngine Layout(IView view)
    {
      var layoutView = Views.LayoutView;
      layoutView.Add(WebConfig.PageTitleToken, PageTitle);
      layoutView.Add(WebConfig.PageBodyToken, view.Render());

      return layoutView;
    }
  }
}
