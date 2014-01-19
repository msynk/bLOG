using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bLOG.Core.Web.ViewEngines
{
  public class ViewPathProvider
  {
    public string ViewsFolder { get; private set; }
    public string LayoutFileName { get; private set; }
    public string NotFoundFileName { get; private set; }

    public string ViewsExtension { get; private set; }
    public ViewPathProvider(string viewsFolder = WebConfig.DefaultViewsFolder, 
      string viewsExtention = WebConfig.DefaultViewsExtention,
      string layoutFileName = WebConfig.DefaultLayoutViewName, 
      string notFoundFileName = WebConfig.DefaultNotFoundViewName)
    {
      ViewsFolder = viewsFolder;
      ViewsExtension = viewsExtention;
      LayoutFileName = layoutFileName;
      NotFoundFileName = notFoundFileName;
    }

    private string GetFullName(string name)
    {
      return string.Format("{0}.{1}", name, ViewsExtension);
    }

    public string LayoutView { get { return Path.Combine(ViewsFolder, GetFullName(LayoutFileName)); } }
    public string UnknownRequestView { get { return Path.Combine(ViewsFolder, GetFullName(NotFoundFileName)); } }

    public string Get(string folder, string name)
    {
      return Path.Combine(ViewsFolder, folder, GetFullName(name));
    }
  }
}
