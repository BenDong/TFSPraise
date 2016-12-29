using System;
using System.Collections.Generic;

namespace TFSPraise.Entities
{
    public class Receiver
    {
        public Receiver()
        {
            Likes = new List<Like>();
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ID { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}