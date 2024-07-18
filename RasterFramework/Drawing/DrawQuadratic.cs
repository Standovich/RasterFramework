using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Drawing
{
    internal class DrawQuadratic : IDrawCurve
    {
        public void Apply(Core.Image image, Point[] points)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Kvadratická";
        }
    }
}
