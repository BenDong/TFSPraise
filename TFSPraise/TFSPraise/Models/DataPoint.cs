using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TFSPraise.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint()
        {

        }
        public DataPoint(int x, int y, string label)
        {
            this.X = x;
            this.Y = y;
            this.Label = label;
        }

        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name ="x")]
        public Nullable<int> X { get; set; }
        [DataMember(Name = "y")]
        public Nullable<int> Y { get; set; }
        [DataMember(Name = "z")]
        public Nullable<double> Z { get; set; }
    }
}