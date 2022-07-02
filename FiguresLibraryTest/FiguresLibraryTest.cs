using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLibrary;
using System;

namespace FiguresLibraryTest
{
    [TestClass]
    public class FiguresLibraryTest
    {
        // Тест для проверки подсчета площади у круга
        [TestMethod]
        public void CalculatingCircleArea()
        {
            double r = 3.3;
            double expectedCircleArea = 34.21194399759284;

            Figure figure = new Circle(r);

            double actualCircleArea = figure.CalculateArea();

            Assert.IsTrue(Math.Abs( actualCircleArea - expectedCircleArea) < 0.0000000001);
        }

        // Тест для подсчета площади у треугольника
        [TestMethod]
        public void CalculatingTriangleArea()
        {
            double[] triangleSides = { 5, 3, 4 };
            double expectedTriangleArea = 6;

            Figure figure = new Triangle(triangleSides);

            double actualTriangleArea = figure.CalculateArea();

            Assert.AreEqual(expectedTriangleArea, actualTriangleArea);
        }

        // Тест для проверки метода, определяющего
        // прямоугольный треугольник или нет
        [TestMethod]
        public void TriangleIsRectangular()
        {
            Triangle tr = new Triangle(new double[] { 5, 4, 3 });
            Triangle tr2 = new Triangle(new double[] { 4, 8, 11 });

            Assert.IsTrue(tr.isRectangular());
            Assert.IsFalse(tr2.isRectangular());
        }
    }
}
