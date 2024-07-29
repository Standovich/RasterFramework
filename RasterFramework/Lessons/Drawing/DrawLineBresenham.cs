using RasterFramework.Interfaces;

namespace RasterFramework.Lessons.Drawing
{
    internal class DrawLineBresenham : IDrawLine
    {
        private IDrawLine drawLine = new DrawLineDDA();
        public void Apply(Core.Image image, Point p0, Point p1)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Bresenham";
        }
    }
}
