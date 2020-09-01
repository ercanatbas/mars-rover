using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Plateaus;
using System;

namespace MarsRover.Rovers
{
    public class Rover : IRover
    {
        #region .ctor
        public DirectionType CurrentDirection { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        private readonly ICoordinateValidator _validator;
        private readonly IPlateau _plateau;

        public Rover(IPlateau plateau, ICoordinateValidator coordinateValidator)
        {
            this._plateau = plateau;
            this._validator = coordinateValidator;
        }
        #endregion

        #region direction
        public void SetDirection(DirectionType direction) => CurrentDirection = direction;

        public DirectionType GetCurrentDirection() => CurrentDirection;
        #endregion

        #region coordinate
        public void SetCoordinate(Coordinate coordinate)
        {
            _validator.Validate(coordinate, _plateau);
            X = coordinate.X;
            Y = coordinate.Y;
        }

        public Coordinate GetCoordinate()
        {
            return new Coordinate(X, Y);
        }
        #endregion

        public void MoveForward(DirectionType currentDirection)
        {
            if (currentDirection.Equals(DirectionType.N))
                Y++;
            else if (currentDirection.Equals(DirectionType.E))
                X++;
            else if (currentDirection.Equals(DirectionType.W))
                X--;
            else if (currentDirection.Equals(DirectionType.S))
                Y--;

            _validator.Validate(new Coordinate(X, Y), _plateau);
        }

        public string GetCurrentPosition() => $"{X} {Y} {Enum.GetName(typeof(DirectionType), CurrentDirection)}";
    }
}
