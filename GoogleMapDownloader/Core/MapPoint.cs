using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core
{
    public class MapPoint
    {
        private double x;
        private double y;

        public MapPoint()
        {
        }

        public MapPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
