using System.Collections.Generic;
namespace TFSPraise.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public bool Resign { get; set; }

        public ICollection<Praise> PublishedPraises { get; set; }

        public ICollection<Blog> PublishedBlogs { get; set; }
    }
}