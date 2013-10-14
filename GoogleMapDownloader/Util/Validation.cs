using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleMapDownloader.Util
{
    public class Validation
    {
        private static Regex regNumber = new Regex(@"^\d+(\.\d+)?$", RegexOptions.IgnoreCase); //数字
        private static Regex regInt = new Regex(@"^\d+$", RegexOptions.IgnoreCase);//整数
        private static Regex regFloat = new Regex(@"^\d+\.\d+$", RegexOptions.IgnoreCase);//浮点数或整数

        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNumber(string val)
        {
            return regNumber.IsMatch(val);
        }

        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsFloat(string val)
        {
            return regFloat.IsMatch(val);
        }
    }
}
