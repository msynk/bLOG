using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bLOG.Core.Web.ViewEngines
{
  public class RedirectView : IView
  {
    private readonly string _redirectUrl;

    public RedirectView(string redirectUrl)
    {
      _redirectUrl = redirectUrl;
    }

    public string Render()
    {
      return "";
    }

    public void Render(HttpContext context)
    {
      context.Response.Redirect(_redirectUrl);
    }
  }
}
