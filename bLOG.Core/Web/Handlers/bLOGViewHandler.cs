using System.Web;
using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web.Handlers
{
  public abstract class bLOGViewHandler : IHttpHandler
  {
    protected HttpContext Context;

    #region IHttpHandler

    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
      Context = context;
      context.Response.Write(GenerateResponse());
    }

    #endregion

    private static readonly bLOGViewEngine LayoutView = GetView(WebConfig.PathProvider.LayoutView);
    private static readonly bLOGViewEngine UnknownRequestView = GetView(WebConfig.PathProvider.UnknownRequestView);

    private static bLOGViewEngine GetView(string virtualPath)
    {
      return Views.GetViewEngine(virtualPath);
    }


    protected bLOGViewEngine View(string viewName)
    {
      return GetView(WebConfig.PathProvider.Get(ViewsFolder, viewName));
    }

    protected object Route(string key)
    {
      return Context.Request.RequestContext.RouteData.Values[key];
    }

    protected string RenderUnknownRequest()
    {
      return UnknownRequestView.Render();
    }

    protected string Handler { get { return Route(WebConfig.HanlderRoute).ToString(); } }
    protected string Action { get { return Route(WebConfig.ActionRoute).ToString(); } }
    protected string Id { get { return Route(WebConfig.IdRoute).ToString(); } }


    protected abstract string ViewsFolder { get; }
    protected abstract string PageTitle { get; }
    protected abstract string Render();


    private string GenerateResponse()
    {
      LayoutView.Reset();
      LayoutView.Add(WebConfig.PageTitleToken, PageTitle);
      LayoutView.Add(WebConfig.PageBodyToken, Render());

      return LayoutView.Render();
    }
  }
}
