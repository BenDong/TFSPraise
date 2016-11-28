using System.Collections.Generic;
using TFSPraise.Entities;

namespace TFSPraise.Abstract
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
    }
}