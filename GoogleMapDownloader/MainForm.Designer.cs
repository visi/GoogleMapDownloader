namespace GoogleMapDownloader
{
    partial class MapDownloader
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapDownloader));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolbar_drawDownBounds = new System.Windows.Forms.ToolStripButton();
            this.toolbar_tile = new System.Windows.Forms.ToolStripButton();
            this.toolbar_eraser = new System.Windows.Forms.ToolStripButton();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.statusbar_progress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusbar_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlR = new System.Windows.Forms.Panel();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnContinueDownload = new System.Windows.Forms.Button();
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxZoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinZoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopDownload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDrawBox = new System.Windows.Forms.Button();
            this.txtMaxLatitude = new System.Windows.Forms.TextBox();
            this.txtMaxLongitude = new System.Windows.Forms.TextBox();
            this.txtMinLatitude = new System.Windows.Forms.TextBox();
            this.txtMinLongitude = new System.Windows.Forms.TextBox();
            this.saveFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlR.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbar_drawDownBounds,
            this.toolbar_tile,
            this.toolbar_eraser});
            this.toolbar.Location = new System.Drawing.Point(0, 25);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(984, 25);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolbar_drawDownBounds
            // 
            this.toolbar_drawDownBounds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_drawDownBounds.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_drawDownBounds.Image")));
            this.toolbar_drawDownBounds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_drawDownBounds.Name = "toolbar_drawDownBounds";
            this.toolbar_drawDownBounds.Size = new System.Drawing.Size(23, 22);
            this.toolbar_drawDownBounds.Text = "截取范围";
            this.toolbar_drawDownBounds.Click += new System.EventHandler(this.toolbar_drawDownBounds_Click);
            // 
            // toolbar_tile
            // 
            this.toolbar_tile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_tile.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_tile.Image")));
            this.toolbar_tile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_tile.Name = "toolbar_tile";
            this.toolbar_tile.Size = new System.Drawing.Size(23, 22);
            this.toolbar_tile.Text = "瓦片索引";
            this.toolbar_tile.Click += new System.EventHandler(this.toolbar_tile_Click);
            // 
            // toolbar_eraser
            // 
            this.toolbar_eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_eraser.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_eraser.Image")));
            this.toolbar_eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_eraser.Name = "toolbar_eraser";
            this.toolbar_eraser.Size = new System.Drawing.Size(23, 22);
            this.toolbar_eraser.Text = "toolStripButton1";
            this.toolbar_eraser.Click += new System.EventHandler(this.toolbar_eraser_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusbar_progress,
            this.statusbar_status});
            this.statusbar.Location = new System.Drawing.Point(0, 540);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(984, 22);
            this.statusbar.TabIndex = 2;
            this.statusbar.Text = "statusStrip1";
            // 
            // statusbar_progress
            // 
            this.statusbar_progress.Name = "statusbar_progress";
            this.statusbar_progress.Size = new System.Drawing.Size(300, 20);
            this.statusbar_progress.Visible = false;
            // 
            // statusbar_status
            // 
            this.statusbar_status.Name = "statusbar_status";
            this.statusbar_status.Size = new System.Drawing.Size(56, 17);
            this.statusbar_status.Text = "准备就绪";
            // 
            // mapControl
            // 
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 17;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(730, 486);
            this.mapControl.TabIndex = 0;
            this.mapControl.Zoom = 0D;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.mapControl);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMain.Location = new System.Drawing.Point(0, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(734, 490);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlR
            // 
            this.pnlR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlR.Controls.Add(this.btnLoadConfig);
            this.pnlR.Controls.Add(this.btnContinueDownload);
            this.pnlR.Controls.Add(this.btnSaveFolder);
            this.pnlR.Controls.Add(this.txtSaveFolder);
            this.pnlR.Controls.Add(this.label4);
            this.pnlR.Controls.Add(this.txtMaxZoom);
            this.pnlR.Controls.Add(this.label3);
            this.pnlR.Controls.Add(this.txtMinZoom);
            this.pnlR.Controls.Add(this.label1);
            this.pnlR.Controls.Add(this.btnStopDownload);
            this.pnlR.Controls.Add(this.btnDownload);
            this.pnlR.Controls.Add(this.groupBox1);
            this.pnlR.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlR.Location = new System.Drawing.Point(734, 50);
            this.pnlR.Name = "pnlR";
            this.pnlR.Padding = new System.Windows.Forms.Padding(3);
            this.pnlR.Size = new System.Drawing.Size(250, 490);
            this.pnlR.TabIndex = 4;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(10, 283);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 10;
            this.btnLoadConfig.Text = "加载配置文件";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // btnContinueDownload
            // 
            this.btnContinueDownload.Location = new System.Drawing.Point(91, 462);
            this.btnContinueDownload.Name = "btnContinueDownload";
            this.btnContinueDownload.Size = new System.Drawing.Size(75, 23);
            this.btnContinueDownload.TabIndex = 9;
            this.btnContinueDownload.Text = "继续下载";
            this.btnContinueDownload.UseVisualStyleBackColor = true;
            this.btnContinueDownload.Click += new System.EventHandler(this.btnContinueDownload_Click);
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.Location = new System.Drawing.Point(175, 224);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(68, 23);
            this.btnSaveFolder.TabIndex = 8;
            this.btnSaveFolder.Text = "选择...";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            this.btnSaveFolder.Click += new System.EventHandler(this.btnSaveFolder_Click);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Location = new System.Drawing.Point(10, 227);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.ReadOnly = true;
            this.txtSaveFolder.Size = new System.Drawing.Size(152, 21);
            this.txtSaveFolder.TabIndex = 7;
            this.txtSaveFolder.Text = "F:\\GoogleMap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "保存路径：";
            // 
            // txtMaxZoom
            // 
            this.txtMaxZoom.Location = new System.Drawing.Point(163, 174);
            this.txtMaxZoom.Name = "txtMaxZoom";
            this.txtMaxZoom.Size = new System.Drawing.Size(72, 21);
            this.txtMaxZoom.TabIndex = 5;
            this.txtMaxZoom.Text = "18";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "到";
            // 
            // txtMinZoom
            // 
            this.txtMinZoom.Location = new System.Drawing.Point(75, 174);
            this.txtMinZoom.Name = "txtMinZoom";
            this.txtMinZoom.Size = new System.Drawing.Size(68, 21);
            this.txtMinZoom.TabIndex = 5;
            this.txtMinZoom.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "下载级别：";
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Location = new System.Drawing.Point(168, 462);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(75, 23);
            this.btnStopDownload.TabIndex = 2;
            this.btnStopDownload.Text = "停止下载";
            this.btnStopDownload.UseVisualStyleBackColor = true;
            this.btnStopDownload.Click += new System.EventHandler(this.btnStopDownload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(10, 462);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDrawBox);
            this.groupBox1.Controls.Add(this.txtMaxLatitude);
            this.groupBox1.Controls.Add(this.txtMaxLongitude);
            this.groupBox1.Controls.Add(this.txtMinLatitude);
            this.groupBox1.Controls.Add(this.txtMinLongitude);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "范围";
            // 
            // btnDrawBox
            // 
            this.btnDrawBox.Location = new System.Drawing.Point(72, 109);
            this.btnDrawBox.Name = "btnDrawBox";
            this.btnDrawBox.Size = new System.Drawing.Size(95, 25);
            this.btnDrawBox.TabIndex = 4;
            this.btnDrawBox.Text = "绘制下载范围";
            this.btnDrawBox.UseVisualStyleBackColor = true;
            this.btnDrawBox.Click += new System.EventHandler(this.btnDrawBox_Click);
            // 
            // txtMaxLatitude
            // 
            this.txtMaxLatitude.Location = new System.Drawing.Point(132, 72);
            this.txtMaxLatitude.Name = "txtMaxLatitude";
            this.txtMaxLatitude.Size = new System.Drawing.Size(100, 21);
            this.txtMaxLatitude.TabIndex = 3;
            this.txtMaxLatitude.Text = "53.561771";
            // 
            // txtMaxLongitude
            // 
            this.txtMaxLongitude.Location = new System.Drawing.Point(7, 72);
            this.txtMaxLongitude.Name = "txtMaxLongitude";
            this.txtMaxLongitude.Size = new System.Drawing.Size(100, 21);
            this.txtMaxLongitude.TabIndex = 2;
            this.txtMaxLongitude.Text = "135.08693";
            // 
            // txtMinLatitude
            // 
            this.txtMinLatitude.Location = new System.Drawing.Point(132, 21);
            this.txtMinLatitude.Name = "txtMinLatitude";
            this.txtMinLatitude.Size = new System.Drawing.Size(100, 21);
            this.txtMinLatitude.TabIndex = 1;
            this.txtMinLatitude.Text = "18.159829";
            // 
            // txtMinLongitude
            // 
            this.txtMinLongitude.Location = new System.Drawing.Point(7, 21);
            this.txtMinLongitude.Name = "txtMinLongitude";
            this.txtMinLongitude.Size = new System.Drawing.Size(100, 21);
            this.txtMinLongitude.TabIndex = 0;
            this.txtMinLongitude.Text = "73.441277";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.退出XToolStripMenuItem,
            this.menuItem_Exit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem3.Text = "保存";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem2.Text = "另存为...";
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(118, 6);
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Name = "menuItem_Exit";
            this.menuItem_Exit.Size = new System.Drawing.Size(121, 22);
            this.menuItem_Exit.Text = "退出(X)";
            this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.关于ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "用户使用帮助";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // MapDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.pnlR);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MapDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图下载器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MapDownloader_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapDownloader_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlR.ResumeLayout(false);
            this.pnlR.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.StatusStrip statusbar;
        private GMap.NET.WindowsForms.GMapControl mapControl;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlR;
        private System.Windows.Forms.ToolStripStatusLabel statusbar_status;
        private System.Windows.Forms.ToolStripProgressBar statusbar_progress;
        private System.Windows.Forms.ToolStripButton toolbar_drawDownBounds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaxLatitude;
        private System.Windows.Forms.TextBox txtMaxLongitude;
        private System.Windows.Forms.TextBox txtMinLatitude;
        private System.Windows.Forms.TextBox txtMinLongitude;
        private System.Windows.Forms.Button btnDrawBox;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ToolStripButton toolbar_tile;
        private System.Windows.Forms.ToolStripButton toolbar_eraser;
        private System.Windows.Forms.Button btnStopDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxZoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinZoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.FolderBrowserDialog saveFolderDialog;
        private System.Windows.Forms.Button btnSaveFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnContinueDownload;
        private System.Windows.Forms.Button btnLoadConfig;
    }
}

