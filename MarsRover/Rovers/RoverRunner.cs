using MarsRover.Rovers.Expressions;
using System;
using System.Collections.Generic;

namespace MarsRover.Rovers
{
    public static class RoverRunner
    {
        public static List<CommandExpression> CreateExpressionTree(string instruction)
        {
            List<CommandExpression> tree = new List<CommandExpression>();

            foreach (var direction in instruction)
            {
                switch (direction)
                {
                    case 'L':
                        tree.Add(new LeftExpression());
                        break;
                    case 'R':
                        tree.Add(new RightExpression());
                        break;
                    case 'M':
                        tree.Add(new MoveExpression());
                        break;
                    default:
                        throw new Exception("Invalid command processed. Please supply only L,R and M");
                }
            }
            return tree;
        }

        public static void RunExpression(Context context)
        {
            foreach (CommandExpression expression in CreateExpressionTree(context.Instruction))
            {
                expression.Interpret(context);
            }

            Console.WriteLine(context.Rover.GetCurrentPosition());
        }
    }
}
