using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFSPraise.Entities
{
    public class Like
    {
        public Like()
        {
            Receivers = new List<Receiver>();
        }

        public int LikeID { get; set; }
        public int SponsorID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual UserProfile Sponsor { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
    }
}