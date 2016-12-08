using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Entities;

namespace TFSPraise.Models
{
    public class PraiseListViewModel
    {
        public IEnumerable<Praise> PraiseList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}