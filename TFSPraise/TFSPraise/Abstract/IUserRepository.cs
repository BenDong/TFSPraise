using System.Collections.Generic;
using TFSPraise.Entities;

namespace TFSPraise.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}