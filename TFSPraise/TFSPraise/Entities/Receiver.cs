using System.Collections.Generic;

namespace TFSPraise.Entities
{
    public class Receiver
    {
        public string Name { get; set; }
        public string ReceiverID { get; set; }
        public bool Resign { get; set; }

        public ICollection<Praise> Praises { get; set; }
    }
}