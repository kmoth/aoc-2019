using System;

namespace aoc
{
    class IntcodeComputer
    {
        private int[] inputs = new int[]{
            1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,1,9,27,31,1,31,10,35,2,13,35,39,1,39,10,43,1,43,9,47,1,47,13,51,1,51,13,55,2,55,6,59,1,59,5,63,2,10,63,67,1,67,9,71,1,71,13,75,1,6,75,79,1,10,79,83,2,9,83,87,1,87,5,91,2,91,9,95,1,6,95,99,1,99,5,103,2,103,10,107,1,107,6,111,2,9,111,115,2,9,115,119,2,13,119,123,1,123,9,127,1,5,127,131,1,131,2,135,1,135,6,0,99,2,0,14,0};

        public void Run()
        {
            Console.WriteLine($"Total: {inputs.Length}, Opcodes: {(inputs.Length / 4f)}");
            RestoreAlarmState();
            
            for (int i = 0; i < inputs.Length; i += 4)
            {
                if (ProcessOpcode(i))
                {
                    break;
                }
            }
        }

        private void RestoreAlarmState()
        {
            inputs[1] = 12;
            inputs[2] = 2;
        }

        private bool ProcessOpcode(int start)
        {
            switch(inputs[start])
            {
                case 1:
                    DoAdd(start);
                    return false;

                case 2:
                    DoMultiply(start);
                    return false;

                case 99:
                    DoComplete();
                    return true;

                default:
                    return true;
            }
        }

        private void DoAdd(int start)
        {
            // Console.WriteLine($"ADD: {start}");

            inputs[start + 3] = inputs[start + 1] + inputs[start + 2];
        }

        private void DoMultiply(int start)
        {
            // Console.WriteLine($"MUL: {start}");

            inputs[start + 3] = inputs[start + 1] * inputs[start + 2];
        }

        private void DoComplete()
        {
            Console.WriteLine($"COMPLETE: {inputs[0]}");
        }
    }
}