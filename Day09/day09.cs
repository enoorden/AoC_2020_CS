using System;
using System.IO;
using System.Linq;

namespace Day09
{
    public class day09
    {
        static long[] input = File.ReadAllLines(@"..\..\..\input09.txt").Select(t => Convert.ToInt64(t)).ToArray();
        private static int back = 25;

        static void Main(string[] args)
        {
            //part1
            long n = 0;
            for (var i = back; i < input.Length; i++)
            {
                n = input[i];
                var r = input[(i - back)..i];

                if (RangeContainsSum(r, n)) continue;
                Console.WriteLine($"Part1: {n}");
                break;
            }

            //part2
            for (var i = 0; i < input.Length; i++)
            {
                var total = input[i];
                var j = 1;
                while (total < n)
                {
                    total += input[i + j];
                    if (total == n)
                    {
                        Console.WriteLine($"Part2: {input[i..(i + j + 1)].Min() + input[i..(i + j + 1)].Max()}");
                        return;
                    }
                    j++;
                }
            }
        }

        public static bool RangeContainsSum(long[] range, long sum)
        {
            return range.Any(x => range.Contains(sum - x) && sum - x != x);
        }
    }
}