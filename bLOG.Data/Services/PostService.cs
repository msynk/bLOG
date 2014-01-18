using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bLOG.Data.Models;

namespace bLOG.Data.Services
{
  public class PostService : DataService<Post>
  {
    public static PostService Instance { get { return new PostService(); } }
  }
}
