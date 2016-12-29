using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Models;
using TFSPraise.Entities;

namespace TFSPraise.Controllers
{
    public class LikeController : Controller
    {
        private RepositoryBase<Like> likeRepo;
        readonly int PageSize = 4;

        public LikeController(RepositoryBase<Like> _likeRepo)
        {
            likeRepo = _likeRepo;
        }
   
        public ActionResult LikeList(int page = 1)
        {
            ListViewModel<Like> praiseListViewModel = new ListViewModel<Like>
            {
                List = likeRepo.GetAll().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo {
                    TotalItems = likeRepo.GetAll().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize }
            };
            return View(praiseListViewModel);
        }
    }
}