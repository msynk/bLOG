using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web
{
  public static class WebConfig
  {
    public const string DefaultViewsFolder = "Views";
    public const string DefaultViewsExtention = "html";
    public const string DefaultLayoutViewName = "Layout";


    public static ViewPathProvider PathProvider = new ViewPathProvider();

    public static string ViewTokenFormat = "@{0}";

    public static string PageTitleToken = "PageTitle";
    public static string PageBodyToken = "PageBody";
    
  }
}
