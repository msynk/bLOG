using System;
using System.Collections.Generic;

namespace bLOG.Data.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }
    }
}
