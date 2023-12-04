using System.Collections.Generic;
using System.Collections.Specialized;

namespace Task_2
{
    internal class Program
    {
        static string[] textFile = File.ReadAllLines("TextFile1.txt");
        static string[] textFile2 = File.ReadAllLines("TextFile2.txt");

        static void Main(string[] args)
        {
            Console.WriteLine(PartTwo());
        }

        static int PartOne(int maxRed = 12, int maxGreen = 13, int maxBlue = 14)
        {
            int num = 0;

            for (int i = 0; i < textFile.Length; i++)
            {
                int addedNum = 0;

                bool redEnough = true;
                bool greenEnough = true;
                bool blueEnough = true;

                List<int> red = new List<int>();
                List<int> blue = new List<int>();
                List<int> green = new List<int>();

                List<string> data1 = textFile[i].Split(':').ToList();
                foreach (string s in data1[0].Split(' '))
                {
                    int.TryParse(s, out addedNum);
                }
                data1.RemoveAt(0);
                string[] sub = data1[0].Split(';').ToArray();
                for (int d  = 0; d < sub.Length; d++)
                {
                        red.Add(0);
                        blue.Add(0);
                        green.Add(0);

                    foreach (string data in sub[d].Split(','))
                    {

                        if (data.Contains("green"))
                        {
                            foreach (string j in data.Split(' '))
                            {
                                bool worked = int.TryParse(j, out int g);
                                if (worked)
                                {
                                    green[d] += g;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(g);
                                }
                            }
                        }
                        if (data.Contains("red"))
                        {
                            foreach (string a in data.Split(' '))
                            {
                                bool worked = int.TryParse(a, out int r);
                                if (worked)
                                {
                                    red[d] += r;
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(r);
                                }
                            }
                        }
                        if (data.Contains("blue"))
                        {
                            foreach (string c in data.Split(' '))
                            {
                                bool worked = int.TryParse(c, out int b);
                                if (worked) 
                                {
                                    blue[d] += b;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(b);
                                }
                            }
                        }
                    }
                    if (green[d] > maxGreen) greenEnough = false;
                    if (blue[d] > maxBlue) blueEnough = false;
                    if (red[d] > maxRed) redEnough = false;
                }

                if (redEnough && blueEnough && greenEnough)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(textFile[i]);
                    num += addedNum;
                    Console.ResetColor();
                    Console.WriteLine($"{red}, {green}, {blue}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(textFile[i]);
                    Console.ResetColor();
                    Console.WriteLine($"{red}, {green}, {blue}");
                    
                }

            }
            return num;
        }

        static int PartTwo(int maxRed = 12, int maxGreen = 13, int maxBlue = 14)
        {
            int num = 0;

            for (int i = 0; i < textFile2.Length; i++)
            {

                List<int> red = new List<int>();
                List<int> blue = new List<int>();
                List<int> green = new List<int>();

                List<string> data1 = textFile2[i].Split(':').ToList();
                data1.RemoveAt(0);
                string[] sub = data1[0].Split(';').ToArray();
                for (int d = 0; d < sub.Length; d++)
                {

                    foreach (string data in sub[d].Split(','))
                    {

                        if (data.Contains("green"))
                        {
                            foreach (string j in data.Split(' '))
                            {
                                bool worked = int.TryParse(j, out int g);
                                if (worked)
                                {
                                    green.Add(g);

                                }
                            }
                        }
                        if (data.Contains("red"))
                        {
                            foreach (string a in data.Split(' '))
                            {
                                bool worked = int.TryParse(a, out int r);
                                if (worked)
                                {
                                    red.Add(r);

                                }
                            }
                        }
                        if (data.Contains("blue"))
                        {
                            foreach (string c in data.Split(' '))
                            {
                                bool worked = int.TryParse(c, out int b);
                                if (worked)
                                {
                                    blue.Add(b);

                                }
                            }
                        }
                    }
                }

                //int closestRed = 0;
                //int closestGreen = 0;
                //int closestBlue = 0;
                //for (int h = 0; h < red.Count; h++)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine($"{MathF.Abs(red[h] - maxRed)} < {MathF.Abs(closestRed - maxRed)}");


                //    Console.WriteLine($"Current red: {red[h]}");
                //    Console.WriteLine($"Closest red: {closestRed}");


                //    if (closestRed == 0 || MathF.Abs(red[h] - maxRed) < MathF.Abs(closestRed - maxRed)
                //        || MathF.Abs(red[h] - maxRed) == MathF.Abs(closestRed - maxRed) && red[h] > closestRed)
                //        closestRed = red[h];
                //}

                //for (int h = 0; h < blue.Count; h++)
                //{
                //    Console.ForegroundColor = ConsoleColor.Blue;
                //    Console.WriteLine($"{MathF.Abs(blue[h] - maxBlue)} < {MathF.Abs(closestBlue - maxBlue)}");
                //    Console.WriteLine($"Current blue: {blue[h]}");
                //    Console.WriteLine($"Closest blue: {closestBlue}");

                //    if (closestBlue == 0 || MathF.Abs(blue[h] - maxBlue) < MathF.Abs(closestBlue - maxBlue)
                //        || MathF.Abs(blue[h] - maxBlue) == MathF.Abs(closestBlue - maxBlue) && blue[h] > closestBlue)
                //        closestBlue = blue[h];
                //}

                //for (int h = 0; h < green.Count; h++)
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    Console.WriteLine($"{MathF.Abs(green[h] - maxGreen)} < {MathF.Abs(closestGreen - maxGreen)}");

                //    Console.WriteLine($"Current green: {green[h]}");
                //    Console.WriteLine($"Closest green: {closestGreen}");


                //    if (closestGreen == 0 || MathF.Abs(green[h] - maxGreen) < MathF.Abs(closestGreen - maxGreen)
                //         || MathF.Abs(green[h] - maxGreen) == MathF.Abs(closestGreen - maxGreen) && green[h] > closestGreen)
                //        closestGreen = green[h];
                //    Console.ResetColor();
                //}

                int closestBlue = blue.Aggregate((x, y) => x > y ? x : y);
                int closestRed = red.Aggregate((x, y) => x > y ? x : y);
                int closestGreen = green.Aggregate((x, y) => x > y ? x : y);

                Console.WriteLine($"Blue {closestBlue}, Red {closestRed}, Green {closestGreen}");
                num += closestBlue * closestRed * closestGreen;

            }
            return num;
        }
    }
}