using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

namespace GoogleMapDownloader.Core
{
    public abstract class MapServerDownloader
    {
        public event DownloadEvent.TileDownloadCompletedHandler TileDownloadCompleted;//瓦片下载完成事件
        public event DownloadEvent.DownloadCompletedHandler DownloadCompleted;//下载完成

        private ulong downloadTileCount = 0;
        private ulong downloadedTileCount = 0;
        private object lockObject = new object();

        protected string urlFormat = "";
        protected string savePath = "";
        protected Extent downloadExtent = null;
        protected int minDownloadZoom = 0;
        protected int maxDownloadZoom = 0;
        protected List<Thread> threadPool = null;//线程池
        protected List<DownloadZoom> downloadQueue = new List<DownloadZoom>();//下载队列

        public MapServerDownloader()
        {
            downloadTileCount = 0;
            downloadedTileCount = 0;

            threadPool = new List<Thread>(4);
            for (int i = 0; i < 4; i++)
            {
                threadPool.Add(new Thread(new ThreadStart(Download)) { Name = "thread" + i.ToString() });
            }
        }

        public MapServerDownloader(Extent downloadExtent, int minDownloadZoom, int maxDownloadZoom)
            : this()
        {
            this.downloadExtent = downloadExtent;
            this.minDownloadZoom = minDownloadZoom;
            this.maxDownloadZoom = maxDownloadZoom;
        }

        #region  属性

        //瓦片地址格式
        public string UrlFormat
        {
            get { return urlFormat; }
        }

        //保存路径
        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        //下载范围
        public Extent DownloadExtent
        {
            get { return downloadExtent; }
            set { downloadExtent = value; }
        }

        //下载最小缩放层级
        public int MinDownloadZoom
        {
            get { return minDownloadZoom; }
            set { minDownloadZoom = value; }
        }

        //下载最大缩放层级
        public int MaxDownloadZoom
        {
            get { return maxDownloadZoom; }
            set { maxDownloadZoom = value; }
        }

        /// <summary>
        /// 在下载的瓦片总数量
        /// </summary>
        public ulong DownloadTileCount
        {
            get { return downloadTileCount; }
            set { downloadTileCount = value; }
        }

        /// <summary>
        /// 已经下载的瓦片数量
        /// </summary>
        public ulong DownloadedTileCount
        {
            get { return downloadedTileCount; }
            set { downloadedTileCount = value; }
        }

        /// <summary>
        /// 下载图层队列
        /// </summary>
        public List<DownloadZoom> DownloadZoomQueue
        {
            get { return downloadQueue; }
        }

        public DownloadZoom CurDownloadZoom
        {
            get;
            set;
        }

        #endregion

        public abstract string MapType { get; }

        /// <summary>
        /// 下载单张瓦片
        /// </summary>
        /// <param name="tile"></param>
        public abstract void GetTilePath(Tile tile);//下载tile

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
            downloadQueue.Clear();

            Tile minTile;
            Tile maxTile;
            DownloadZoom item;

            for (int i = minDownloadZoom; i <= maxDownloadZoom; i++)
            {
                minTile = Utility.GetTile(i, downloadExtent.MinLongitude, downloadExtent.MaxLatitude);
                maxTile = Utility.GetTile(i, downloadExtent.MaxLongitude, downloadExtent.MinLatitude);

                item = new DownloadZoom()
                {
                    Zoom = i,
                    MinTileX = minTile.X,
                    MaxTileX = maxTile.X,
                    MinTileY = minTile.Y,
                    MaxTileY = maxTile.Y
                };

                if (downloadQueue.Count > 0)
                {
                    item.Prev = downloadQueue[downloadQueue.Count - 1];
                    downloadQueue[downloadQueue.Count - 1].Next = item;
                }
                item.Downloader = this;

                downloadQueue.Add(item);
            }

            downloadTileCount = (ulong)downloadQueue.Sum(d => d.TileCount);
        }

        /// <summary>
        /// 创建层级文件夹
        /// </summary>
        /// <param name="zoom"></param>
        private void CreateZoomDirectory(int zoom)
        {
            if (!Directory.Exists(savePath + "/" + zoom.ToString().PadLeft(2, '0')))
            {
                Directory.CreateDirectory(savePath + "/" + zoom.ToString().PadLeft(2, '0'));
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        protected virtual void Download()
        {
            if (CurDownloadZoom == null)
            {
                Thread.CurrentThread.Abort();
                return;
            }
            CreateZoomDirectory(CurDownloadZoom.Zoom);

            #region 锁定下载

            Tile tile;

            lock (lockObject)
            {
                if (CurDownloadZoom == null)
                {
                    Thread.CurrentThread.Abort();
                    return;
                }

                tile = new Tile(CurDownloadZoom.CurTileX, CurDownloadZoom.CurTileY, CurDownloadZoom.Zoom);
                tile.DownloadZoom = CurDownloadZoom;

                GetTilePath(tile);

                if ((CurDownloadZoom.CurTileY + 1) > CurDownloadZoom.MaxTileY)
                {
                    if ((CurDownloadZoom.CurTileX + 1) > CurDownloadZoom.MaxTileX)
                    {
                        CurDownloadZoom = CurDownloadZoom.Next;
                    }
                    else
                    {
                        ++CurDownloadZoom.CurTileX;
                        CurDownloadZoom.CurTileY = CurDownloadZoom.MinTileY;
                    }
                }
                else
                {
                    ++tile.DownloadZoom.CurTileY;
                }
            }

            SaveTile(tile);

            Download();

            #endregion
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        public void BeginDownload()
        {
            Init();
            Core.DownloadConfig.WriteConfig(this);

            downloadedTileCount = 0;
            CurDownloadZoom = downloadQueue[0];

            foreach (Thread item in threadPool)
            {
                item.Start();
            }
        }

        /// <summary>
        /// 继续下载
        /// </summary>
        public void ContinueDownload()
        {
            foreach (Thread item in threadPool)
            {
                item.Start();
            }
        }

        /// <summary>
        /// 停止下载
        /// </summary>
        public void StopDownload()
        {
            foreach (Thread item in threadPool)
            {
                item.Abort();
            }
        }

        /// <summary>
        /// 保存Tile
        /// </summary>
        /// <param name="tile"></param>
        public virtual void SaveTile(Tile tile)
        {
            string row_1 = (tile.X / 1000000).ToString().PadLeft(3, '0');
            string row_2 = ((tile.X % 1000000) / 1000).ToString().PadLeft(3, '0');
            string row_3 = (tile.X % 1000).ToString().PadLeft(3, '0');

            string col_1 = (tile.Y / 1000000).ToString().PadLeft(3, '0');
            string col_2 = ((tile.Y % 1000000) / 1000).ToString().PadLeft(3, '0');
            string col_3 = (tile.Y % 1000).ToString().PadLeft(3, '0');

            string dir = savePath + "/" + tile.Zoom.ToString().PadLeft(2, '0') + "/" + row_1 + "/" + row_2 + "/" + row_3
                + "/" + col_1 + "/" + col_2;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string fileName = dir + "/" + col_3 + ".png";

            //DownloadFile(tile.UrlPath, fileName);
            DownloadFileWithHttpRequest(tile.UrlPath, fileName);
            #region 下载完成触发事件

            if (TileDownloadCompleted != null)
            {
                TileDownloadCompleted(this, tile);
                ++downloadedTileCount;

                Core.DownloadConfig.UpdateDownloading(tile.DownloadZoom);
            }

            if (downloadedTileCount == downloadTileCount)
            {
                if (DownloadCompleted != null)
                {
                    DownloadCompleted();//下载完成
                }
                StopDownload();//停止下载
            }

            #endregion
        }

        #region 将文件下载到指定路径

        /// <summary>
        /// 下载指定url到文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        public void DownloadFile(string url, string fileName)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.Headers.Set("User-Agent", "Microsoft Internet Explorer");//设置访问标头
                wc.DownloadFile(url, fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wc.Dispose();
            }
        }

        /// <summary>
        /// 下载指定url到文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        public void DownloadFileWithHttpRequest(string url, string fileName)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.UserAgent = "Microsoft Internet Explorer";

                HttpWebResponse rep;
                rep = (HttpWebResponse)req.GetResponse();
                Stream stream = rep.GetResponseStream();

                byte[] buffer = new byte[255];
                FileStream fs = File.Open(fileName, FileMode.OpenOrCreate);
                int readCount = stream.Read(buffer, 0, buffer.Length);
                while (readCount > 0)
                {
                    fs.Write(buffer, 0, readCount);
                    readCount = stream.Read(buffer, 0, buffer.Length);
                }
                fs.Close();

                stream.Close();
                rep.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
