using System;
using System.ComponentModel.DataAnnotations;

namespace TFSPraise.Entities
{
    public class Blog
    {
        [Key]
        public int BlogNo { get; set; }
        public string OwnerID { get; set; }
        public string Content { get; set; }
        public DateTime BlogTime { get; set; }
    }
}