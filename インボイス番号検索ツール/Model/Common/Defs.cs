using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace インボイス番号検索ツール.Model.Common
{
    internal class Defs
    {
        public static string Version { get; set; } = "2.0.0";
        public static bool Debug { get; } = true;

        public enum Authority
        {
            Generic = 0,
            Admin = 99,
        }

        public enum Status
        {
            Active = 0,
            Inactive = 99,
        }

        public static Color DefaultThemeColor = Color.DarkSeaGreen;
    }
}
