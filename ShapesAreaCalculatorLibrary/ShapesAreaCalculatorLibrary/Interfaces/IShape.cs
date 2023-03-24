namespace ShapesAreaCalculatorLibrary.Interfaces
{
    /// <summary>
    /// Describes the shape interface
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Gets an area of a shape
        /// </summary>
        /// <returns>Area of the shape</returns>
        double GetArea();

        /// <summary>
        /// Gets an area of a shape
        /// </summary>
        /// <param name="precision">Precision</param>
        /// <returns>Area of the shape</returns>
        double GetArea(int precision);
    }
}
