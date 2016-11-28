using System.Collections.Generic;
using TFSPraise.Domains;

namespace TFSPraise.Abstract
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
    }
}