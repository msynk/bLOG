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

    private static readonly bLOGViewEngine LayoutView = GetView(WebConfig.PathProvider.Layout);

    private static bLOGViewEngine GetView(string virtualPath)
    {
      return Views.GetViewEngine(virtualPath);
    }


    protected bLOGViewEngine View(string viewName)
    {
      return GetView(WebConfig.PathProvider.Get(ViewsFolder, viewName));
    }


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
