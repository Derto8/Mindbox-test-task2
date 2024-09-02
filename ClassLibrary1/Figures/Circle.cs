using ClassLibrary1.Helpers;
using ClassLibrary1.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1.Figures
{
    public class Circle : ICircle
    {
        public const double MinRadius = 1e-7;

        public double Radius { get; }

        public Circle(double radius)
        {
            var config = ConfigurationHelper.GetConfiguration();

            var parseCalcAccurancy = double.TryParse(config["CalcAccurancy"], out double calcAccurancy);
            if (!parseCalcAccurancy)
                throw new InvalidCastException("Can not parse CalcAccurancy from configuration");

            if (radius - MinRadius < calcAccurancy)
                throw new ArgumentException($"The radius - {radius} of the figure is too small!");

            Radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
