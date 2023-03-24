using ShapesAreaCalculatorLibrary.Interfaces;
using System;

namespace ShapesAreaCalculatorLibrary
{
    /// <summary>
    /// Circle shape
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initializes class instance of <see cref="Circle"/>
        /// </summary>
        /// <param name="radius">Circle radius</param>
        public Circle(double radius)
        {
            if (!NumberValidationHelper.IsPositive(radius))
            {
                throw new ArgumentException("Radius must be positive number!", nameof(radius));
            }

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
    }
}
