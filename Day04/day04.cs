using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    class day04
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input04.txt");
        static List<Dictionary<string,string>> passports = new List<Dictionary<string, string>> ();
        static void Main(string[] args)
        {
            //parse input
            var p = new Dictionary<string, string>();
            foreach (var s in input)
            {
                if (s == "")
                {
                    passports.Add(p);
                    p = new Dictionary<string, string>();
                }
                else
                {
                    foreach (var attrib in s.Split())
                    {
                        p[attrib.Split(':')[0]] = attrib.Split(':')[1];
                    }
                }
            }
            passports.Add(p); //add last entry
            
            //part1
            var valid1 = passports.FindAll(x => x.Count > 7 || (!x.ContainsKey("cid") && x.Count == 7));
            Console.WriteLine($"Part1: {valid1.Count}");

            //part2
            var valid2 = valid1.FindAll(x =>
                (int.Parse(x["byr"]) >= 1920 && int.Parse(x["byr"]) <= 2002) &&
                (int.Parse(x["iyr"]) >= 2010 && int.Parse(x["iyr"]) <= 2020) &&
                (int.Parse(x["eyr"]) >= 2020 && int.Parse(x["eyr"]) <= 2030) && 
                (Regex.IsMatch(x["hgt"], "^(1[5-8][0-9]|19[0-3])cm$") || Regex.IsMatch(x["hgt"], "^(59|6[0-9]|7[0-6])in$")) &&
                (Regex.IsMatch(x["hcl"], "^#[0-9a-f]{6}$")) &&
                (new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(x["ecl"])) &&
                (Regex.IsMatch(x["pid"], "^[0-9]{9}$"))
            );
            Console.WriteLine($"Part2: {valid2.Count}");
        }
    }
}
