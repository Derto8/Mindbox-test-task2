using ClassLibrary1.Helpers;
using ClassLibrary1.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Figures
{
    public class Triangle : ITriangle
    {
        private readonly double _calcAccuracy;

        public readonly Lazy<bool> _isRightTriangle;

        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        public bool IsRightTriangle => _isRightTriangle.Value;

        public Triangle(double sideA, double sideB, double sideC)
        {
            var config = ConfigurationHelper.GetConfiguration();

            //как говорится, никогда не доверяй данным извне (бд, файлы конфигурации, апи и тдтп), а лучше проверяй их!
            var parseCalcAccurancy = double.TryParse(config["CalcAccurancy"], out double calcAccurancy);
            if (!parseCalcAccurancy)
                throw new InvalidCastException("Can not parse CalcAccurancy from configuration");

            _calcAccuracy = calcAccurancy;

            if (sideA < _calcAccuracy) throw new ArgumentException($"The side - {nameof(sideA)} - {sideA} is too small!");

            if (sideB < _calcAccuracy) throw new ArgumentException($"The side - {nameof(sideB)} - {sideB} is too small!");

            if (sideC < _calcAccuracy) throw new ArgumentException($"The side - {nameof(sideC)} - {sideC} is too small!");

            var perimeter = sideA + sideB + sideC;
            var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
            if (perimeter - maxSide - maxSide < _calcAccuracy)
                throw new ArgumentException("The largest side of the triangle must be less than the other sides, the figure you entered is not a triangle");

            SideA = sideA; SideB = sideB; SideC = sideC;

            _isRightTriangle = new Lazy<bool>(IsRightTriangleFunc);
        }

        public double GetSquare()
        {
            var halfPerimeter = (SideA + SideB + SideC) / 2d;
            var square = Math.Sqrt(
                halfPerimeter 
                * (halfPerimeter - SideA) 
                * (halfPerimeter - SideB) 
                * (halfPerimeter - SideC));

            return square;
        }

        private bool IsRightTriangleFunc()
        {
            double maxSize = SideA, b = SideB, c = SideC;
            if (b - maxSize > _calcAccuracy)
                SwapElementsHelper.SwapElements(ref maxSize, ref b);

            if (c - maxSize > _calcAccuracy)
                SwapElementsHelper.SwapElements(ref maxSize, ref c);

            return Math.Abs(Math.Pow(maxSize, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < _calcAccuracy;
        }
    }
}
