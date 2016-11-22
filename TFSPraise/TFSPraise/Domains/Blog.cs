using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSPraise.Domains
{
    public class Blog
    {
        public string OwnerID { get; set; }
        public string Content { get; set; }
        public DateTime BlogTime { get; set; }
    }
}