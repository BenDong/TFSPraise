using System.Collections.Generic;
namespace TFSPraise.Entities
{
    public class User
    {
        public User()
        {
            Praises = new List<Praise>();
            Blogs = new List<Blog>();
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public bool Resign { get; set; }
        public virtual ICollection<Praise> Praises { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}