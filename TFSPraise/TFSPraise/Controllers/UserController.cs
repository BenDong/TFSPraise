using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Entities;
using TFSPraise.Concrete;

namespace TFSPraise.Controllers
{
    public class UserController : Controller
    {
        RepositoryBase<UserProfile> userRepo;
        UserProfile CurrentUserProfile;

        public UserController(RepositoryBase<UserProfile> _userRepo)
        {
            userRepo = _userRepo;
            CurrentUserProfile = userRepo.Contravariant<UserRepository>().GetCurrentUser();
        }

        [ChildActionOnly]
        public ActionResult CurrentUser()
        {
            return PartialView(CurrentUserProfile);
        }
    }
}