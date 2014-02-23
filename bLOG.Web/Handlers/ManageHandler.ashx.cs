using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using bLOG.Core.Web.Handlers;
using bLOG.Core.Web.ViewEngines;
using bLOG.Data.Services;
using bLOG.Models;
using bLOG.Web.Framework.Services;

namespace bLOG.Web.Handlers
{
  public class ManageHandler : BaseHandler
  {
    protected override string ViewsFolder { get { return "Manage"; } }
    protected override string PageTitle { get { return _pageTitle; } }
    private string _pageTitle = "Manage";

    private struct Actions
    {
      public const string Index = "INDEX";
      public const string ShowAllPosts = "SHOWALLPOSTS";
      public const string ConfirmDelete = "CONFIRMDELETE";
      public const string Delete = "DELETE";
    }

    protected override IView ProcessRequestInternal()
    {
      switch (Action.ToUpper())
      {
        case Actions.Index:
          return Index();
        case Actions.ShowAllPosts:
          return ShowAllPosts();
        case Actions.ConfirmDelete:
          return ConfirmDelete();
        case Actions.Delete:
          return Delete();
      }
      return null;
    }





    private IView Index()
    {
      return Layout(View(Actions.Index));
    }

    private IView ShowAllPosts()
    {
      var username = Param("username");
      var password = Param("password");
      if (!SecurityService.Authenticate(username, password))
      {
        //throw new Exception("wrong username or password");
        return null;
      }

      var allposts = PostService.Get();
      return Layout(GetAllPostsView(allposts));
    }

    private IView GetAllPostsView(IEnumerable<Post> posts)
    {
      var allPostsView = View(Actions.ShowAllPosts);
      var postRowView = View("PostRow");
      var rows = "";
      foreach (var post in posts)
      {
        postRowView.Reset();
        postRowView.AddOrEdit("Id", post.Id);
        postRowView.AddOrEdit("Title", post.Title);
        postRowView.AddOrEdit("SiteUrl", Request.Url.Authority);
        rows += postRowView.Render();
      }
      allPostsView.AddOrEdit("PostRows", rows);
      return allPostsView;
    }

    private IView ConfirmDelete()
    {
      var view = View(Actions.ConfirmDelete);
      var post = PostService.Get(Id);
      if (post == null) return null;

      view.AddOrEdit("Id", post.Id);
      view.AddOrEdit("Title", post.Title);
      return Layout(view);
    }

    private IView Delete()
    {
      var username = Param("username");
      var password = Param("password");
      if (!SecurityService.Authenticate(username, password))
      {
        return null;
      }

      PostService.Delete(PostService.Get(Id));

      return new RedirectView("/Manage");
    }

  }
}