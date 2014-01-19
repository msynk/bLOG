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

    public string ViewsExtension { get; private set; }
    public ViewPathProvider(string viewsFolder = WebConfig.DefaultViewsFolder, string layoutFileName = WebConfig.DefaultLayoutViewName, string viewsExtention = WebConfig.DefaultViewsExtention)
    {
      ViewsFolder = viewsFolder;
      LayoutFileName = layoutFileName;
      ViewsExtension = viewsExtention;
    }

    private string GetFullName(string name)
    {
      return string.Format("{0}.{1}", name, ViewsExtension);
    }

    public string Layout { get { return Path.Combine(ViewsFolder, GetFullName(LayoutFileName)); } }

    public string Get(string folder, string name)
    {
      return Path.Combine(ViewsFolder, folder, GetFullName(name));
    }
  }
}
