using RasterFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Lessons.Drawing
{
    internal class ScanLine : IDrawFill
    {
        public void Apply(Core.Image image)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Scan-Line";
        }
    }
}
