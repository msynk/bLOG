using System;
using System.Globalization;
using System.Linq;
using bLOG.Core.Domain;
using bLOG.Core.Web.Handlers;
using bLOG.Core.Web.ViewEngines;
using bLOG.Data.Services;
using System.Configuration;
using bLOG.Core.Web;

namespace bLOG.Web.Handlers
{
  public class HomeHandler : BaseHandler
  {
    protected override string ViewsFolder { get { return "Home"; } }
    protected override string PageTitle { get { return "bLOG HOME!"; } }

    private struct Actions
    {
      public const string Index = "INDEX";
    }

    protected override IView ProcessRequestInternal()
    {
      switch (Action.ToUpper())
      {
        case Actions.Index:
          return Index();
      }
      return null;
    }

    public IView Index()
    {
      var indexView = View(Actions.Index);
      indexView.Add("Summaries", RenderSummaries());
      return Layout(indexView);
    }

    private string RenderSummaries()
    {
      var postSummaryView = View("PostSummary");
      var pageSize = int.Parse(WebConfig.AppSettings["Index.PageSize"]);
      var pageNumber = int.Parse(Id) - 1;
      var posts = PostService.Query.Skip(pageNumber * pageSize).Take(pageSize).OrderByDescending(p => p.PublishDate);

      var summaries = "";
      foreach (var post in posts)
      {
        postSummaryView.Reset();
        postSummaryView.Add("Id", post.Id.ToString(CultureInfo.InvariantCulture));
        postSummaryView.Add("Slug", post.Title.Replace(" ", "-"));
        postSummaryView.Add("Title", post.Title);
        var content = post.Content;
        var index = content.IndexOf("<summary />", StringComparison.Ordinal);
        postSummaryView.Add("Content", content.Substring(0, index > 0 ? index : 500) + "...");
        postSummaryView.Add("PublishDate", post.PublishDate.ToString("D"));
        postSummaryView.Add("ViewsCount", post.ViewsCount.ToString(CultureInfo.InvariantCulture));
        summaries += postSummaryView.Render();
      }
      return summaries;
    }
  }
}