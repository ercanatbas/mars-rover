using MarsRover.Coordinates;

namespace MarsRover.Plateaus
{
    public class Plateau : IPlateau
    {
        public int X { get; set; }
        public int Y { get; set; }

        private readonly ICoordinateValidator _validator;

        public Plateau(ICoordinateValidator validator)
        {
            _validator = validator;
        }

        public void SetCoordinate(Coordinate coordinate)
        {
            _validator.Validate(coordinate);

            X = coordinate.X;
            Y = coordinate.Y;
        }

        public Coordinate GetCoordinate()
        {
            return new Coordinate(X, Y);
        }
    }
}
