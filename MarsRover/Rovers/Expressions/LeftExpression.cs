using MarsRover.Directions;

namespace MarsRover.Rovers.Expressions
{
    public class LeftExpression : CommandExpression
    {
        public override void Interpret(Context command)
        {
            var currentDirection = command.Rover.GetCurrentDirection();
            if (currentDirection.Equals(DirectionType.N))
                currentDirection = (DirectionType)(4);

            currentDirection -= 1;
            command.Rover.SetDirection(currentDirection);
        }
    }
}
