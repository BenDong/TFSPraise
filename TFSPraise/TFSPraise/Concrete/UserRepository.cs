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
    public class UserRepository : RepositoryBase<User>
    {
        public User GetCurrentUser()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            User currentUser = ((TFSPraiseContext)Context).Users.Where(x => x.ID == identity.Name).FirstOrDefault();
            if (currentUser == null)
            {
                currentUser = new User { ID = identity.Name, Name = "Ben Dong" };
                Add(currentUser);
            }
            return currentUser;
        }
    }
}