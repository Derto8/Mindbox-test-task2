using ClassLibrary1.Figures;
using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibraryTests
{
    [TestClass]
    public class TriangleTests
    {
        private const double _calcAccurancy = 1e-8;
        private ITriangle _triangle;

        [TestMethod]
        public void Init_Triangle_Test()
        {
            //Average
            double sideA = 2, sideB = 3, sideC = 4;

            //Act
            _triangle = new Triangle(sideA, sideB, sideC);

            //Assert
            Assert.IsNotNull(_triangle);

            var assertSideAResult = Math.Abs(_triangle.SideA - sideA);
            Assert.IsTrue(assertSideAResult < _calcAccurancy);

            var assertSideBResult = Math.Abs(_triangle.SideB - sideB);
            Assert.IsTrue(assertSideBResult < _calcAccurancy);

            var assertSideCResult = Math.Abs(_triangle.SideC - sideC);
            Assert.IsTrue(assertSideCResult < _calcAccurancy);
        }

        [DataRow(3, 4, 5)]
        [DataRow(3, 4, 5.0000000009)]
        [TestMethod]
        public void Is_RightTriangle_Tests(double sideA, double sideB, double sideC)
        {
            //Average
            _triangle = new Triangle(sideA, sideB, sideC);

            //Act
            var isRightTriangle = _triangle.IsRightTriangle;

            //Assert
            Assert.IsTrue(isRightTriangle);
        }

        [DataRow(3, 4, 3)]
        [DataRow(3 + 1e-8, 4 + 1e-8, 3 + 1e-8)]
        [TestMethod]
        public void Is_Not_RightTriangle_Tests(double sideA, double sideB, double sideC)
        {
            //Average
            _triangle = new Triangle(sideA, sideB, sideC);

            //Act
            var isRightTriangle = _triangle.IsRightTriangle;

            //Assert
            Assert.IsFalse(isRightTriangle);
        }

        [TestMethod]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        [DataRow(0, 0, 0)]
        public void Init_Triangle_Error_Tests(double sideA, double sideB, double sideC)
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle = new Triangle(sideA, sideB, sideC));
        }

        [TestMethod]
        public void Init_Not_Triangle_Test()
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle = new Triangle(2, 2, 5));
        }
    }
}
