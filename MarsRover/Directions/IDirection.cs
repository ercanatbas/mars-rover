namespace MarsRover.Directions
{
    public interface IDirection
    {
        /// <summary>
        /// The property gives current direction of inherited from this interface.
        /// </summary>
        DirectionType CurrentDirection { get; }


        /// <summary>
        /// The method set the current direction of inherited from this interface.
        /// </summary>
        /// <param name="directionType">Which direction head of the rovers.</param>
        void SetDirection(DirectionType directionType);
    }
}
