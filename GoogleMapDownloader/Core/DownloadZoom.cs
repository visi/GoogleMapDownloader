using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core
{
    public class DownloadZoom
    {
        private long minTileX;
        private long minTileY;

        public int Zoom { get; set; }
        public long MinTileX
        {
            get { return minTileX; }
            set
            {
                minTileX = CurTileX = value;
            }
        }
        public long MaxTileX { get; set; }
        public long MinTileY
        {
            get { return minTileY; }
            set
            {
                minTileY = CurTileY = value;
            }
        }
        public long MaxTileY { get; set; }

        /// <summary>
        /// 总的瓦片数量
        /// </summary>
        public long TileCount
        {
            get
            {
                return ((MaxTileX - MinTileX) + 1) * ((MaxTileY - MinTileY) + 1);
            }
        }

        public long CurTileX { get; set; }
        public long CurTileY { get; set; }
        /// <summary>
        /// 已下载的瓦片数量
        /// </summary>
        public long DownloadedTileCount
        {
            get
            {
                return ((CurTileX - minTileX) + 1) * ((CurTileY - minTileY) + 1);
            }
        }
        public bool DownloadCompleted { get; set; }

        public MapServerDownloader Downloader { get; set; }
        public DownloadZoom Prev { get; set; }
        public DownloadZoom Next { get; set; }
    }
}
