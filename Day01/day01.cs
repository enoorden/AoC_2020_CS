using System;
using System.IO;

namespace Day01
{
    class day01
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input01.txt");
        static void Main(string[] args)
        {
            // part 1
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (int.Parse(input[i]) + int.Parse(input[j]) == 2020)
                    {
                        Console.WriteLine("Part1:");
                        Console.WriteLine(int.Parse(input[i]) * int.Parse(input[j]));
                    }

                    // part 2
                    for (int k = j; k < input.Length; k++)
                    {
                        if (int.Parse(input[i]) + int.Parse(input[j]) + int.Parse(input[k]) == 2020)
                        {
                            Console.WriteLine("Part2:");
                            Console.WriteLine(int.Parse(input[i]) * int.Parse(input[j]) * int.Parse(input[k]));
                        }
                    }
                }
            }
        }
    }
}
