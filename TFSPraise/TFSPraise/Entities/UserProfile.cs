using System;
using System.Collections.Generic;
namespace TFSPraise.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Praises = new List<Praise>();
            Blogs = new List<Blog>();
        }
        public int ID { get; set; }
        public bool Resign { get; set; }
        public virtual Identity Identity { get; set; }
        public virtual ICollection<Praise> Praises { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}