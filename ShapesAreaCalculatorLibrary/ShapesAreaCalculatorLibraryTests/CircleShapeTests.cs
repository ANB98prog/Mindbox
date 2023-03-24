using ShapesAreaCalculatorLibrary;
using ShapesAreaCalculatorLibrary.Interfaces;

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
        public void CreateCircleByInterfaceFact()
        {
            double radius = 5;

            IShape circle = new Circle(radius);

            Assert.NotNull(circle);
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
        [InlineData(1, 3.14)]
        public void GetCircleAreaFact(double radius, double expected)
        {
            Circle circle  = new Circle(radius);

            Assert.Equal(expected, circle.GetArea());
        }
    }
}