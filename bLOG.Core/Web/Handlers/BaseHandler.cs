﻿using System.Web;
using bLOG.Core.Web.ViewEngines;

namespace bLOG.Core.Web.Handlers
{
  public abstract class BaseHandler : IHttpHandler
  {
    public HttpContext Context { get; private set; }
    public HttpRequest Request { get { return Context == null ? null : Context.Request; } }
    public HttpResponse Response { get { return Context == null ? null : Context.Response; } }

    #region IHttpHandler

    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
      Context = context;
      var view = ProcessRequestInternal() ?? Views.UnknownRequestView;
      view.Render(context);
    }

    #endregion

    protected abstract IView ProcessRequestInternal();
    protected abstract string ViewsFolder { get; }
    protected abstract string PageTitle { get; }

    protected string Handler { get { return Route(WebConfig.HanlderRoute).ToString(); } }
    protected string Action { get { return Route(WebConfig.ActionRoute).ToString(); } }
    protected string Id { get { return Route(WebConfig.IdRoute).ToString(); } }



    protected BasicViewEngine View(string viewName)
    {
      var view = Views.GetViewEngine(WebConfig.ViewPathProvider.GetPath(ViewsFolder, viewName));
      view.Reset();
      return view;
    }

    protected object Route(string key)
    {
      return Request.RequestContext.RouteData.Values[key];
    }
    protected string Query(string name)
    {
      return Request.QueryString[name];
    }

    protected string Param(string name)
    {
      return Request.Params[name];
    }

    protected BasicViewEngine Layout(IView view)
    {
      var layoutView = Views.LayoutView;
      layoutView.AddOrEdit(WebConfig.PageTitleToken, PageTitle);
      layoutView.AddOrEdit(WebConfig.PageBodyToken, view.Render());

      return layoutView;
    }
  }
}
