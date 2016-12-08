using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSPraise.Entities
{
    public class Blog
    {
        public string Content { get; set; }
        public int BlogID { get; set; }
        public string PublisherID { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual User Publisher { get; set; }
    }
}