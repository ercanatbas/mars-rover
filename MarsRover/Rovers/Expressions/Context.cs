namespace MarsRover.Rovers.Expressions
{
    public class Context
    {
        public string Instruction { get; set; }
        public IRover Rover { get; set; }

        public Context(string instruction, IRover rover)
        {
            Instruction = instruction;
            Rover = rover;
        }
    }
}
