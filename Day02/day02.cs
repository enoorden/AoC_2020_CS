using System;
using System.IO;

namespace Day02
{
    class day02
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input02.txt");

        static void Main(string[] args)
        {
            var t1 = 0;
            var t2 = 0;

            foreach (var s in input)
            {
                var strSplit = s.Split();
                var min = int.Parse(strSplit[0].Split('-')[0]);
                var max = int.Parse(strSplit[0].Split('-')[1]);
                var c = char.Parse(strSplit[1].Split(':')[0]);
                var pwd = strSplit[2];

                //part1
                var o = pwd.Split(c).Length - 1;
                if (o >= min && o <= max)
                {
                    t1++;
                }

                //part2
                if (pwd[min - 1] == c ^ pwd[max - 1] == c)
                {
                    t2++;
                }
            }
            Console.WriteLine($"Part1: {t1}");
            Console.WriteLine($"Part2: {t2}");
        }
    }
}
