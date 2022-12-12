using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    public class ConvMethod
    {
        public string Name { get; }
        public int[,] Kernel { get; }
        public bool Divide { get; }

        public ConvMethod(string name, int[,] kernel, bool divide)
        {
            Name = name;
            Kernel = kernel;
            Divide = divide;
        }
    }
}
