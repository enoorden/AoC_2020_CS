using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day11
{
    public class day11
    {
        public static bool change = true;

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\input11.txt");

            var fp = input.Select(item => item.ToArray()).ToArray();
            while (change)
            {
                var newfp = ProcessRules(fp);
                {
                    fp = CopyArrayLinq(newfp);
                }
            }
            var occ = 0;
            foreach (var s in fp) occ += s.Count(x => x == '#');
            Console.WriteLine($"Part1: {occ}");

            //part2
            change = true;
            fp = input.Select(item => item.ToArray()).ToArray();
            while (change)
            {
                var newfp = ProcessRules2(fp);
                fp = CopyArrayLinq(newfp);
            }

            occ = 0;
            foreach (var s in fp) occ += s.Count(x => x == '#');

            Console.WriteLine($"Part2: {occ}");
        }

        public static char[][] ProcessRules(char[][] fp)
        {
            change = false;
            var newPlan = CopyArrayLinq(fp);
            for (var x = 0; x < fp.Length; x++)
            {
                for (var y = 0; y < fp[x].Length; y++)
                {
                    switch (fp[x][y])
                    {
                        case '.':
                            newPlan[x][y] = '.';
                            continue;
                        case '#':
                            if (TooCrowded(fp, x, y))
                            {
                                newPlan[x][y] = 'L';
                                change = true;
                            }
                            else
                            {
                                newPlan[x][y] = '#';
                            }
                            break;
                        case 'L':
                            if (AllEmpty(fp, x, y))
                            {
                                newPlan[x][y] = '#';
                                change = true;
                            }
                            else
                            {
                                newPlan[x][y] = 'L';
                            }
                            break;
                    }
                }
            }
            return newPlan;
        }

        public static bool AllEmpty(char[][] fp, int x, int y)
        {
            if ((TrySeat(fp, x - 1, y - 1) != '#') && (TrySeat(fp, x - 1, y) != '#') &&
                (TrySeat(fp, x - 1, y + 1) != '#') && (TrySeat(fp, x, y - 1) != '#') &&
                (TrySeat(fp, x, y + 1) != '#') && (TrySeat(fp, x + 1, y - 1) != '#') &&
                (TrySeat(fp, x + 1, y) != '#') && (TrySeat(fp, x + 1, y + 1) != '#')) return true;
            return false;
        }
        public static bool TooCrowded(char[][] fp, int x, int y)
        {
            int occ = 0;
            if (TrySeat(fp, x - 1, y - 1) == '#') occ++;
            if (TrySeat(fp, x - 1, y) == '#') occ++;
            if (TrySeat(fp, x - 1, y + 1) == '#') occ++;
            if (TrySeat(fp, x, y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x, y + 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1, y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1, y) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1, y + 1) == '#') occ++;
            return occ > 3;
        }

        public static char TrySeat(char[][] fp, int x, int y)
        {
            if (x < 0 || y < 0 || x >= fp.Length || y >= fp[x].Length) return '|';
            return fp[x][y];
        }

        static char[][] CopyArrayLinq(char[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }


        public static char[][] ProcessRules2(char[][] fp)
        {
            change = false;
            var newPlan = CopyArrayLinq(fp);
            for (var x = 0; x < fp.Length; x++)
            {
                for (var y = 0; y < fp[x].Length; y++)
                {
                    switch (fp[x][y])
                    {
                        case '.':
                            newPlan[x][y] = '.';
                            continue;
                        case '#':
                            if (TooCrowded2(fp, x, y))
                            {
                                newPlan[x][y] = 'L';
                                change = true;
                            }
                            else
                            {
                                newPlan[x][y] = '#';
                            }
                            break;
                        case 'L':
                            if (AllEmpty2(fp, x, y))
                            {
                                newPlan[x][y] = '#';
                                change = true;
                            }
                            else
                            {
                                newPlan[x][y] = 'L';
                            }
                            break;
                    }
                }
            }
            return newPlan;
        }

        public static List<int[]> getVisibleSeats(char[][] fp, int x, int y)
        {
            var vis = new List<int[]>();
            vis.Add(getVis(fp, x, y, 1, 0));
            vis.Add(getVis(fp, x, y, 1, 1));
            vis.Add(getVis(fp, x, y, 0, 1));
            vis.Add(getVis(fp, x, y, 1, -1));
            vis.Add(getVis(fp, x, y, 0, -1));
            vis.Add(getVis(fp, x, y, -1, 1));
            vis.Add(getVis(fp, x, y, -1, 0));
            vis.Add(getVis(fp, x, y, -1, -1));
            return vis;
        }

        public static int[] getVis(char[][] fp, int x, int y, int stepx, int stepy)
        {
            var seat = '.';
            var c = 1;
            while (seat == '.')
            {
                seat = TrySeat(fp, x + (stepx * c), y + (stepy * c));
                if (seat == '.') c++;
            }
            if (seat == 'L' || seat == '#') return new int[] { x + (stepx * c), y + (stepy * c) };
            return null;
        }

        public static bool AllEmpty2(char[][] fp, int x, int y)
        {
            var visibleseats = getVisibleSeats(fp, x, y);
            foreach (var seat in visibleseats.Where(x => x != null))
            {
                if (TrySeat(fp, seat[0], seat[1]) == '#') return false;
            }

            return true;
        }
        public static bool TooCrowded2(char[][] fp, int x, int y)
        {
            int occ = 0;

            var visibleseats = getVisibleSeats(fp, x, y);
            foreach (var seat in visibleseats.Where(x => x != null))

                {
                    if (TrySeat(fp, seat[0], seat[1]) == '#') occ++;
                if (occ > 4) return true;
            }
            return occ > 4;
        }
    }
}