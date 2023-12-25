using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Task_23
{
    struct vector2
    {
        public int x, y;
        
        public vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static int Distance(vector2 vector, vector2 vector2)
        {
            return Math.Abs(vector.x - vector2.x) + Math.Abs(vector.y - vector2.y);
        }

        public int Distance( vector2 vector2)
        {
            return Math.Abs(x - vector2.x) + Math.Abs(y - vector2.y);
        }

        public void Add(vector2 vector)
        {
            x += vector.x;
            y += vector.y;
        }
    }

    internal class Program
    {
        static string[] textFile = File.ReadAllLines("TextFile1.txt");


        static void Main(string[] args)
        {
            char[][] map = textFile.Select(item => item.ToCharArray()).ToArray();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine(PartTwo(map));
            }
        }

        static int PartOne(char[][] map) 
        {
            int steps = 0;
            vector2 end = new vector2(142, 141);
            vector2 pos = new vector2(0 , 1);
            vector2 previousPos = pos;

            while (true)
            {
                vector2 direction = new vector2(0, 0);
                bool up = false;
                bool down = false;
                bool left = false;
                bool right = false;

                
                if (map[pos.y][pos.x] == 'E') return steps;

                if (map[pos.y][pos.x + 1] is '.' or '>' or 'E' &&
                   previousPos.x != pos.x + 1) { right = true; }

                if (pos.x - 1 >= 0 && previousPos.x != pos.x - 1)
                {

                    if (map[pos.y][pos.x - 1] is '.' or '<' or 'E') { left = true; }
                }

                if (map[pos.y + 1][pos.x] is '.' or 'v' or 'E' &&
                   previousPos.y != pos.y + 1) {  down = true; }

                if (map[pos.y - 1][pos.x] is '.' or '^' or 'E' &&
                   previousPos.y != pos.y - 1) {  up = true; }

                if (left && up && vector2.Distance(new vector2(pos.x, pos.y - 1), end) < vector2.Distance(new vector2(pos.x - 1, pos.y), end))
                {
                    direction = new vector2(0, -1);
                }
                else if (left)
                {
                    direction = new vector2(-1, 0);
                }
                else if (up)
                {
                    direction = new vector2(0, -1);
                }
                else if (down)
                {
                    direction = new vector2(0, 1);
                } 
                else if (right)
                {
                    direction = new vector2(1, 0);
                }

                previousPos = pos;
                pos.Add(direction);

               Console.Clear();
                
                int offset = 0;
                if (pos.y > 10) offset = pos.y - 9;
                for (int i = 0; i < map.Length; i++) 
                {
                    if (i < pos.y + 10 && i > pos.y - 10) 
                    Console.WriteLine(map[i]);
                }
                Console.SetCursorPosition(pos.x, pos.y - offset);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(100);
                steps++;
            }

            return steps;
        }

        static int PartTwo(char[][] map)
        {
            int steps = 0;
            vector2 end = new vector2(142, 141);
            vector2 pos = new vector2(0, 1);
            List<vector2> previousPos = new List<vector2> { pos };

            while (true)
            {
                vector2 direction = new vector2(0, 0);
                bool up = false;
                bool down = false;
                bool left = false;
                bool right = false;


                if (map[pos.y][pos.x] == 'E') return steps;

                    if (map[pos.y][pos.x + 1] is '.' or '>' or '<' or 'v' or '^' or 'E' &&
                       !previousPos.Contains(new vector2(pos.x + 1, pos.y))) { right = true; }
                    else right = false;

                    if (pos.x - 1 >= 0 && !previousPos.Contains(new vector2(pos.x - 1, pos.y)))
                    {

                        if (map[pos.y][pos.x - 1] is '.' or '>' or '<' or 'v' or '^' or 'E') { left = true; }
                    }
                    else left = false;

                    if (map[pos.y + 1][pos.x] is '.' or '>' or '<' or 'v' or '^' or 'E' &&
                       !previousPos.Contains(new vector2(pos.x, pos.y + 1))) { down = true; }
                    else down = false;

                    if (map[pos.y - 1][pos.x] is '.' or '>' or '<' or 'v' or '^' or 'E' &&
                       !previousPos.Contains(new vector2(pos.x, pos.y - 1))) { up = true; }
                    else up = false;
                
                if (left && up && vector2.Distance(new vector2(pos.x, pos.y - 1), end) < vector2.Distance(new vector2(pos.x - 1, pos.y), end))
                {
                    direction = new vector2(0, -1);
                }

                else if (up)
                {
                    direction = new vector2(0, -1);
                }
                else if (down)
                {
                    direction = new vector2(0, 1);
                }
                else if (right)
                {
                    direction = new vector2(1, 0);
                }
                else if (left)
                {
                    direction = new vector2(-1, 0);
                }

                previousPos.Add(pos);
                pos.Add(direction);

                Console.Clear();

                int offset = 0;
                if (pos.y > 10) offset = pos.y - 9;
                for (int i = 0; i < map.Length; i++)
                {
                    if (i < pos.y + 10 && i > pos.y - 10)
                        Console.WriteLine(map[i]);
                }
                Console.SetCursorPosition(pos.x, pos.y - offset);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");
                Console.ResetColor();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"X: {previousPos[previousPos.Count - 1].x} Y: {previousPos[previousPos.Count - 1].y}");
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(10);
                steps++;
            }

            return steps;
        }
    }
}