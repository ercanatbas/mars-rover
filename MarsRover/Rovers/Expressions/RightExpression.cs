using MarsRover.Directions;

namespace MarsRover.Rovers.Expressions
{
    public class RightExpression : CommandExpression
    {
        public override void Interpret(Context command)
        {
            var currentDirection = command.Rover.GetCurrentDirection();

            if (currentDirection.Equals(DirectionType.W))
                currentDirection = (DirectionType)(-1);

            currentDirection += 1;
            command.Rover.SetDirection(currentDirection);
        }
    }
}
