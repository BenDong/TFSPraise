using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Domains;

namespace TFSPraise.Concrete
{
    public class PraiseRepository : IPraiseRepository
    {
        TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<Praise> GetPraises()
        {
            return context.Praises;
        }
    }
}