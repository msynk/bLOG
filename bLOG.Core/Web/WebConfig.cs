using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web
{
  public static class WebConfig
  {
    public const string ViewsFolder = "Views";
    public const string ViewsExtention = "html";
    public const string LayoutViewName = "Layout";
    public const string NotFoundViewName = "404";

    public const string HanlderRoute = "handler";
    public const string ActionRoute = "action";
    public const string IdRoute = "id";

    public static string ViewTokenFormat = "@{0}";

    public static string PageTitleToken = "PageTitle";
    public static string PageBodyToken = "PageBody";


    public static ViewPathProvider ViewPathProvider = ViewPathProvider.Default;
  }
}
