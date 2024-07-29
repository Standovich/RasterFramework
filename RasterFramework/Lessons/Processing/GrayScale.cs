using RasterFramework.Interfaces;

namespace RasterFramework.Lessons.Processing
{
    internal class GrayScale : IFilter
    {
        public Core.Image Apply(Core.Image sourceImage)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Šedá škála";
        }
    }
}
