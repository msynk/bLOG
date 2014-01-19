using System.Globalization;
using bLOG.Core.Domain;
using bLOG.Core.Web.Handlers;
using bLOG.Data.Services;

namespace bLOG.Web.Handlers
{
  /// <summary>
  /// Summary description for HomeHandler
  /// </summary>
  public class PostHandler : bLOGViewHandler
  {
    protected override string ViewsFolder { get { return "Post"; } }
    protected override string PageTitle { get { return "POST!"; } }

    protected override string Render()
    {
      switch (Action.ToUpper())
      {
        case "SHOW":
          return Show();
        default:
          return RenderUnknownRequest();
      }
    }

    private string Show()
    {
      var post = PostService.Get(Id);
      if (post == null) return RenderUnknownRequest();

      var postView = View("Show");
      postView.Reset();
      postView.Add("Id", post.Id.ToString(CultureInfo.InvariantCulture));
      postView.Add("Slug", post.Title.Replace(" ", "-"));
      postView.Add("Title", post.Title);
      postView.Add("Content", post.Content);
      postView.Add("PublishDate", post.PublishDate.ToString("D"));
      postView.Add("ViewsCount", post.ViewsCount.ToString(CultureInfo.InvariantCulture));
      return postView.Render();
    }
  }
}