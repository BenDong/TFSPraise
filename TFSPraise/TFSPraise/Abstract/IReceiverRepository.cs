using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Entities;

namespace TFSPraise.Abstract
{
    public interface IReceiverRepository
    {
        IEnumerable<Receiver> GetReceivers();
    }
}