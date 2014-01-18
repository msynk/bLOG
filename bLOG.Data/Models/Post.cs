using System;
using System.Collections.Generic;

namespace bLOG.Data.Models
{
    public partial class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public System.DateTime PublishDate { get; set; }
        public System.DateTime LastModified { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
