using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFSPraise.Entities
{
    public class Praise
    {
        public Praise()
        {
            Receivers = new List<Receiver>();
        }

        public int PraiseID { get; set; }
        public string OwnerID { get; set; }
        public string PraiseContent { get; set; }
        public DateTime PraiseDate { get; set; }

        public virtual ICollection<Receiver> Receivers { get; set; }

        public virtual User Praiser { get; set; }
    }
}