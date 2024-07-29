using RasterFramework.Interfaces;

namespace RasterFramework.Lessons.Processing
{
    internal class Blur : IConvolution
    {
        public Core.Image Apply(Core.Image sourceImage, double[,] kernel)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Rozmazání";
        }
    }
}
