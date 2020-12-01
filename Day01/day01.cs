using System;
using System.IO;

namespace Day01
{
    class day01
    {
        static string[] input = File.ReadAllLines(@"..\..\..\input.txt");
        static void Main(string[] args)
        {
            // day 1
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    //Console.WriteLine($"{input[i]} + {input[j]}");
                    if (int.Parse(input[i]) + int.Parse(input[j]) == 2020)
                    {
                        Console.WriteLine("Day1:");
                        Console.WriteLine(int.Parse(input[i]) * int.Parse(input[j]));
                    }
                }
            }

            // day 2
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    for (int k = j; k < input.Length; k++)
                    {
                        if (int.Parse(input[i]) + int.Parse(input[j]) + int.Parse(input[k]) == 2020)
                        {
                            Console.WriteLine("\nDay2:");
                            Console.WriteLine(int.Parse(input[i]) * int.Parse(input[j]) * int.Parse(input[k]));
                        }
                    }
                }
            }
        }
    }
}
