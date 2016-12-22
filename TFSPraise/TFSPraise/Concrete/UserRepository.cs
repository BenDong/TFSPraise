using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Entities;
using System.Security.Principal;

namespace TFSPraise.Concrete
{
    public class UserRepository : IUserRepository
    {
        TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User GetCurrentUser()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            User currentUser = context.Users.Where(x => x.ID == identity.Name).FirstOrDefault();
            if (currentUser == null)
            {
                currentUser = new User { ID = identity.Name, Name = "Ben Dong" };
                AddUser(currentUser);
            }
            return currentUser;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}