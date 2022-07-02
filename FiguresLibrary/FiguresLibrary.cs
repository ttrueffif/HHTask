using System;

namespace FiguresLibrary
{
    public abstract class Figure
    {
        public abstract double CalculateArea();
    }

    // Треугольник
    public class Triangle : Figure
    {
        private double[] _sides = new double[3];

        public Triangle(params double[] sides)
        {
            if (sides == null || sides.Length != 3)
                throw new ArgumentException("Triangle(): invalid parametres");

            if (!isExists(sides))
                throw new Exception("such triangle doesn't exists");

            for (int i = 0; i < sides.Length; i++)
                // Так лучше double не сравнивать
                if (sides[i] >= 0.0) _sides[i] = sides[i];
                else throw new Exception("??? side length <= 0 ???");
        }

        // Проверка условия:
        //     может ли существовать треугольник с такими сторонами или нет
        private bool isExists(double[] sides)
        {
            if (sides[0] >= sides[1] + sides[2] ||
                sides[1] >= sides[0] + sides[2] ||
                sides[2] >= sides[0] + sides[1])
                return false;

            return true;
        }

        // Проверка осуществляется с помощью теоремы Пифагора
        public bool isRectangular()
        {
            // Сторону с максимальной длиной в конец массива _sides
            for (int i = 0; i < _sides.Length - 1; ++i)
            {
                if (_sides[i] > _sides[_sides.Length - 1])
                {
                    double temp = _sides[i];
                    _sides[i] = _sides[_sides.Length - 1];
                    _sides[_sides.Length - 1] = temp;
                }
            }

            // true - треугольник прямоугольный
            // false - треугольник не прямоугольный
            return _sides[2] * _sides[2] == (_sides[0] * _sides[0] + _sides[1] * _sides[1]);
        }

        // Нахождение периметра, вспомогательный метод
        // закрыт, использую только в методе CalculateArea()
        private double CalculateP()
        {
            double P = default(double);

            for (int i = 0; i < _sides.Length; ++i)
                P += _sides[i];

            return P;
        }

        public override double CalculateArea()
        {
            // Полупериметр для формулы Герона
            // Формула Герона 
            double P = CalculateP() / 2;

            return Math.Sqrt(P * (P - _sides[0]) * (P - _sides[1]) * (P - _sides[2]));
        }
    }

    // Круг
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
