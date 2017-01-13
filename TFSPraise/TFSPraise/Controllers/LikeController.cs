using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Models;
using TFSPraise.Entities;
using TFSPraise.Concrete;

namespace TFSPraise.Controllers
{
    public class LikeController : Controller
    {
        private RepositoryBase<Like> likeRepo;
        private RepositoryBase<UserProfile> userRepo;
        readonly int PageSize = 4;

        public LikeController(RepositoryBase<Like> _likeRepo, RepositoryBase<UserProfile> _userRepo)
        {
            likeRepo = _likeRepo;
            userRepo = _userRepo;
        }

        public ActionResult LikeList(int page = 1)
        {
            ListViewModel<Like> praiseListViewModel = new ListViewModel<Like>
            {
                List = likeRepo.GetAll().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = likeRepo.GetAll().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                }
            };
            return View(praiseListViewModel);
        }

        public ActionResult LikeRanking()
        {
            var usersOrdered = userRepo.GetAll().OrderByDescending(u=>u.Likes.Count).ToList();
            ViewBag.CurrentUserName = ((UserRepository)userRepo).GetCurrentUser().Identity.DispalyName;

            return PartialView(usersOrdered);
        }

        public ActionResult LikeChart()
        {
            Dictionary<int, int> chartDatas = new Dictionary<int, int>();
            var likeGroups = likeRepo.GetAll().GroupBy(l => l.Date.Month);
            foreach (var group in likeGroups)
            {
                chartDatas.Add(group.Key, group.ToList().Count);
            }

            return PartialView(chartDatas);
        }

        [ChildActionOnly]
        public int LikesWarning()
        {
            return likeRepo.GetAll().ToList().Count;
        }
    }
}