namespace MarsRover.Rovers.Expressions
{
    public abstract class CommandExpression
    {
        public abstract void Interpret(Context command);
    }
}
