using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSPraise.Entities
{
    public class Identity
    {
        public int IdentityID { get; set; }
        public string Name { get; set; }
        public string DispalyName { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}