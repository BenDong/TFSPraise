using System.Collections.Generic;

namespace TFSPraise.Entities
{
    public class Receiver
    {
        public Receiver()
        {
            Praises = new List<Praise>();
        }
        public string Name { get; set; }
        public string ReceiverID { get; set; }
        public bool Resign { get; set; }

        public virtual ICollection<Praise> Praises { get; set; }
    }
}