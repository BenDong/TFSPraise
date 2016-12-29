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

        public UserController(RepositoryBase<UserProfile> _userRepo)
        {
            userRepo = _userRepo;
        }

        [ChildActionOnly]
        public ActionResult CurrentUser()
        {
            UserProfile CurrentUserProfile = ((UserRepository)userRepo).GetCurrentUser();
            if(CurrentUserProfile == null)
            {
                return HttpNotFound("Not found current user");
            }

            return PartialView(CurrentUserProfile);
        }
    }
}