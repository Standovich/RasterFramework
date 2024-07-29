using RasterFramework.Interfaces;

namespace RasterFramework.Lessons.Drawing
{
    internal class DrawCubic : IDrawCurve
    {
        private IDrawLine drawLine = new DrawLineDDA();
        public void Apply(Core.Image image, Point[] points)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Kubická";
        }
    }
}
