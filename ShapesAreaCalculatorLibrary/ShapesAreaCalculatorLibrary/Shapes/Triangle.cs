using ShapesAreaCalculatorLibrary.Helpers;
using ShapesAreaCalculatorLibrary.Interfaces;
using System;

namespace ShapesAreaCalculatorLibrary.Shapes
{
    /// <summary>
    /// Triangle shape
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Triangle side 'a'
        /// </summary>
        public double A { get; private set; }

        /// <summary>
        /// Triangle side 'b'
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Triangle side 'c'
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// Initializes class instance of <see cref="Triangle"/>
        /// </summary>
        /// <param name="a">Triangle side 'a'</param>
        /// <param name="b">Triangle side 'b'</param>
        /// <param name="c">Triangle side 'c'</param>
        public Triangle(double a, double b, double c)
        {
            validateRectangleSides(a, b, c);

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Validates input paramenters
        /// </summary>
        /// <param name="a">Triangle side 'a'</param>
        /// <param name="b">Triangle side 'b'</param>
        /// <param name="c">Triangle side 'c'</param>
        /// <exception cref="ArgumentException"></exception>
        private void validateRectangleSides(double a, double b, double c)
        {
            if (!NumberValidationHelper.IsPositive(a))
                throw new ArgumentException("All triangle sides must be positive!", nameof(a));
            if (!NumberValidationHelper.IsPositive(b))
                throw new ArgumentException("All triangle sides must be positive!", nameof(b));
            if (!NumberValidationHelper.IsPositive(c))
                throw new ArgumentException("All triangle sides must be positive!", nameof(c));

            if (a > (b + c) || b > (a + c) || c > (a + b))
                throw new ArgumentException("Invalid triangles sides, the sum of any two sides must be greater than the third.");
        }

        /// <summary>
        /// Whether triangle is right-angled
        /// </summary>
        /// <returns>true if it is else if not</returns>
        public bool IsRightAngled()
        {
            return Math.Pow(C, 2) == Math.Pow(A, 2) + Math.Pow(B, 2);
        }

        /// <summary>
        /// Gets area of triangle by its three sides
        /// </summary>
        /// <returns>Area of the triangle</returns>
        public double GetArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        /// <summary>
        /// Gets area of triangle by its three sides
        /// </summary>
        /// <param name="precision">Result precision</param>
        /// <returns>Area of the triangle with specified precision</returns>
        public double GetArea(int precision)
        {
            return Math.Round(GetArea(), precision);
        }
    }
}
