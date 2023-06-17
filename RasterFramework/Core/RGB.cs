using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class RGB
    {
        public static double ToGray(Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            return (r * 0.299) + (g * 0.587) + (b * 0.114);
        }
    }
}
