using System;
using System.Collections.Generic;
namespace TFSPraise.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Likes = new List<Like>();
            Blogs = new List<Blog>();
        }
        public int IdentityID { get; set; }
        public bool Resign { get; set; }
        public virtual Identity Identity { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}