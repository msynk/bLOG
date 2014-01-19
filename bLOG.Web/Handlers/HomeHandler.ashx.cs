using System.Globalization;
using bLOG.Core.Domain;
using bLOG.Core.Web.Handlers;
using bLOG.Data.Services;

namespace bLOG.Web.Handlers
{
  /// <summary>
  /// Summary description for HomeHandler
  /// </summary>
  public class HomeHandler : bLOGViewHandler
  {
    protected override string ViewsFolder { get { return "Home"; } }
    protected override string PageTitle { get { return "bLOG HOME!"; } }

    protected override string Render()
    {
      switch (Action.ToUpper())
      {
        case "INDEX":
          return Index();
        default:
          return RenderUnknownRequest();
      }
    }

    public string Index()
    {
      var indexView = View("Index");
      indexView.Add("Summaries", RenderSummaries());
      return indexView.Render();
    }

    private string RenderSummaries()
    {
      var postSummaryView = View("PostSummary");
      var summaries = "";
      foreach (var post in PostService.Get())
      {
        postSummaryView.Reset();
        postSummaryView.Add("Id", post.Id.ToString(CultureInfo.InvariantCulture));
        postSummaryView.Add("Slug", post.Title.Replace(" ", "-"));
        postSummaryView.Add("Title", post.Title);
        postSummaryView.Add("Content", post.Content);
        postSummaryView.Add("PublishDate", post.PublishDate.ToString("D"));
        postSummaryView.Add("ViewsCount", post.ViewsCount.ToString(CultureInfo.InvariantCulture));
        summaries += postSummaryView.Render();
      }
      return summaries;
    }
  }
}