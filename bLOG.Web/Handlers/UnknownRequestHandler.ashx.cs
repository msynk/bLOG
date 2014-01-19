using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bLOG.Core.Web.Handlers;

namespace bLOG.Web.Handlers
{
  /// <summary>
  /// Summary description for UnknownRequestHandler
  /// </summary>
  public class UnknownRequestHandler : bLOGViewHandler
  {
    protected override string ViewsFolder { get { return ""; } }
    protected override string PageTitle { get { return "Unknown Request"; } }

    protected override string Render()
    {
      return RenderUnknownRequest();
    }
  }
}