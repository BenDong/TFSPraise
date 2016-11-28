using System;

namespace TFSPraise.Domains
{
    public class Praise
    {
        public string OwnerID { get; set; }
        public string ReceivierID { get; set; }
        public string Content { get; set; }
        public DateTime PraiseDate { get; set; }
    }
}