using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Domains;

namespace TFSPraise.Concrete
{
    public class BlogRepository : IBlogRepository
    {
        TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blogs;
        }
    }
}