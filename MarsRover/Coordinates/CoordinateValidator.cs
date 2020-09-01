using MarsRover.Plateaus;
using System;

namespace MarsRover.Coordinates
{
    public class CoordinateValidator : ICoordinateValidator
    {
        public virtual void Validate(Coordinate coordinate)
        {
            if (coordinate.X < 0 && coordinate.Y < 0)
                throw new Exception("Invalid plateau location.");
        }

        public void Validate(Coordinate coordinate, IPlateau plateau)
        {
            if (coordinate.X < 0 || coordinate.Y < 0)
                throw new Exception("Rover must be in plateau.");

            if (coordinate.X > plateau.X)
                throw new Exception("X Location must be lower than X location of the Plateau.");

            if (coordinate.Y > plateau.Y)
                throw new Exception("Y Location must be lower than Y location of the Plateau.");
        }
    }
}
