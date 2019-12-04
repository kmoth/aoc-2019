using System;

namespace aoc
{
    class Program
    {
        static void Main(string[] args)
        {
            // DAY 1
            // RocketFuelCalculator calculator = new RocketFuelCalculator();
            // calculator.Calculate();
            //

            // DAY 2
            IntcodeComputer computer = new IntcodeComputer();
            // computer.Run(12, 2);

            int targetResult = 19690720;
            
            int result = IntcodeRunner(computer, targetResult);
            Console.WriteLine($"Result={result}");
        }

        private static int IntcodeRunner(IntcodeComputer computer, int targetResult)
        {
            int x, y = 0;

            for (x = 0; x < 100; x++)
            {
                for (y = 0; y < 100; y++)
                {
                    int result = computer.Run(x, y);

                    if (result == targetResult)
                    {
                        return 100 * x + y;
                    }
                }
            }

            return -1;
        }
    }
}
