using System;
using System.IO;
using System.Numerics;

namespace Day03
{
    class day03
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input03.txt");

        static void Main(string[] args)
        {
           
            Console.WriteLine($"Part1: {TrySlope(input,3,1)}");

            long part2 = (long) TrySlope(input, 1, 1) *
                         (long) TrySlope(input, 3, 1) *
                         (long) TrySlope(input, 5, 1) *
                         (long) TrySlope(input, 7, 1) *
                         (long) TrySlope(input, 1, 2);
            Console.WriteLine($"Part1: {part2}");
        }

        private static int TrySlope(string[] input, int right, int down)
        {
            int trees = 0;
            int x = 0;
            int width = input[0].Length;

            for (int y = 0; y < input.Length; y += down)
            {
                if (input[y][x % width] == '#')
                {
                    trees++;
                }

                x += right;
            }

            return trees;
        }
    }
}