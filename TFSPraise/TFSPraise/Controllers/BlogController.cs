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
        readonly int PageSize = 4;
        public BlogController(IBlogRepository repoParam)
        {
            repo = repoParam;
        }
        public ActionResult HomePage(string id, int page = 0)
        {
            IEnumerable<Blog> blogs = string.IsNullOrEmpty(id) ? repo.GetBlogs() : repo.GetBlogs().Where(b => b.PublisherID == id);
            ListViewModel<Blog> blogListViewModel = new ListViewModel<Blog>
            {
                ItemList = blogs.Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = blogs.ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                }
            };
            ViewBag.BlogerID = id;
  
            return View(blogListViewModel);
        }
    }
}