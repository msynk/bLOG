using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web
{
  public static class WebConfig
  {
    public const string DefaultViewsFolder = "Views";
    public const string DefaultViewsExtention = "html";
    public const string DefaultLayoutViewName = "Layout";
    public const string DefaultNotFoundViewName = "404";

    public const string HanlderRoute = "handler";
    public const string ActionRoute = "action";
    public const string IdRoute = "id";



    public static ViewPathProvider PathProvider = new ViewPathProvider();

    public static string ViewTokenFormat = "@{0}";

    public static string PageTitleToken = "PageTitle";
    public static string PageBodyToken = "PageBody";


    

  }
}
