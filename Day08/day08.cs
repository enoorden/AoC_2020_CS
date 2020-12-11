using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    class day08
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input08.txt");

        static void Main(string[] args)
        {
            Console.WriteLine($"Part1: {RunCommands(input)[0]}");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("acc")) continue; //nothing changes, no need to run check

                var inputCopy = new string[input.Length];
                input.CopyTo(inputCopy, 0);
                if (inputCopy[i].StartsWith("jmp")) inputCopy[i] = inputCopy[i].Replace("jmp", "nop");
                else if (inputCopy[i].StartsWith("nop")) inputCopy[i] = inputCopy[i].Replace("nop", "jmp");

                var result = RunCommands(inputCopy.ToArray());
                if (result[1] != 0) continue;
                Console.WriteLine($"Part2: {result[0]}");
                break;
            }
        }

        static int[] RunCommands(string[] cmds)
        {
            int accumulator = 0;
            int pointer = 0;
            List<int> completedCmds = new List<int>();

            while (pointer < input.Length)
            {
                if (completedCmds.Contains(pointer))
                {
                    return new int[] { accumulator, 1 };
                }

                completedCmds.Add(pointer);
                var cmd = cmds[pointer].Split()[0];
                var stp = int.Parse(cmds[pointer].Split()[1]);

                switch (cmd)
                {
                    case "nop":
                        {
                            pointer++;
                            break;
                        }

                    case "acc":
                        {
                            pointer++;
                            accumulator += stp;
                            break;
                        }

                    case "jmp":
                        {
                            pointer += stp;
                            break;
                        }
                }
            }

            return pointer == cmds.Length ? new int[] { accumulator, 0 } : new int[] { accumulator, 2 };
        }
    }
}