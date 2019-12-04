using System;
using System.Collections.Generic;

namespace aoc
{
    class IntcodeComputer
    {
        private int[] liveInputs = new int[]{1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,1,9,27,31,1,31,10,35,2,13,35,39,1,39,10,43,1,43,9,47,1,47,13,51,1,51,13,55,2,55,6,59,1,59,5,63,2,10,63,67,1,67,9,71,1,71,13,75,1,6,75,79,1,10,79,83,2,9,83,87,1,87,5,91,2,91,9,95,1,6,95,99,1,99,5,103,2,103,10,107,1,107,6,111,2,9,111,115,2,9,115,119,2,13,119,123,1,123,9,127,1,5,127,131,1,131,2,135,1,135,6,0,99,2,0,14,0};

        private int[] memory;

        private Dictionary<int, Opcode> opcodes = new Dictionary<int, Opcode>();

        private delegate int Opcode(params int[] values);

        public IntcodeComputer()
        {
            InitOpcodesLookup();
        }

        public int Run(int noun, int verb)
        {
            Reset();
            SetInputs(noun, verb);
            ProcessInputs();

            return memory[0];
        }

        private void Reset()
        {
            memory = new int[liveInputs.Length];
            Array.Copy(liveInputs, memory, liveInputs.Length);
        }

        private void InitOpcodesLookup()
        {
            opcodes.Add(1, Add);
            opcodes.Add(2, Multiply);
            opcodes.Add(99, Exit);
        }

        private void ProcessInputs()
        {
            int lengthMinusOne = memory.Length - 1;

            for (int i = 0; i < memory.Length; i += 4)
            {
                int opcodeIndex = memory[i];
                int value1Index = memory[Math.Min(i + 1, lengthMinusOne)];
                int value2Index = memory[Math.Min(i + 2, lengthMinusOne)];
                int destinationIndex = memory[Math.Min(i + 3, lengthMinusOne)];

                int resultCode = opcodes[opcodeIndex].Invoke(
                    value1Index, 
                    value2Index, 
                    destinationIndex);

                if (resultCode > 0)
                {
                    break;
                }
            }
        }

        private void SetInputs(int noun, int verb)
        {
            memory[1] = noun;
            memory[2] = verb;
        }

        private int Add(params int[] values)
        {
            int value1 = values[0];
            int value2 = values[1];
            int destinationIndex = values[2];

            memory[destinationIndex] = memory[value1] + memory[value2];

            return 0;
        }

        private int Multiply(params int[] values)
        {
            int value1 = values[0];
            int value2 = values[1];
            int destinationIndex = values[2];

            memory[destinationIndex] = memory[value1] * memory[value2];

            return 0;
        }

        private int Exit(params int[] values)
        {
            return 1;
        }
    }
}
