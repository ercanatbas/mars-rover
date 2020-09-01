namespace MarsRover.Rovers.Expressions
{
    public class MoveExpression : CommandExpression
    {
        public override void Interpret(Context command)
        {
            var currentDirection = command.Rover.GetCurrentDirection();
            command.Rover.MoveForward(currentDirection);
        }
    }
}
