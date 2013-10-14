using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace GoogleMapDownloader.Core
{
    public class Utility
    {
        /// <summary>
        /// 经纬度所在的瓦片
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static Tile GetTile(int zoom, double lon, double lat)
        {
            Tile tile = new Tile();

            //（经度+180）÷360×262144 = 经度图片编号
            tile.X = (long)((lon + 180.0) / 360 * Math.Pow(2, zoom));

            double siny = Math.Sin(lat * Math.PI / 180);
            double y = Math.Log((1 + siny) / (1 - siny));
            tile.Y = (long)((128 * Math.Pow(2, zoom)) * (1 - y / (2 * Math.PI)) / 256);

            return tile;
        }

        /// <summary>
        /// 经纬度转墨卡托
        /// </summary>
        /// <param name="lonLat"></param>
        /// <returns></returns>
        public static MapPoint LonLat2Mercator(MapPoint lonLat)
        {
            MapPoint mercator = new MapPoint();
            double x = lonLat.X * 20037508.34 / 180;
            double y = Math.Log(Math.Tan((90 + lonLat.Y) * Math.PI / 360)) / (Math.PI / 180);
            y = y * 20037508.34 / 180;
            mercator.X = x;
            mercator.Y = y;
            return mercator;
        }

        /// <summary>
        /// 墨卡托转经纬度
        /// </summary>
        /// <param name="mercator"></param>
        /// <returns></returns>  
        public static MapPoint Mercator2LonLat(MapPoint mercator)
        {
            MapPoint lonLat = new MapPoint();
            double x = mercator.X / 20037508.34 * 180;
            double y = mercator.Y / 20037508.34 * 180;
            y = 180 / Math.PI * (2 * Math.Atan(Math.Exp(y * Math.PI / 180)) - Math.PI / 2);
            lonLat.X = x;
            lonLat.Y = y;
            return lonLat;
        }
    }
}
