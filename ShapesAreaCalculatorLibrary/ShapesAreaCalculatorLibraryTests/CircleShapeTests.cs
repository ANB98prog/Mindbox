using ShapesAreaCalculatorLibrary.Interfaces;
using ShapesAreaCalculatorLibrary.Shapes;

namespace ShapesAreaCalculatorLibraryTests
{
    public class CircleShapeTests
    {
        [Fact]
        public void CreateCircleFact()
        {
            double radius = 5;

            Circle circle = new Circle(radius);

            Assert.NotNull(circle);
            Assert.Equal(radius, circle.Radius);
        }

        [Fact]
        public void CreateCircleWithNegativeRadiusFact()
        {
            double radius = -5;

            var exMessage = Assert.Throws<ArgumentException>(() => new Circle(radius));

            Assert.StartsWith("Radius must be positive number!", exMessage.Message);
            Assert.Equal("radius", exMessage.ParamName);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 3.1415926535897931)]
        [InlineData(5, 78.539816339744831)]
        public void GetCircleAreaFact(double radius, double expected)
        {
            Circle circle  = new Circle(radius);

            Assert.Equal(expected, circle.GetArea());
        }

        [Fact]
        public void ChangeCircleRadiusFact()
        {
            double r1 = 1;
            double expected1 = 3.1415926535897931;

            double r2 = 5;
            double expected2 = 78.539816339744831;

            Circle circle = new Circle(r1);

            Assert.Equal(expected1, circle.GetArea());

            circle.Radius = r2;
            Assert.Equal(expected2, circle.GetArea());
        }

        [Fact]
        public void ChangeToNegativeRadiusFact()
        {
            Circle circle = new Circle(1);

            var errorMessage = Assert.Throws<ArgumentException>(() => circle.Radius = -1);
            Assert.StartsWith("Radius must be positive number!", errorMessage.Message);
            Assert.Equal("radius", errorMessage.ParamName);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 2, 3.14)]
        [InlineData(1, 4, 3.1416)]
        [InlineData(5, 4, 78.5398)]
        public void GetCircleAreaWithPrecisionOfTwoFact(double radius, int precision,  double expected)
        {
            Circle circle = new Circle(radius);

            Assert.Equal(expected, circle.GetArea(precision));
        }
    }
}