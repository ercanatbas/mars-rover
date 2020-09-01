using FluentAssertions;
using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using MarsRover.Rovers.Expressions;
using System;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        private readonly IRover _rover;

        public RoverTests()
        {
            ICoordinateValidator validator = new CoordinateValidator();
            IPlateau plateau = new Plateau(validator);
            _rover = new Rover(plateau, validator);
            plateau.SetCoordinate(new Coordinate(5, 5));
        }

        [Theory]
        [InlineData(DirectionType.S)]
        [InlineData(DirectionType.W)]
        public void SetDirection_ChangeDirection_ShouldBeSuccess(DirectionType directionType)
        {
            _rover.SetDirection(directionType);

            _rover.GetCurrentDirection().Should().NotBeNull();
            _rover.GetCurrentDirection().Should().Be(directionType);
        }

        [Fact]
        public void SetLocation_PassUnvalidCoordinate_ShouldBeThrowEx()
        {
            Assert.Throws<Exception>(() => _rover.SetCoordinate(new Coordinate(6, 6)));
        }

        [Fact]
        public void SetLocation_PassValidCoordinate_ShouldBeChanged()
        {
            var coordinate = new Coordinate(3, 1);
            _rover.SetCoordinate(coordinate);
            var result = _rover.GetCoordinate();
            result.Should().Equals(coordinate);
        }

        [Theory]
        [InlineData(DirectionType.S)]
        [InlineData(DirectionType.W)]
        [InlineData(DirectionType.E)]
        [InlineData(DirectionType.N)]
        public void MoveTo_PassValidLocation_ShouldBeSuccess(DirectionType directionType)
        {
            var coordinate = new Coordinate(3, 1);

            _rover.SetCoordinate(coordinate);
            _rover.SetDirection(directionType);

            _rover.MoveForward(directionType);

            var result = _rover.GetCurrentPosition();

            result.Should().NotBeNullOrEmpty(); 
            result.Should().Be($"{_rover.GetCoordinate().X } {_rover.GetCoordinate().Y} {directionType}");
        }

        [Fact]
        public void MoveTo_PassInValidLocation_ShouldBeThrowEx()
        {
            var coordinate = new Coordinate(0, 1);
            var directionType = DirectionType.W;

            _rover.SetCoordinate(coordinate);
            _rover.SetDirection(directionType);

            Assert.Throws<Exception>(() => _rover.MoveForward(directionType));
        }

        [Fact]
        public void RoverRunner_RunWithValidInstruction_ShouldBeSuccess()
        {
            var instruction = "LMMRMMM";
            var direction = DirectionType.N;
            var coordinate = new Coordinate(2, 1);
            _rover.SetCoordinate(coordinate);
            _rover.SetDirection(direction);

            var context = new Context(instruction, _rover);
            RoverRunner.RunExpression(context);

            var result = _rover.GetCurrentPosition();
            
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("0 4 N");
        }

        [Fact]
        public void RoverRunner_RunWithInValidInstruction_ShouldBeThrowEx()
        {
            var instruction = "BLMMRMMM";
            var direction = DirectionType.N;
            var coordinate = new Coordinate(4, 1);
            _rover.SetCoordinate(coordinate);
            _rover.SetDirection(direction);

            var context = new Context(instruction, _rover);
            Assert.Throws<Exception>(() => RoverRunner.RunExpression(context));
        }

        [Fact]
        public void SetCoordinate_RoversXCoordinateIsOutsideFromPlateau_ShouldBeThrowEx()
        {
            Assert.Throws<Exception>(() => _rover.SetCoordinate(new Coordinate(7, 1)));
        }

        [Fact]
        public void SetCoordinate_RoversYCoordinateIsOutsideFromPlateau_ShouldBeThrowEx()
        {
            Assert.Throws<Exception>(() => _rover.SetCoordinate(new Coordinate(2, 6)));
        }

        [Fact]
        public void SetCoordinate_RoversLocationIsInsideFromPlateau_ShouldBeSuccess()
        {
            _rover.SetCoordinate(new Coordinate(1, 2));

            var result = _rover.GetCoordinate();

            result.X.Should().Be(1);
            result.Y.Should().Be(2);
        }
    }
   
}
