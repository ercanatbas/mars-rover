using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using MarsRover.Rovers.Expressions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main()
        {
            string[] input = { "1", "2", "N", "LMLMLMLMM", "3", "3", "E", "MMRMMRMRRM" };

            var serviceProvider = CreateContainerBuilder();
            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.SetCoordinate(new Coordinate(5, 5));

            for (var i = 0; i < input.Length - 1; i += 4)
            {
                var rover = serviceProvider.GetService<IRover>();
                var initCoordinate = new Coordinate(Convert.ToInt32(input[i]), Convert.ToInt32(input[i + 1]));
                Enum.TryParse(input[i + 2], out DirectionType initDirection);
                rover.SetCoordinate(initCoordinate);
                rover.SetDirection(initDirection);

                // Interpreter Pattern
                var instruction = input[i + 3];
                var context = new Context(instruction, rover);
                RoverRunner.RunExpression(context);
            }

            Console.ReadKey();
        }

        private static ServiceProvider CreateContainerBuilder()
        {
            return new ServiceCollection()
                .AddSingleton<ICoordinateValidator, CoordinateValidator>()
                .AddScoped<IPlateau, Plateau>()
                .AddScoped<IRover, Rover>()
                .BuildServiceProvider();
        }

    }
}
