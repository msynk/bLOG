using System.Collections.Generic;
using System.IO;
using System.Web;

namespace bLOG.Core.Web.ViewEngines
{
  public static class Views
  {
    private static readonly Dictionary<string, string> ContentCache = new Dictionary<string, string>();
    private static readonly Dictionary<string, bLOGViewEngine> EngineCache = new Dictionary<string, bLOGViewEngine>();

    public static void Reset()
    {
      ContentCache.Clear();
      EngineCache.Clear();
    }

    public static void Register(string virtualPath)
    {
      if (ContentCache.ContainsKey(virtualPath))
      {
        ContentCache.Remove(virtualPath);
        EngineCache.Remove(virtualPath);
      }
      Add(virtualPath);
    }

    private static void Add(string virtualPath)
    {
      using (var reader = new StreamReader(HttpContext.Current.Server.MapPath(virtualPath)))
      {
        ContentCache.Add(virtualPath, reader.ReadToEnd());
        EngineCache.Add(virtualPath, new bLOGViewEngine(virtualPath));
      }
    }

    public static string GetContent(string virtualPath)
    {
      if(!ContentCache.ContainsKey(virtualPath)) Register(virtualPath);
      return ContentCache[virtualPath];
    }

    public static bLOGViewEngine GetViewEngine(string virtualPath)
    {
      if (!EngineCache.ContainsKey(virtualPath)) Register(virtualPath);
      return EngineCache[virtualPath];
    }
  }
}
