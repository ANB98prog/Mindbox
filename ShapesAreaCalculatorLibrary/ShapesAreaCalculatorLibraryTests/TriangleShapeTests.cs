using ShapesAreaCalculatorLibrary.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace ShapesAreaCalculatorLibraryTests
{
    public class TriangleShapeTests
    {
        [Fact]
        public void CreateTriangleFact()
        {
            double a = 12;
            double b = 5;
            double c = 13;

            Triangle triangle = new Triangle(a, b, c);

            Assert.NotNull(triangle);
            Assert.Equal(a, triangle.A);
            Assert.Equal(b, triangle.B);
            Assert.Equal(c, triangle.C);
        }

        [Theory]
        [InlineData(-1, 2, 3, "a")]
        [InlineData(1, -2, 3, "b")]
        [InlineData(1, 2, -3, "c")]
        public void CreateTriangleWithNegativeSideFact(double a, double b, double c, string invalidParam)
        {            
            var exMessage = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

            Assert.StartsWith("All triangle sides must be positive!", exMessage.Message);
            Assert.Equal(invalidParam, exMessage.ParamName);
        }

        [Theory]
        [InlineData(12, 5, 13, 30)]
        [InlineData(1, 1, 1, 0.4330127018922193)]
        [InlineData(3, 4, 5, 6)]
        public void GetTriangleAreaFact(double a, double b, double c, double expected)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(expected, triangle.GetArea());
        }

        [Theory]
        [InlineData(12, 5, 13, 1, 30)]
        [InlineData(1, 1, 1, 6, 0.433013)]
        [InlineData(3, 4, 5, 0, 6)]
        public void GetTriangleAreaWithPrecisionFact(double a, double b, double c, int precision,  double expected)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(expected, triangle.GetArea(precision));
        }

        [Theory]
        [InlineData(1, 1, 1, false)]
        [InlineData(3, 4, 5, true)]
        [InlineData(12, 5, 13, true)]
        public void IsRightAngledTriangleFact(double a, double b, double c, bool expected)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(expected, triangle.IsRightAngled());
        }
    }
}
