using System.Web;

namespace bLOG.Core.Web.ViewEngines
{
  public interface IView
  {
    void Render(HttpContext context);

    string Render();
  }
}
