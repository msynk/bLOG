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
      var postSummaryView = View("PostSummary");
      var summaries = "";
      foreach (var post in PostService.Instance.Get())
      {
        postSummaryView.Reset();
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