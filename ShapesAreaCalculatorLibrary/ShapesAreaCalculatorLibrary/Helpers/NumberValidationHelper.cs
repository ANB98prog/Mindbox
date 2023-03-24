namespace ShapesAreaCalculatorLibrary.Helpers
{
    /// <summary>
    /// Numbers validation helper
    /// </summary>
    internal static class NumberValidationHelper
    {
        /// <summary>
        /// Checks whether number is positive
        /// </summary>
        /// <param name="number">Validating number</param>
        /// <returns> true if positive else false</returns>
        internal static bool IsPositive(double number)
        {
            return number >= 0;
        }
    }
}
