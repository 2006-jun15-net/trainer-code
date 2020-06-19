using System;
using System.Collections.Generic;
using System.Text;
using ProductCatalog.Library;
using Xunit;

namespace ProductCatalog.Tests
{
    public class CircleTests
    {
        [Theory] // "Fact" means a zero-parameter test; "Theory" means a test with params that has several possible values
        [InlineData(3, 9.4248)]
        [InlineData(100, 314.15926535)]
        [InlineData(0, 0)]
        public void CircumferenceShouldBeCorrect(double diameter, double circumference)
        {
            // arrange
            var circle = new Circle(diameter);

            // act
            double actualCircumference = circle.Circumference;

            // assert
            Assert.Equal(circumference, actualCircumference, precision: 4); // within 4 decimal places
        }
    }
}
