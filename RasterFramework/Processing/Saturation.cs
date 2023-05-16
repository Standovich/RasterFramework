using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class Saturation : IFilter
    {
        public Core.Image Apply(Core.Image sourceImage)
        {
            throw new NotImplementedException();
        }

        public string GetFilterDescription()
        {
            return "Umožňuje úpravu barev obrazu pomocí HSL modelu.";
        }
    }
}
