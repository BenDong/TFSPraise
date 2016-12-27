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

        public int ID { get; set; }
        public int OwnerID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual UserProfile Praiser { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
    }
}