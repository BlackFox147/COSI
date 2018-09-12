using System.Collections.Generic;

namespace Laba2_ImageIdentification.Histogram.Models
{
    public class ChannelHistogram
    {
        public IDictionary<byte, int> Histogram { get; set; }

        public TypeOfСhannel TypeOfСhannel { get; set; }

        public ChannelHistogram(TypeOfСhannel typeOfСhannel)
        {
            Histogram = new Dictionary<byte, int>();
            TypeOfСhannel = typeOfСhannel;
        }
    }
}
