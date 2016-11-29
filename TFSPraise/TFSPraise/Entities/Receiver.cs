using System.Collections.Generic;

namespace TFSPraise.Entities
{
    public class Receiver
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public bool Resign { get; set; }

        public ICollection<Praise> ReceivedPraises { get; set; }
    }
}