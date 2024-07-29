using RasterFramework.Interfaces;
using System.Reflection;

namespace RasterFramework.Core
{
    internal class AlgorithmCall
    {
        private IDrawLine line;
        private IDrawCurve curve;
        private IDrawFill fill;
        private IFilter filter;
        private IConvolution convolution;

        public Color[,] DrawLine(Image image, Type type, Point p0, Point p1)
        {
            Color[,] rawDataCopy = image.GetRawDataCopy();
            try
            {
                Assembly assem = typeof(IDrawLine).Assembly;
                line = (IDrawLine)assem.CreateInstance(type.FullName.ToString());

                line.Apply(image, p0, p1);
                return image.RawData;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return rawDataCopy;
            }
        }

        public Color[,] DrawCurve(Image image, Type type, Point[] points)
        {
            Color[,] rawDataCopy = image.GetRawDataCopy();
            try
            {
                Assembly assem = typeof(IDrawCurve).Assembly;
                curve = (IDrawCurve)assem.CreateInstance(type.FullName.ToString());

                curve.Apply(image, points);
                return image.RawData;
            }
            catch(Exception ex)
            {
                HandleException(ex);
                return rawDataCopy;
            }
        }

        public Color[,] DrawFill(CheckBox fillCheckBox, Image image, Type type)
        {
            Color[,] rawDataCopy = image.GetRawDataCopy();
            try
            {
                Assembly assem = typeof(IDrawFill).Assembly;
                fill = (IDrawFill)assem.CreateInstance(type.FullName.ToString());

                fill.Apply(image);
                return image.RawData;
            }
            catch(Exception ex)
            {
                HandleException(ex);
                fillCheckBox.CheckState = CheckState.Unchecked;
                return rawDataCopy;
            }
        }

        public Color[,] ApplyFilter(Image image, Type type)
        {
            Color[,] rawDataCopy = image.GetRawDataCopy();
            try
            {
                Assembly assem = typeof(IFilter).Assembly;
                filter = (IFilter)assem.CreateInstance(type.FullName.ToString());

                return filter.Apply(image).RawData;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return rawDataCopy;
            }
        }

        public Color[,] ApplyConvolution(Image image, Type type, double[,] kernel)
        {
            Color[,] rawDataCopy = image.GetRawDataCopy();
            try
            {
                Assembly assem = typeof(IFilter).Assembly;
                convolution = (IConvolution)assem.CreateInstance(type.FullName.ToString());

                return convolution.Apply(image, kernel).RawData;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return rawDataCopy;
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex.GetType() == typeof(IndexOutOfRangeException))
            {
                MessageBox.Show("Algoritmus se pravděpodobně snaží v některé části pracovat mimo rozsah pole.\n Celý detail chyby:\n"
                    + ex.StackTrace, "Nastala chyba!");
            }
            else if (ex.GetType() == typeof(NotImplementedException))
            {
                MessageBox.Show("Vybraný algoritmus ještě není implementován.\n Celý detail chyby:\n"
                    + ex.StackTrace, "Nastala chyba!");
            }
            else if (ex.GetType() == typeof(NullReferenceException))
            {
                MessageBox.Show("Algoritmus se snaží pracovat s objektem, který neexistuje.\n Celý detail chyby:\n"
                    + ex.StackTrace, "Nastala chyba!");
            }
            else
            {
                MessageBox.Show("Celý detail chyby: \n"
                    + ex.StackTrace, "Nastala chyba!");
            }
        }
    }
}
