using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using bLOG.Data.Services;

namespace bLOG.Web.Handlers
{
  /// <summary>
  /// Summary description for HomeHandler
  /// </summary>
  public class HomeHandler : IHttpHandler
  {
    private HttpContext _context;
    public bool IsReusable
    {
      get
      {
        return false;
      }
    }

    public void ProcessRequest(HttpContext context)
    {
      _context = context;
      //context.Response.ContentType = "text/plain";
      context.Response.Clear();
      context.Response.Write(GenerateResponse());
    }


    private string GenerateResponse()
    {
      var layout = "";
      using (var reader = new StreamReader(_context.Server.MapPath("~/Views/Layout.html")))
      {
        layout = reader.ReadToEnd();
      }
      var postSummary = "";
      using (var reader = new StreamReader(_context.Server.MapPath("~/Views/Home/PostSummary.html")))
      {
        postSummary = reader.ReadToEnd();
      }

      var posts = PostService.Instance.Get();
      var summaries = "";
      foreach (var post in posts)
      {
        var summary = postSummary.Replace("@Title", post.Title).Replace("@Content", post.Content);
        summaries += summary + Environment.NewLine;
      }
      return layout.Replace("@PageTitle", "hahahahahaha!").Replace("@Body", summaries);
    }

  }
}