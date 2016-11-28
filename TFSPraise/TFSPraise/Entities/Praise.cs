using System;
using System.ComponentModel.DataAnnotations;

namespace TFSPraise.Entities
{
    public class Praise
    {
        [Key]
        public int PraiseID { get; set; }
        public string OwnerID { get; set; }
        public string ReceivierID { get; set; }
        public string Content { get; set; }
        public DateTime PraiseDate { get; set; }
    }
}