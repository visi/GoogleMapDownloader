using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace GoogleMapDownloader.Core
{
    public class DownloadConfig
    {
        private static object lockInstance = new object();

        private static string configFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "config.xml";
        private static XDocument configDoc = null;

        static DownloadConfig()
        {
            try
            {
                configDoc = XDocument.Load(configFilePath);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        /// <summary>
        /// 根据地图类型返回下载器
        /// </summary>
        /// <param name="mapType"></param>
        /// <returns></returns>
        private static MapServerDownloader InitByType(string mapType)
        {
            switch (mapType)
            {
                case "googleChinaMap":
                    {
                        return new GoogleMapDownloader.Core.Provider.GoogleChinaMapDownloader();
                    }
            }
            return null;
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static MapServerDownloader Load(string path)
        {
            XDocument doc = XDocument.Load(path);
            if (doc == null) return null;

            MapServerDownloader downloader = InitByType(doc.Root.Element("mapType").Value);
            XElement ele = doc.Root.Element("extent");
            double minLon = double.Parse(ele.Attribute("minLongitude").Value);
            double maxLon = double.Parse(ele.Attribute("maxLongitude").Value);
            double minLat = double.Parse(ele.Attribute("minLatitude").Value);
            double maxLat = double.Parse(ele.Attribute("maxLatitude").Value);
            downloader.DownloadExtent = new Extent(minLon, minLat, maxLon, maxLat);

            ele = doc.Root.Element("zoom");
            downloader.MinDownloadZoom = int.Parse(ele.Attribute("from").Value);
            downloader.MaxDownloadZoom = int.Parse(ele.Attribute("to").Value);
            downloader.SavePath = doc.Root.Element("savePath").Value;
            downloader.DownloadedTileCount = ulong.Parse(doc.Root.Element("downloadedTileCount").Value);

            DownloadZoom downloadZoom;
            foreach (XElement item in doc.Root.Element("items").Elements("item"))
            {
                downloadZoom = ReadDownloadZoom(item);
                downloadZoom.Downloader = downloader;

                downloader.DownloadZoomQueue.Add(downloadZoom);
            }

            downloader.DownloadTileCount = (ulong)downloader.DownloadZoomQueue.Sum(d => d.TileCount);
            downloader.CurDownloadZoom = downloader.DownloadZoomQueue.Where(d => d.Zoom == int.Parse(doc.Root.Element("curDownloadZoom").Value)).First();
            WriteConfig(downloader);

            return downloader;
        }

        /// <summary>
        /// 清除
        /// </summary>
        public static void Clear()
        {
            List<XElement> eles = configDoc.Root.Elements().ToList();
            for (int i = 0; i < eles.Count(); i++)
            {
                eles[i].Remove();
            }
            Save();
        }

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="downloader"></param>
        public static void WriteConfig(MapServerDownloader downloader)
        {
            Clear();
            configDoc.Root.Add(new XElement("mapType", downloader.MapType));
            configDoc.Root.Add(new XElement("extent",
                new XAttribute("minLongitude", downloader.DownloadExtent.MinLongitude.ToString()),
                new XAttribute("maxLongitude", downloader.DownloadExtent.MaxLongitude.ToString()),
                new XAttribute("minLatitude", downloader.DownloadExtent.MinLatitude.ToString()),
                new XAttribute("maxLatitude", downloader.DownloadExtent.MaxLongitude.ToString())
            ));
            configDoc.Root.Add(new XElement("zoom",
                new XAttribute("from", downloader.MinDownloadZoom.ToString()),
                 new XAttribute("to", downloader.MaxDownloadZoom.ToString())
            ));
            configDoc.Root.Add(new XElement("savePath", downloader.SavePath));
            configDoc.Root.Add(new XElement("downloadTileCount", downloader.DownloadTileCount.ToString()));
            configDoc.Root.Add(new XElement("downloadedTileCount", downloader.DownloadedTileCount.ToString()));
            configDoc.Root.Add(new XElement("curDownloadZoom", downloader.CurDownloadZoom != null ? downloader.CurDownloadZoom.Zoom.ToString() : downloader.MinDownloadZoom.ToString()));

            XElement downloadItems = new XElement("items");
            foreach (DownloadZoom item in downloader.DownloadZoomQueue)
            {
                downloadItems.Add(DownloadZoomItemConfig(item));
            }

            configDoc.Root.Add(downloadItems);

            Save();
        }

        /// <summary>
        /// 将下载写到日志文件里
        /// </summary>
        /// <param name="downloadItem"></param>
        private static XElement DownloadZoomItemConfig(DownloadZoom downloadItem)
        {
            return new XElement("item",
                new XAttribute("zoom", downloadItem.Zoom.ToString())
                , new XElement("minTileX", downloadItem.MinTileX.ToString())
                , new XElement("maxTileX", downloadItem.MaxTileX.ToString())
                , new XElement("minTileY", downloadItem.MinTileY.ToString())
                , new XElement("maxTileY", downloadItem.MaxTileY.ToString())
                , new XElement("tileCount", downloadItem.TileCount.ToString())
                , new XElement("curTileX", downloadItem.CurTileX.ToString())
                , new XElement("curTileY", downloadItem.CurTileY.ToString())
                , new XElement("downloadedTileCount", downloadItem.DownloadedTileCount.ToString()));
        }

        /// <summary>
        /// 更新下载记录状态
        /// </summary>
        /// <param name="downloadItem"></param>
        public static void UpdateDownloading(DownloadZoom downloadItem)
        {
            lock (lockInstance)
            {
                MapServerDownloader downloader = downloadItem.Downloader;
                XElement eleUpdate;

                eleUpdate = configDoc.Root.Element("downloadedTileCount");
                eleUpdate.Value = downloader.DownloadedTileCount.ToString();

                eleUpdate = configDoc.Root.Element("curDownloadZoom");
                eleUpdate.Value = downloadItem.Zoom.ToString();

                XElement ele = configDoc.Root.Element("items").Elements()
                        .Where(e => e.Attribute("zoom").Value.Trim() == downloadItem.Zoom.ToString())
                        .FirstOrDefault();

                if (ele == null)
                {
                    return;
                }

                eleUpdate = ele.Element("curTileX");
                eleUpdate.Value = downloadItem.CurTileX.ToString();

                eleUpdate = ele.Element("curTileY");
                eleUpdate.Value = downloadItem.CurTileY.ToString();

                eleUpdate = ele.Element("downloadedTileCount");
                eleUpdate.Value = downloadItem.DownloadedTileCount.ToString();

                Save();
            }
        }

        /// <summary>
        /// 读取一个下载层
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        public static DownloadZoom ReadDownloadZoom(XElement ele)
        {
            if (ele == null) return null;

            DownloadZoom downloadZoom = new DownloadZoom();
            downloadZoom.Zoom = int.Parse(ele.Attribute("zoom").Value);
            downloadZoom.MinTileX = long.Parse(ele.Element("minTileX").Value);
            downloadZoom.MaxTileX = long.Parse(ele.Element("maxTileX").Value);
            downloadZoom.MinTileY = long.Parse(ele.Element("minTileY").Value);
            downloadZoom.MaxTileY = long.Parse(ele.Element("maxTileY").Value);

            downloadZoom.CurTileX = long.Parse(ele.Element("curTileX").Value);
            downloadZoom.CurTileY = long.Parse(ele.Element("curTileY").Value);

            return downloadZoom;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private static void Save()
        {
            configDoc.Save(configFilePath);
            configDoc = XDocument.Load(configFilePath);
        }
    }
}
