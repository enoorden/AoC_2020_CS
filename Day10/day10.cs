using System;
using System.IO;
using System.Linq;

namespace Day10
{
    class day10
    {
        static int[] input = File.ReadAllLines(@"..\..\..\input10.txt").Select(t => Convert.ToInt32(t)).ToArray();

        static void Main(string[] args)
        {
            Array.Sort(input);
            var sorted = input.ToList().Prepend(0).Append(input[^1] + 3).ToArray();

            //Part1
            int step1 = 0;
            int step3 = 0;
            for (int i = 0; i < sorted.Length - 1; i++)
            {
                if (sorted[i + 1] - sorted[i] == 1) step1++;
                if (sorted[i + 1] - sorted[i] == 3) step3++;
            }
            Console.WriteLine($"Part1: {step1 * step3}");

            //Part2
            long p = 1;
            for (int i = 0; i < sorted.Length - 1; i++)
            {
                var continuous = 1;
                for (int j = 1; j < sorted.Length; j++)
                {
                    if (sorted[i + j] == sorted[i] + j) continuous++;
                    else
                    {
                        i += j - 1;
                        break;
                    };
                }

                if (continuous == 3) p *= 2;
                if (continuous == 4) p *= 4;
                if (continuous == 5) p *= 7;
            }
            Console.WriteLine(p);
        }
    }
}