using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Entities;

namespace TFSPraise.Concrete
{
    public class ReceiverRepository : IReceiverRepository
    {
        private TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<Receiver> GetReceivers()
        {
            return context.Receivers;
        }
    }
}