using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Entities;

namespace TFSPraise.Concrete
{
    public class UserRepository : IUserRepository
    {
        TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }
    }
}