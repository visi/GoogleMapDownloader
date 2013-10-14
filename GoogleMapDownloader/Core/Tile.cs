using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core
{
    public class Tile
    {
        private int width = 256;
        private int height = 256;

        public Tile()
        {
        }
        public Tile(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public Tile(long x, long y, int zoom)
            : this(x, y)
        {
            this.Zoom = zoom;
        }

        public int Zoom { get; set; }

        public long X { get; set; }

        public long Y { get; set; }

        public string UrlPath { get; set; }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public DownloadZoom DownloadZoom { get; set; }
    }
}
