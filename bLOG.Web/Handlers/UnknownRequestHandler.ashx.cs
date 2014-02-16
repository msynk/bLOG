using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bLOG.Core.Web.Handlers;
using bLOG.Core.Web.ViewEngines;

namespace bLOG.Web.Handlers
{
  public class UnknownRequestHandler : BaseHandler
  {
    protected override string ViewsFolder { get { return ""; } }
    protected override string PageTitle { get { return "Unknown Request"; } }

    protected override IView ProcessRequestInternal()
    {
      return null;
    }
  }
}