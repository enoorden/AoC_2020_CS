using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;

namespace Day13
{
    class day13
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\input13.txt");
            //string[] input = File.ReadAllLines(@"..\..\..\test.txt");
            //string[] input = File.ReadAllLines(@"..\..\..\test2.txt");

            //part1
            var arrival = int.Parse(input[0]);
            var busses = input[1].Split(',').Where(x => x != "x").Select(t => Convert.ToInt32(t)).ToArray();
            
            var wait = busses.Min(y => y - (arrival % y));
            var bus = busses.First(x => x - (arrival % x) == wait);
            
            Console.WriteLine($"Part1: {bus * wait}");
            
            //part2
            var bussesOffset = new Dictionary<int,int>();
            var inputSplit = input[1].Split(',').ToArray();

            /*
             Console.WriteLine(File.ReadLines(@"..\..\..\input13.txt")
                .Last(s => !string.IsNullOrWhiteSpace(s))
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select((s, i) => new KeyValuePair<int, int>(i, (s == "x") ? 1 : int.Parse(s)))
                .Aggregate(new { T = 0L, Lcm = 1L }, (acc, b) =>
                    new
                    {
                        T = Enumerable.Range(0, Int32.MaxValue)
                            .Select(n => acc.T + (acc.Lcm * n))
                            .First((n) => (n + b.Key) % b.Value == 0),
                        Lcm = acc.Lcm * b.Value
                    }
                )
                .T);
            */
        
            //create dictionary  
            for (int i = 0; i < inputSplit.Length; i++) if (inputSplit[i] != "x") bussesOffset[i] = int.Parse(inputSplit[i]);


            var t = (ulong) bussesOffset[0];

            foreach (var i in bussesOffset)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }
            int passing;
            while (true)                             
            {
                //Console.WriteLine(start);
                passing = 0;
                foreach (int bo in bussesOffset.Keys)
                {
                    if ((t + (ulong)bo) % (ulong)bussesOffset[bo] == 0) passing++;

                }

                //Console.WriteLine(passing);
                if (passing == bussesOffset.Count)
                {
                    Console.WriteLine($"------{t}");
                    break;
                }

                if (t%1000000 == 0) Console.WriteLine(t);
                
                //start += li;
                t += (ulong) bussesOffset[0]; //(ulong) bussesOffset[0];
            }
            
        }
    }
}
