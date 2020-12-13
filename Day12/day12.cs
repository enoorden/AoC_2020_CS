using System;
using System.IO;

namespace Day12
{
    class day12
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\input12.txt");
            var ferry = new Ferry();

            foreach (var s in input)
            {
                var cmd = char.Parse(s.Substring(0, 1));
                var arg = int.Parse(s.Substring(1));

                switch (cmd)
                {
                    case 'L':
                    case 'R':
                        ferry.Turn(cmd, arg);
                        break;

                    case 'N':
                    case 'S':
                    case 'E':
                    case 'W':
                    case 'F':
                        ferry.Move(cmd, arg);
                        break;
                }
            }
            Console.WriteLine($"Part1: {ferry.Manhatten}");

            var ferry2 = new Ferry();
            var wp = new WayPoint(ferry2);


            foreach (var s in input)
            {
                var cmd = char.Parse(s.Substring(0, 1));
                var arg = int.Parse(s.Substring(1));

                switch (cmd)
                {
                    case 'L':
                    case 'R':
                        wp.Rotate(cmd, arg);
                        break;

                    case 'N':
                    case 'S':
                    case 'E':
                    case 'W':
                        wp.Move(cmd, arg);
                        break;

                    case 'F':
                        ferry2.Move2wp(wp, arg);
                        break;
                }
            }
            Console.WriteLine($"Part2: {ferry2.Manhatten}");
        }
    }

    public enum Directions
    {
        East  = 0,
        South = 90,
        West  = 180,
        North = 270
    }

    class Ferry
    {
        public int[] Position { get; }
        public Directions Facing { get; set; }
        
        public int Manhatten => Math.Abs(this.Position[0]) + Math.Abs(this.Position[1]);

        public Ferry()
        {
            Position = new [] {0, 0};
            Facing = 0;
        }

        public void Move(char dir, int distance)
        {
            if (dir == 'F') dir = char.Parse(this.Facing.ToString().Substring(0,1));
            switch (dir)
            {
                case 'N':
                    Position[1] += distance;
                    break;
                case 'S':
                    Position[1] -= distance;
                    break;
                case 'E':
                    Position[0] += distance;
                    break;
                case 'W':
                    Position[0] -= distance;
                    break;
            }
        }

        public void Move2wp(WayPoint wp, int times)
        {
            Position[0] += wp.Position[0] * times;
            Position[1] += wp.Position[1] * times;
        }

        public void Turn(char side, int degrees)
        {
            Facing = side switch
            {
                'R' => (Directions) (((int) Facing + 720 + degrees) % 360),
                'L' => (Directions) (((int) Facing + 720 - degrees) % 360),
                _ => Facing
            };
        }
    }

    class WayPoint
    {
        public int[] Position { get; set; }

        public WayPoint(Ferry f)
        {
            Position = new[] {f.Position[0] + 10, f.Position[1] + 1};
        }
        public void Rotate(char side, int degrees)
        {
            var times = degrees / 90;
            for (int i = 0; i < times; i++)
            {
                switch (side)
                {
                    case 'L':
                        Position = RotateLeft(Position);
                        break;
                    case 'R':
                        Position = RotateRight(Position);
                        break;
                }
            }
        }

        private int[] RotateLeft(int[] p)
        {
            return new int[] { -p[1], p[0] };
        }

        private int[] RotateRight(int[] p)
        {
            return new int[] { p[1], -p[0] };
        }

        public void Move(char dir, int distance)
        {
            switch (dir)
            {
                case 'N':
                    Position[1] += distance;
                    break;
                case 'S':
                    Position[1] -= distance;
                    break;
                case 'E':
                    Position[0] += distance;
                    break;
                case 'W':
                    Position[0] -= distance;
                    break;
            }
        }
    }
}