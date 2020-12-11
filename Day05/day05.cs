using System;
using System.Collections.Generic;
using System.IO;

namespace Day05
{
    class day05
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input05.txt");

        static void Main(string[] args)
        {
            //part 1
            List<int> seatsTaken = new List<int>(); //part2
            int max = 0;
            foreach (var s in input)
            {
                var row = s.Substring(0, 7);
                var column = s.Substring(7, 3);
                var seatId = GetRow(row) * 8 + GetColumn(column);
                if (seatId > max) max = seatId;
                seatsTaken.Add(seatId); //part2
            }

            Console.WriteLine($"Part1: {max}");

            //part 2
            for (int r = 1; r <= 126; r++)
            {
                for (int c = 0; c <= 7; c++)
                {
                    var trySeat = r * 8 + c;
                    if (!seatsTaken.Contains(trySeat) &&
                        seatsTaken.Contains(trySeat + 1) &&
                        seatsTaken.Contains(trySeat - 1))
                    {
                        Console.WriteLine($"Part2: {trySeat}");
                    }
                }
            }
        }

        static int GetRow(string rowEnc)
        {
            int l = 0;
            int u = 127;

            foreach (char c in rowEnc)
            {
                if (c == 'F') u = u - ((u - l) / 2 + 1);
                if (c == 'B') l = l + ((u - l) / 2 + 1);
            }
            return u;
        }
        static int GetColumn(string columnnEnc)
        {
            int l = 0;
            int u = 7;
            foreach (char c in columnnEnc)
            {
                if (c == 'L') u = u - ((u - l) / 2 + 1);
                if (c == 'R') l = l + ((u - l) / 2 + 1);
            }
            return u;
        }

    }
}
