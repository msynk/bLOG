using System;
using System.Globalization;
using System.Linq;
using bLOG.Core.Domain;
using bLOG.Core.Web.Handlers;
using bLOG.Core.Web.ViewEngines;
using bLOG.Data.Services;
using System.Configuration;
using bLOG.Core.Web;
using System.Collections.Generic;
using bLOG.Models;

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
      Render(indexView);
      return Layout(indexView);
    }

    private void Render(BasicViewEngine view)
    {
      int pageNumber;
      var number = Query("p");
      if (string.IsNullOrEmpty(number))
      {
        number = "1";
      }
      if (!int.TryParse(number, out pageNumber))
      {
        pageNumber = 1;
      }
      var pageSize = int.Parse(WebConfig.AppSettings["Index.PageSize"]);
      var skip = (pageNumber - 1) * pageSize;
      var posts = PostService.Query.OrderByDescending(p => p.PublishDate).Skip(skip).Take(pageSize).ToList();
      var totalPosts = PostService.Query.Count();
      var totalPages = totalPosts / pageSize;
      if (totalPages * pageSize != totalPosts) totalPages++;

      if (pageNumber > totalPages) Context.Response.Redirect("/");

      view.AddOrEdit("FirstPageTitleDisplay", pageNumber == 1 ? "block" : "none");

      RenderSummaries(view, posts);
      RenderPaging(view, pageNumber, totalPages);
    }

    private static void RenderPaging(BasicViewEngine view, int pageNumber, int totalPages)
    {
      var prevPageNumber = pageNumber + 1;
      view.AddOrEdit("PrevPage", prevPageNumber);
      view.AddOrEdit("PrevVisibility", prevPageNumber > totalPages ? "hidden" : "visible");

      var nextPageNumber = pageNumber - 1;
      view.AddOrEdit("NextPage", nextPageNumber);
      view.AddOrEdit("NextVisibility", nextPageNumber < 1 ? "hidden" : "visible");
    }

    private void RenderSummaries(BasicViewEngine view, IEnumerable<Post> posts)
    {
      var postSummaryView = View("PostSummary");
      var summaries = "";
      foreach (var post in posts)
      {
        postSummaryView.Reset();
        postSummaryView.AddOrEdit("Id", post.Id);
        postSummaryView.AddOrEdit("Slug", post.Title.Replace(" ", "-"));
        postSummaryView.AddOrEdit("Title", post.Title);
        var content = post.Content;
        var index = content.IndexOf("<summary />", StringComparison.Ordinal);
        postSummaryView.AddOrEdit("Content", content.Substring(0, index > 0 ? index : 500) + "...");
        postSummaryView.AddOrEdit("PublishDate", post.PublishDate.ToString("D"));
        postSummaryView.AddOrEdit("ViewsCount", post.ViewsCount);
        summaries += postSummaryView.Render();
      }
      view.AddOrEdit("Summaries", summaries);
    }
  }
}