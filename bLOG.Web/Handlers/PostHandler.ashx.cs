using System.Globalization;
using bLOG.Core.Web.Handlers;
using bLOG.Core.Web.ViewEngines;
using bLOG.Data.Services;
using bLOG.Models;

namespace bLOG.Web.Handlers
{
  public class PostHandler : BaseHandler
  {
    protected override string ViewsFolder { get { return "Post"; } }
    protected override string PageTitle { get { return _pageTitle; } }
    private string _pageTitle = "POST!";

    private struct Actions
    {
      public const string Show = "SHOW";
    }

    protected override IView ProcessRequestInternal()
    {
      switch (Action.ToUpper())
      {
        case Actions.Show:
          return ShowPost();
      }
      return null;
    }

    private IView ShowPost()
    {
      var post = PostService.Get(Id);
      if (post == null) return null;

      _pageTitle = post.Title;
      post.ViewsCount += 1;
      PostService.Edit(post);

      return Layout(GetPostView(post));
    }

    private IView GetPostView(Post post)
    {
      var postView = View(Actions.Show);
      postView.Reset();
      postView.Add("Id", post.Id.ToString(CultureInfo.InvariantCulture));
      postView.Add("Slug", post.Title.Replace(" ", "-"));
      postView.Add("Title", post.Title);
      postView.Add("Content", post.Content);
      postView.Add("PublishDate", post.PublishDate.ToString("D"));
      postView.Add("ViewsCount", post.ViewsCount.ToString(CultureInfo.InvariantCulture));
      return postView;
    }
  }
}