using ClassLibrary1.Figures;
using ClassLibrary1.Interfaces;

namespace FigureLibraryTests
{
    [TestClass]
    public class CircleTests
    {
        private const double _calcAccurancy = 1e-8;
        private ICircle _circle;

        [TestMethod]
        public void Compare_Squares_Test()
        {
            //Average
            var radius = 10;
            _circle = new Circle(radius);
            var squareValue = Math.PI * Math.Pow(radius, 2);

            //Act
            var square = _circle.GetSquare();

            //Assert
            var assertResult = Math.Abs(square - squareValue);
            Assert.IsTrue(assertResult < _calcAccurancy);
        }

        [TestMethod]
        public void Init_Zero_Radius_Test()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() => _circle = new Circle(0));
        }

        [TestMethod]
        public void Init_Less_Min_Radius()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() => _circle = new Circle(Circle.MinRadius - _calcAccurancy));
        }
    }
}
