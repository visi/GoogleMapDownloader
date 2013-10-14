using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.WindowsForms;

namespace GoogleMapDownloader
{
    public partial class MapDownloader : Form
    {
        string logFile = "log.txt";
        bool rectStart = false;
        Core.MapServerDownloader downloader;

        Core.MapInterface mapInterface;
        List<PointLatLng> boxPoints = new List<PointLatLng>();

        public MapDownloader()
        {
            InitializeComponent();

            mapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleChinaMap;
            mapControl.MinZoom = 1;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 5;

            mapInterface = new Core.MapInterface(mapControl);
        }

        private void MapDownloader_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            pnlR.Width = 250;
            pnlMain.Width = this.Width - pnlR.Width;
        }

        /// <summary>
        /// 全局热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapDownloader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.X://退出
                    {
                        Exit();
                        break;
                    }
            }
        }

        #region 菜单事件

        /// <summary>
        /// 退出
        /// </summary>
        private void Exit()
        {
            if (MessageBox.Show("确认要退出吗？", "退出", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
        }

        private void menuItem_Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        #endregion

        #region 工具栏

        /// <summary>
        /// 绘制下载范围工具单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbar_drawDownBounds_Click(object sender, EventArgs e)
        {
            this.mapInterface.RemovePolygon("box");
            mapControl.MouseDown += Map_MouseDown;
            mapControl.MouseUp += Map_MouseUp;
        }

        #region 绘制下载范围

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rectStart)
            {
                boxPoints.Clear();
                rectStart = true;
                PointLatLng lonlat = mapControl.FromLocalToLatLng(e.X, e.Y);
                boxPoints.Add(new PointLatLng()
                {
                    Lng = lonlat.Lng,
                    Lat = lonlat.Lat
                });
                txtMinLatitude.Text = lonlat.Lat.ToString();
                txtMinLongitude.Text = lonlat.Lng.ToString();

                mapControl.MouseMove += Map_MouseMove;
            }
        }
        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng p = boxPoints[0];
            boxPoints.Clear();
            PointLatLng lnglat = mapControl.FromLocalToLatLng(e.X, e.Y);

            boxPoints.Add(new PointLatLng() { Lng = p.Lng, Lat = p.Lat });
            boxPoints.Add(new PointLatLng() { Lng = p.Lng, Lat = lnglat.Lat });
            boxPoints.Add(lnglat);
            boxPoints.Add(new PointLatLng() { Lng = lnglat.Lng, Lat = p.Lat });

            mapInterface.DrawPolygon("box", boxPoints);

            txtMaxLongitude.Text = lnglat.Lng.ToString();
            txtMaxLatitude.Text = lnglat.Lat.ToString();
        }
        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (rectStart)
            {
                rectStart = false;
                PointLatLng p = boxPoints[0];
                boxPoints.Clear();
                PointLatLng lnglat = mapControl.FromLocalToLatLng(e.X, e.Y);

                boxPoints.Add(new PointLatLng() { Lng = p.Lng, Lat = p.Lat });
                boxPoints.Add(new PointLatLng() { Lng = p.Lng, Lat = lnglat.Lat });
                boxPoints.Add(lnglat);
                boxPoints.Add(new PointLatLng() { Lng = lnglat.Lng, Lat = p.Lat });

                mapInterface.DrawPolygon("box", boxPoints);

                txtMaxLongitude.Text = lnglat.Lng.ToString();
                txtMaxLatitude.Text = lnglat.Lat.ToString();

                mapControl.MouseDown -= Map_MouseDown;
                mapControl.MouseMove -= Map_MouseMove;
            }
        }

        #endregion

        /// <summary>
        /// 弹出瓦片索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbar_tile_Click(object sender, EventArgs e)
        {
            mapControl.ShowTileGridLines = !mapControl.ShowTileGridLines;
        }

        /// <summary>
        /// 擦除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbar_eraser_Click(object sender, EventArgs e)
        {
            mapInterface.ClearOverlay();
        }

        #endregion

        /// <summary>
        /// 绘制下载范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinLongitude.Text) || string.IsNullOrEmpty(txtMinLatitude.Text)
            || string.IsNullOrEmpty(txtMaxLongitude.Text) || string.IsNullOrEmpty(txtMaxLatitude.Text))
            {
                MessageBox.Show("坐标不能为空");
                return;
            }
            double minLng = double.Parse(txtMinLongitude.Text);
            double minLat = double.Parse(txtMinLatitude.Text);
            double maxLng = double.Parse(txtMaxLongitude.Text);
            double maxLat = double.Parse(txtMaxLatitude.Text);

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng() { Lng = minLng, Lat = maxLat });
            points.Add(new PointLatLng() { Lng = maxLng, Lat = maxLat });
            points.Add(new PointLatLng() { Lng = maxLng, Lat = minLat });
            points.Add(new PointLatLng() { Lng = minLng, Lat = minLat });

            mapInterface.DrawPolygon("box", points);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveFolder.Text))
            {
                MessageBox.Show("保存路径不能为空");
                btnSaveFolder.Focus();
                return;
            }

            if (!Util.Validation.IsNumber(txtMinLongitude.Text) || !Util.Validation.IsNumber(txtMaxLongitude.Text)
                || !Util.Validation.IsNumber(txtMinLatitude.Text) || !Util.Validation.IsNumber(txtMaxLatitude.Text))
            {
                MessageBox.Show("坐标格式不正确");
                return;
            }

            PureProjection proj = mapControl.MapProvider.Projection;

            int zoom = Convert.ToInt32(mapControl.Zoom);
            GSize minOfTiles = proj.GetTileMatrixMinXY(zoom);
            GSize maxOfTiles = proj.GetTileMatrixMaxXY(zoom);

            PointLatLng position = new PointLatLng(double.Parse(txtMinLatitude.Text), double.Parse(txtMinLongitude.Text));
            PointLatLng position1 = new PointLatLng(double.Parse(txtMaxLatitude.Text), double.Parse(txtMaxLongitude.Text));

            Core.MapPoint minPoint = new Core.MapPoint() { X = position.Lng, Y = position.Lat };
            Core.MapPoint maxPoint = new Core.MapPoint() { X = position1.Lng, Y = position1.Lat };

            Core.Log.Clear(logFile);
            downloader = new Core.Provider.GoogleChinaMapDownloader(
                new Core.Extent(minPoint.X, minPoint.Y, maxPoint.X, maxPoint.Y),
                int.Parse(txtMinZoom.Text),
                int.Parse(txtMaxZoom.Text)
                )
            {
                SavePath = txtSaveFolder.Text
            };
            downloader.TileDownloadCompleted += TileDownloadCompleted;
            downloader.DownloadCompleted += DownloadCompleted;

            downloader.BeginDownload();
            statusbar_progress.Visible = true;
            statusbar_progress.Maximum = 100;
            statusbar_status.Text = "下载中......";
        }

        /// <summary>
        /// 瓦片下载完成
        /// </summary>
        /// <param name="downloader"></param>
        /// <param name="tile"></param>
        private void TileDownloadCompleted(Core.MapServerDownloader downloader, Core.Tile tile)
        {
            string logFormat = "当前线程：{0}    瓦片：{1},{2},{3}     时间：{4}";
            Core.Log.Write(logFile,
                string.Format(logFormat, System.Threading.Thread.CurrentThread.Name
             , tile.X.ToString(), tile.Y.ToString(), tile.Zoom.ToString(), DateTime.Now.ToString("MM-dd HH:mm:ss ffff")));

            statusbar_progress.Value = (int)((downloader.DownloadedTileCount / (decimal)downloader.DownloadTileCount) * 100);
            statusbar_status.Text = "下载中......" + downloader.DownloadedTileCount.ToString() + "/" + downloader.DownloadTileCount.ToString();
        }

        /// <summary>
        /// 选择保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            saveFolderDialog.ShowNewFolderButton = true;
            saveFolderDialog.ShowDialog();

            txtSaveFolder.Text = saveFolderDialog.SelectedPath;
        }

        /// <summary>
        /// 下载完成
        /// </summary>
        private void DownloadCompleted()
        {
            statusbar_progress.Visible = false;
            statusbar_progress.Value = 0;
            statusbar_status.Text = "下载完成";
            MessageBox.Show("下载已完成");
        }

        private void btnContinueDownload_Click(object sender, EventArgs e)
        {
            downloader.TileDownloadCompleted += TileDownloadCompleted;
            downloader.DownloadCompleted += DownloadCompleted;

            statusbar_progress.Visible = true;
            statusbar_progress.Maximum = 100;
            statusbar_status.Text = "下载中......";

            downloader.ContinueDownload();
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            if (downloader != null)
            {
                downloader.StopDownload();

                statusbar_progress.Visible = false;
                statusbar_progress.Value = 0;

                statusbar_status.Text = "准备就绪";
            }
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                downloader = Core.DownloadConfig.Load(fileDialog.FileName);
            }
        }
    }
}
