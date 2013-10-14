using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using GMap.NET;
using GMap.NET.WindowsForms;

namespace GoogleMapDownloader.Core
{
    public class MapInterface
    {
        private GMapControl map;
        GMapOverlay overlay = new GMapOverlay();

        public MapInterface(GMapControl map)
        {
            this.map = map;
            map.Overlays.Add(overlay);
        }

        /// <summary>
        /// 清除绘制的图层
        /// </summary>
        public void ClearOverlay()
        {
            overlay.Clear();
        }

        /// <summary>
        /// 移除一个多边形
        /// </summary>
        /// <param name="name"></param>
        public void RemovePolygon(string name)
        {
            foreach (GMapPolygon item in overlay.Polygons)
            {
                if (item.Name == name)
                {
                    overlay.Polygons.Remove(item);
                    break;
                }
            }
        }

        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="name"></param>
        /// <param name="points"></param>
        public void DrawPolygon(string name, List<PointLatLng> points)
        {
            this.RemovePolygon(name);

            GMapPolygon polygon = new GMapPolygon(points, name);
            polygon.Stroke = new Pen(new SolidBrush(Color.FromArgb(255, 255, 0, 0)), 2);
            polygon.Fill = new SolidBrush(Color.FromArgb(30, 100, 100, 100));
            overlay.Polygons.Add(polygon);
        }
    }
}
