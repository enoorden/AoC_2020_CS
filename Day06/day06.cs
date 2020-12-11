using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
{
    class day06
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input06.txt");
        static List<List<string>> groups = new List<List<string>>();

        static void Main(string[] args)
        {
            List<string> group = new List<string>();
            foreach (var s in input)
            {
                if (s == "")
                {
                    groups.Add(group);
                    group = new List<string>();
                }
                else
                {
                    group.Add(s);
                }
            }
            groups.Add(group);

            //part1
            var total = 0;
            foreach (var g in groups)
            {
                total += (string.Join("", g)).Distinct().Count();
            }
            Console.WriteLine($"Part1: {total}");

            //part2
            total = 0;
            foreach (var g in groups)
            {
                foreach (var c in g[0])
                {
                    //check if occurence of all chars in first entry against joined answer
                    //if occurence is same as length of group array then everyone answered that question yes
                    if (string.Join("", g).Count(x => x == c) == g.Count) { total++; }
                }
            }
            Console.WriteLine($"Part2: {total}");
        }
    }
}
