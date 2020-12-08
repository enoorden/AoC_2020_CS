using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class day07
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input07.txt");
        
        static void Main(string[] args)
        {
            var rules = GetRules(input);
            var outerBags = GetBags(rules, "shiny gold");
            Console.WriteLine($"Part1: {outerBags.Count}");

            var totalBags = GetTotalBags(rules, "shiny gold");
            Console.WriteLine($"Part2: {totalBags}");
        }
        
        static Dictionary<string, Dictionary<string, int>> GetRules(string[] input)
        {
            var rules = new Dictionary<string, Dictionary<string, int>>();

            foreach (var s in input)
            {
                var rule = new Dictionary<string, int>();
                var bagColor = string.Join(' ', s.Split()[0..2]);
                var bagContent = string.Join(' ', s.Split()[4..]).Split();
                for (int i = 0; i < bagContent.Length / 4; i++)
                {
                    rule[string.Join(' ', bagContent[(i * 4 + 1)..(i * 4 + 3)])] = int.Parse(bagContent[i * 4]);
                }
                rules[bagColor] = rule;
            }

            return rules;
        }
        
        private static List<string> GetBags(Dictionary<string, Dictionary<string, int>> rules, string bagColor, List<string> outerbags = null)
        {
            outerbags ??= new List<string>();
            var b = rules.Where(x => x.Value.ContainsKey(bagColor)).ToDictionary(x => x.Key, x => x.Value);
            foreach (var bKey in b.Keys)
            {
                if (!outerbags.Contains(bKey)) outerbags.Add(bKey);
                GetBags(rules, bKey, outerbags);
            }

            return outerbags;
        }

        private static int GetTotalBags(Dictionary<string, Dictionary<string, int>> rules, string bagColor)
        {
            int total = 0;
            var a = rules[bagColor];

            foreach (var i in a) {
                total += i.Value + (i.Value * GetTotalBags(rules, i.Key));
            }

            return total;
        }
    }
}