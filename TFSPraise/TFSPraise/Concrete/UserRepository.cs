using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Entities;
using System.Security.Principal;
using System.Data.Entity;

namespace TFSPraise.Concrete
{
    public class UserRepository : RepositoryBase<UserProfile>
    {
        public UserProfile GetCurrentUser()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            UserProfile currentUserProfile = ((TFSPraiseContext)Context).UserProfiles.Where(u => u.Identity.Name == identity.Name).FirstOrDefault();
            if (currentUserProfile == null)
            {
                currentUserProfile = new UserProfile { Identity = new Identity { Name = identity.Name, DispalyName = "Ben Dong" }, Resign =  false };
                Add(currentUserProfile);
            }
            return currentUserProfile;
        }
    }
}