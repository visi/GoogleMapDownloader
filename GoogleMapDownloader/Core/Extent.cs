using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core
{
    public class Extent
    {
        public Extent()
        {
        }

        public Extent(double minLon, double minLat, double maxLon, double maxLat)
        {
            this.MinLongitude = minLon;
            this.MinLatitude = minLat;
            this.MaxLongitude = maxLon;
            this.MaxLatitude = maxLat;
        }

        public double MinLongitude { get; set; }

        public double MaxLongitude { get; set; }

        public double MinLatitude { get; set; }

        public double MaxLatitude { get; set; }
    }
}
