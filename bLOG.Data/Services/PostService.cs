using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bLOG.Models;

namespace bLOG.Data.Services
{
  public class PostService : DataService<Post>
  {
    //public static PostService Instance { get { return new PostService(); } }

    public static Post Get(string id)
    {
      return Set.SingleOrDefault(p => p.Id == id);
    }

    public static List<Post> Take(int count)
    {
      return Set.Take(count).ToList();
    }
  }
}
