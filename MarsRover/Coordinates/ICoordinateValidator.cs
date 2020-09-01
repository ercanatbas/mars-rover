using MarsRover.Plateaus;

namespace MarsRover.Coordinates
{
    public interface ICoordinateValidator
    {
        /// <summary>
        /// The method check whether coordinates are correct.
        /// </summary>
        /// <param name="coordinate">Coordinates.</param>
        void Validate(Coordinate coordinate);

        /// <summary>
        /// The method check verifies rover coordinates according to plato.
        /// </summary>
        /// <param name="coordinate">Coordinates</param>
        /// <param name="plateau">Plateau</param>
        void Validate(Coordinate coordinate, IPlateau plateau);
    }
}
