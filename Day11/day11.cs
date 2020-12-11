using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    public class day11
    {
        //private static string[] fp = File.ReadAllLines(@"..\..\..\input11.txt");
        public static string[] fp = File.ReadAllLines(@"..\..\..\test.txt");
        
        static void Main(string[] args)
        {
            var equal = false;
            while (!equal)
            {
                var newfp = ProcessRules(fp);
                if (!newfp.SequenceEqual(fp))
                {
                    foreach (var s in newfp)
                    {
                        Console.WriteLine(s);
                    }

                    Console.WriteLine("--");
                    Array.Copy(newfp, fp, newfp.Length);
                }
                else
                {
                    equal = true;
                    var occ = 0;
                    foreach (var s in newfp)
                    {
                        occ += s.Count(x => x == '#');
                    }

                    Console.WriteLine(occ);
                }
            }
        }


        public static string[] ProcessRules(string[] floorplan)
        {
            var newPlan = new List<string>();
            for (int x = 0; x < floorplan.Length; x++)
            {
                var newAisle = new List<char> ();
                for (int y = 0; y < floorplan[x].Length; y++)
                {
                    switch (floorplan[x][y])
                    {
                        case '.':
                            newAisle.Add('.');
                            continue;
                        case '#':
                            newAisle.Add(TooCrowded(floorplan, x, y) ? 'L' : '#');
                            break;
                        case 'L':
                            newAisle.Add(AllEmpty(floorplan, x, y) ? '#' : 'L');
                            break;
                    }
                }
                newPlan.Add(string.Join("", newAisle));
            }

            return newPlan.ToArray();
        }

        public static bool AllEmpty(string[] f, int x, int y)
        {
            if ((TrySeat(f, x - 1, y - 1) != '#') && (TrySeat(f, x - 1, y) != '#') &&
                (TrySeat(f, x - 1, y + 1) != '#') && (TrySeat(f, x, y - 1) != '#') &&
                (TrySeat(f, x, y + 1) != '#') && (TrySeat(f, x + 1, y - 1) != '#') &&
                (TrySeat(f, x + 1, y) != '#') && (TrySeat(f, x + 1, y + 1) != '#')) return true;
            return false;
        }
        public static bool TooCrowded(string[] f, int x, int y)
        {
            int occ = 0;
            if (TrySeat(f, x - 1, y - 1) == '#') occ++;
            if (TrySeat(f, x - 1,     y) == '#') occ++;
            if (TrySeat(f, x - 1, y + 1) == '#') occ++;
            if (TrySeat(f, x    , y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(f, x    , y + 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(f, x + 1, y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(f, x + 1,     y) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(f, x + 1, y + 1) == '#') occ++;
            return occ > 3;
        }

        public static char TrySeat(string[] floorplan, int x, int y)
        {
            try
            {
                return floorplan[x][y];
            }
            catch
            {
                return '.';
            }
        }
    }
}
