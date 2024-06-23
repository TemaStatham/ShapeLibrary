using NUnit.Framework.Internal;
using ShapeLibrary.Interfaces;
using ShapeLibrary.Shapes;

namespace ShapeLibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCircleWithPositiveRadius()
        {
            Circle circle = new Circle(1);
            double expectedArea = Math.PI;
            double actualArea = circle.CalculateArea();
            Assert.AreEqual(expectedArea, actualArea, 1e-6);

            circle = new Circle(10);
            expectedArea = Math.PI * Math.Pow(10, 2);
            actualArea = circle.CalculateArea();
            Assert.AreEqual(expectedArea, actualArea, 1e-6);
        }

        [TestMethod]
        public void CreateCircleWithZeroOrNonPositiveRadius()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(-1));
            Assert.ThrowsException<ArgumentException>(() => new Circle(0));
        }

        [TestMethod]
        public void CreateTriangleWithPositiveSides()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            double expectedArea = 6;
            double actualArea = triangle.CalculateArea();
            Assert.AreEqual(expectedArea, actualArea, 1e-6, "The calculated area is incorrect.");
        }

        [TestMethod]
        public void CreateTriangleWithUnvalueSides()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(10, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 10, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 1, 10));

            Assert.ThrowsException<ArgumentException>(() => new Triangle(-1, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, -1, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 1, -1));

            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 1, 0));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 0, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(0, 1, 1));
        }

        [TestMethod]
        public void IsRightTriangle()
        {
            Triangle rightTriangle = new Triangle(3, 4, 5);
            Triangle notRightTriangle1 = new Triangle(10, 10, 10);
            Triangle notRightTriangle2 = new Triangle(5, 12, 13);

            bool isRight1 = rightTriangle.IsRight();
            bool isRight2 = notRightTriangle1.IsRight();
            bool isRight3 = notRightTriangle2.IsRight();

            Assert.IsTrue(isRight1, "The triangle 3-4-5 should be a right triangle.");
            Assert.IsFalse(isRight2, "The triangle 10-10-10 should not be a right triangle.");
            Assert.IsTrue(isRight3, "The triangle 5-12-13 should be a right triangle.");
        }

        [TestMethod]
        public void CalculateShapeAreaRunTime()
        {
            IShape circle = new Circle(10);
            IShape triangle = new Triangle(3, 4, 5);

            double circleArea = circle.CalculateArea();
            double triangleArea = triangle.CalculateArea();

            double expectedCircleArea = Math.PI * Math.Pow(10, 2);
            double expectedTriangleArea = 6;

            Assert.AreEqual(expectedCircleArea, circleArea, 1e-6, "The calculated area of the circle is incorrect.");
            Assert.AreEqual(expectedTriangleArea, triangleArea, 1e-6, "The calculated area of the triangle is incorrect.");

        }
    }
}