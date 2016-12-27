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
        private RepositoryBase<Blog> blogRepo;
        readonly int PageSize = 4;

        public BlogController(RepositoryBase<Blog> _blogRepo)
        {
            blogRepo = _blogRepo;
        }
        public ActionResult Home(string id, int page = 1)
        {
            IEnumerable<Blog> blogs = string.IsNullOrEmpty(id) ? blogRepo.GetAll() : blogRepo.GetAll().Where(b => b.PublisherID.Replace("\\", "/") == id);
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
            var currentUser = new TFSPraise.Concrete.UserRepository().GetCurrentUser();
            blog.PublisherID = currentUser.ID;
            blog.PublishDate = DateTime.Now;
            blogRepo.Add(blog);

            return RedirectToAction("Home", new { id = currentUser.ID, page = 1 });
        }

    }
}