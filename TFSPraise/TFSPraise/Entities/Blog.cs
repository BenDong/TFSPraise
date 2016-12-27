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
        public int ID { get; set; }
        public int PublisherID { get; set; }
        public DateTime Date { get; set; }
        public virtual UserProfile Publisher { get; set; }
    }
}