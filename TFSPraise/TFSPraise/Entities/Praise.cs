using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFSPraise.Entities
{
    public class Praise
    {
        public int PraiseID { get; set; }
        public string OwnerID { get; set; }
        public string ReceivierID { get; set; }
        public string PraiseContent { get; set; }
        public DateTime PraiseDate { get; set; }

        public ICollection<Receiver> Receivers { get; set; }

        public User Praiser { get; set; }
    }
}