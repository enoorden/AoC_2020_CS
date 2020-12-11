using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    public class day11
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\input11.txt");
        //public static string[] input = File.ReadAllLines(@"..\..\..\test.txt");
        public static bool change = true;

        static void Main(string[] args)
        {
            char[][] fp = input.Select(item => item.ToArray()).ToArray();

            
            while (change)
            {
                var newfp = ProcessRules(fp);
                {
                    foreach (var s in newfp)
                    {
                        Console.WriteLine(s);
                    }

                    Console.WriteLine("--");
                    fp = CopyArrayLinq(newfp);
                }
            }
            var occ = 0;
            foreach (var s in fp)
            {
                occ += s.Count(x => x == '#');
            }
           Console.WriteLine("hier");
            Console.WriteLine(occ);
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
            if (TrySeat(fp, x - 1,     y) == '#') occ++;
            if (TrySeat(fp, x - 1, y + 1) == '#') occ++;
            if (TrySeat(fp, x    , y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x    , y + 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1, y - 1) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1,     y) == '#') occ++;
            if (occ > 3) return true;
            if (TrySeat(fp, x + 1, y + 1) == '#') occ++;
            return occ > 3;
        }

        public static char TrySeat(char[][] fp, int x, int y)
        {
            try
            {
                return fp[x][y];
            }
            catch
            {
                return '.';
            }
        }

        static char[][] CopyArrayLinq(char[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }
    }
}
