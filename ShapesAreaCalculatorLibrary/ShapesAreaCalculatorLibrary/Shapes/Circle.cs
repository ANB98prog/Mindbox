using ShapesAreaCalculatorLibrary.Helpers;
using ShapesAreaCalculatorLibrary.Interfaces;
using System;

namespace ShapesAreaCalculatorLibrary.Shapes
{
    /// <summary>
    /// Circle shape
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Initializes class instance of <see cref="Circle"/>
        /// </summary>
        /// <param name="radius">Circle radius</param>
        public Circle(double radius)
        {
            if (!NumberValidationHelper.IsPositive(radius))
                throw new ArgumentException("Radius must be positive number!", nameof(radius));

            Radius = radius;
        }

        /// <summary>
        /// Gets area of the circle by its radius
        /// </summary>
        /// <returns>Area of the circle</returns>
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <summary>
        /// Gets area of the circle by its radius
        /// </summary>
        /// <param name="precision">Result precision</param>
        /// <returns>Area of the circle with specified precision</returns>
        public double GetArea(int precision)
        {
            return Math.Round(GetArea(), precision);
        }
    }
}
