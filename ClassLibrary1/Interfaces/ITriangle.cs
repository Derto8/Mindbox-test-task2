using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface ITriangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public bool IsRightTriangle { get; }
    }
}
