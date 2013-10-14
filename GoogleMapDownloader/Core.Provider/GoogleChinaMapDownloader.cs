using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core.Provider
{
    public class GoogleChinaMapDownloader : MapServerDownloader
    {
        public string SecureWord = "Galileo";
        static readonly string Sec1 = "&s=";

        public GoogleChinaMapDownloader()
            : base()
        {
            urlFormat = "http://mt{0}.google.com/vt/lyrs=m@170&hl=zh-CN&gl=cn&x={1}{2}&y={3}&z={4}&s={5}";
        }

        public GoogleChinaMapDownloader(Extent downloadExtent, int minDownloadZoom, int maxDownloadZoom)
            : base(downloadExtent, minDownloadZoom, maxDownloadZoom)
        {
            urlFormat = "http://mt{0}.google.com/vt/lyrs=m@170&hl=zh-CN&gl=cn&x={1}{2}&y={3}&z={4}&s={5}";
        }

        public override string MapType
        {
            get { return "googleChinaMap"; }
        }
        protected static int GetServerNum(Tile tile, int max)
        {
            return (int)(tile.X + 2 * tile.Y) % max;
        }

        protected void GetSecureWords(Tile tile, out string sec1, out string sec2)
        {
            sec1 = string.Empty; // after &x=...
            sec2 = string.Empty; // after &zoom=...
            int seclen = (int)((tile.X * 3) + tile.Y) % 8;
            sec2 = SecureWord.Substring(0, seclen);
            if (tile.Y >= 10000 && tile.Y < 100000)
            {
                sec1 = Sec1;
            }
        }

        public override void GetTilePath(Tile tile)
        {
            string sec1 = string.Empty; // after &x=...
            string sec2 = string.Empty; // after &zoom=...
            GetSecureWords(tile, out sec1, out sec2);
            tile.UrlPath = string.Format(urlFormat, GetServerNum(tile, 4), tile.X.ToString(), sec1, tile.Y.ToString(), tile.Zoom.ToString(), sec2);
        }
    }
}
