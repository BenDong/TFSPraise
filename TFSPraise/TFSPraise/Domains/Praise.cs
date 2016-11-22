using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSPraise.Domains
{
    public class Praise
    {
        public string OwnerID { get; set; }
        public string ReceivierID { get; set; }
        public string Content { get; set; }
        public DateTime PraiseTime { get; set; }
    }
}