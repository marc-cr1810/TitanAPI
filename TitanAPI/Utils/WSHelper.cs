using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TitanAPI.Utils
{
    internal class WSHelper
    {
        public enum CompressionMethod
        {
            None,
            LZMA,
            LZMARATS
        }

        public static object UnWrap(string base64Text)
        {
            HttpContext current = HttpContext.Current;
            Stopwatch stopwatch = null;
            if (current != null && current.Items.Contains("Metrics-Request-Id") && current.Items["Metrics-Request-Id"] != null)
            {
                stopwatch = Stopwatch.StartNew();
            }

            return null;
        }
    }
}
