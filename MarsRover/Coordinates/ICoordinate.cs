namespace MarsRover.Coordinates
{
    public interface ICoordinate
    {
        int X { get; }
        int Y { get; }

        /// <summary>
        /// Set Coordinates
        /// </summary>
        /// <param name="coordinate">Coordinates.</param>
        void SetCoordinate(Coordinate coordinate);


        /// <summary>
        /// Get Coordinates
        /// </summary>
        Coordinate GetCoordinate();
    }
}
