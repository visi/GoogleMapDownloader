using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMapDownloader.Core
{
    public class DownloadEvent
    {
        public delegate void TileDownloadCompletedHandler(MapServerDownloader downloader, Tile tile);
        public delegate void DownloadCompletedHandler();
    }
}
