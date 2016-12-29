using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSPraise.Entities
{
    public class Blog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostID { get; set; }
        public int PosterID { get; set; }
        public DateTime Date { get; set; }
        public virtual UserProfile Poster { get; set; }
    }
}