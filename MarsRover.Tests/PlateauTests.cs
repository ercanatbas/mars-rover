using FluentAssertions;
using MarsRover.Coordinates;
using MarsRover.Plateaus;
using System;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        private readonly IPlateau _plateau;

        public PlateauTests()
        {
            ICoordinateValidator validator = new CoordinateValidator();
            _plateau = new Plateau(validator);
        }

        [Fact]
        public void SetSize_InvalidCoordinate_ShouldBeThrowEx()
        {
            Assert.Throws<Exception>(() => _plateau.SetCoordinate(new Coordinate(-1, -2)));
        }

        [Fact]
        public void SetSize_ValidCoordinate_ShouldBeSuccess()
        {
            _plateau.SetCoordinate(new Coordinate(1, 2));

            var result = _plateau.GetCoordinate();

            result.X.Should().Be(1);
            result.Y.Should().Be(2);
        }
    }
}
