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
        private IBlogRepository blogRepo;
        private IUserRepository userRepo;
        readonly int PageSize = 4;
        public BlogController(IBlogRepository blogRepoParam, IUserRepository userRepoParam)
        {
            blogRepo = blogRepoParam;
            userRepo = userRepoParam;
        }
        public ActionResult Home(string id, int page = 1)
        {
            IEnumerable<Blog> blogs = string.IsNullOrEmpty(id) ? blogRepo.GetBlogs() : blogRepo.GetBlogs().Where(b => b.PublisherID == id);
            blogs = blogs.Reverse();
            ListViewModel<Blog> blogListViewModel = new ListViewModel<Blog>
            {
                List = blogs.Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            blog.PublisherID = userRepo.GetCurrentUser().ID;
            blog.PublishDate = DateTime.Now;
            blogRepo.CreateBlog(blog);

            return RedirectToAction("Home");
        }

    }
}