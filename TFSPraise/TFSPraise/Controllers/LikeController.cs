using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Models;
using TFSPraise.Entities;
using TFSPraise.Concrete;
using Newtonsoft.Json;

namespace TFSPraise.Controllers
{
    public class LikeController : Controller
    {
        private RepositoryBase<Like> likeRepo;
        private RepositoryBase<UserProfile> userRepo;
        private RepositoryBase<Receiver> receiverRepo;
        private UserProfile CurrentUser;
        readonly int PageSize = 4;

        public LikeController(RepositoryBase<Like> _likeRepo, RepositoryBase<UserProfile> _userRepo, RepositoryBase<Receiver> _receiverRepo)
        {
            likeRepo = _likeRepo;
            userRepo = _userRepo;
            receiverRepo = _receiverRepo;
            CurrentUser = ((UserRepository)userRepo).GetCurrentUser();
        }

        [HttpGet]
        public ActionResult LikeCreate()
        {
            ViewBag.AvailableReceivers = receiverRepo.GetAll().Select(r => new { DisplayName = r.DisplayName, ID = r.ID }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult LikeCreate(Like like)
        {
            like.SponsorID = CurrentUser.IdentityID;
            like.Date = DateTime.Now;
            likeRepo.Add(like);

            return RedirectToAction("LikeList");
        }

        public ActionResult LikeList(int page = 1)
        {
            ListViewModel<Like> likeListViewModel = new ListViewModel<Like>
            {
                List = likeRepo.GetAll().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = likeRepo.GetAll().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                }
            };
            return View(likeListViewModel);
        }

        public ActionResult LikeRanking()
        {
            var usersOrdered = userRepo.GetAll().OrderByDescending(u => u.Likes.Count).ToList();
            ViewBag.CurrentUserName = CurrentUser.Identity.DispalyName;

            return PartialView(usersOrdered);
        }

        public ActionResult LikeChart()
        {
            int axisXVal = 0;//AxisX value starts from 0 then increase 1 per time
            string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            List<DataPoint> dataPoints = new List<DataPoint>();

            var likeGroups = likeRepo.Get(x => x.Date.Year == DateTime.Now.Year).GroupBy(l => l.Date.Month).OrderBy(x => x.Key);
            likeGroups.ToList().ForEach(group =>
            {
                axisXVal++;
                dataPoints.Add(new DataPoint(axisXVal, group.Count(), months[group.Key - 1]));
            });

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return PartialView();
        }

        [ChildActionOnly]
        public int LikesWarning()
        {
            return likeRepo.GetAll().ToList().Count;
        }
    }
}