using MarsRover.Coordinates;
using MarsRover.Directions;

namespace MarsRover.Rovers
{
    public interface IRover : IDirection, ICoordinate
    {
        /// <summary>
        /// This method moves rover to forward.
        /// </summary>
        /// <param name="direction">Which direction will go forward.</param>
        void MoveForward(DirectionType direction);

        /// <summary>
        /// This method gets which direction the head of rover look.
        /// </summary>
        DirectionType GetCurrentDirection();

        /// <summary>
        /// This method gets rover position as string output which has specific format.
        /// </summary>
        string GetCurrentPosition();
    }
}
