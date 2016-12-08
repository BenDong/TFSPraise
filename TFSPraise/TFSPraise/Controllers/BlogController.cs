using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Entities;
using TFSPraise.Models;

namespace TFSPraise.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repo;
        readonly int pageSize = 4;
        public BlogController(IBlogRepository repoParam)
        {
            repo = repoParam;
        }
        public ActionResult Home(string id = null, int page = 0)
        {
            IEnumerable<Blog> blogs = repo.GetBlogs().Where(b => b.PublisherID == id || id == null);
            ListViewModel<Blog> blogListViewModel = new ListViewModel<Blog>
            {
                ItemList = blogs.Skip(pageSize * (page - 1)).Take(pageSize).ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = blogs.ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                }
            };

            return View(blogListViewModel);
        }
    }
}