using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bLOG.Core.Web.ViewEngines
{
  public class BasicViewEngine : IView
  {
    private readonly string _virtualPath;
    private readonly Dictionary<string, string> _replacements = new Dictionary<string, string>();

    public BasicViewEngine(string virtualPath)
    {
      _virtualPath = virtualPath;
    }

    public void Reset()
    {
      _replacements.Clear();
    }

    public void Add(string token, string value)
    {
      _replacements.Add(token, value);
    }

    public string Render()
    {
      return _replacements.Aggregate(Views.GetContent(_virtualPath),
        (current, replacement) =>
          current.Replace(string.Format(WebConfig.ViewTokenFormat, replacement.Key), replacement.Value));
    }

    public void Render(HttpContext context)
    {
      context.Response.Write(Render());
    }
  }
}
