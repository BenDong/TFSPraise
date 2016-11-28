using System;

namespace TFSPraise.Domains
{
    public class Blog
    {
        //Foreign key
        public string OwnerID { get; set; }
        public string Content { get; set; }
        public DateTime BlogTime { get; set; }
    }
}