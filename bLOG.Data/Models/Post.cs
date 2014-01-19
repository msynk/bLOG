using System;
using System.Collections.Generic;

namespace bLOG.Data.Models
{
    public partial class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public int ViewsCount { get; set; }
    }
}
