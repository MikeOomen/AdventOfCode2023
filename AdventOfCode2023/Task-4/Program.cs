using System.ComponentModel.DataAnnotations;

namespace Task_4
{
    internal class Program
    {
        static string[] textFile = File.ReadAllLines("TextFile1.txt");

        static void Main(string[] args)
        {
            Console.WriteLine(PartTwo());
        }

        static int PartOne()
        {
            int value = 0;
            foreach (string s in textFile)
            {
                int val = 0;
                List<string> list = s.Split(':').ToList();

                string s2 = list[1];
                string[] str = s2.Split('|');

                foreach (string str2 in str[1].Split(' ')) 
                {


                    bool worked1 = int.TryParse(str2, out int i);
                    if (worked1 )
                    {
                        foreach (string str3 in str[0].Split(' '))
                        {
                            bool worked2 = int.TryParse(str3, out int j);
                            if (worked2 ) 
                            { 
                                if (j == i && val > 0)
                                {
                                    val *= 2;
                                }
                                if (j == i && val == 0)
                                {
                                    val++;

                                }
                            }
                        }
                    }
                }
                Console.WriteLine($"{list[0]} = {val}");
                value += val;
            }

            return value;
        }

        static int PartTwo()
        {
            List<string> textList = textFile.ToList();
            for (int a = 0; a < textList.Count; a++)
            {
                int val = 0;
                List<string> list = textList[a].Split(':').ToList();

                string s2 = list[1];
                string[] str = s2.Split('|');

                foreach (string str2 in str[1].Split(' '))
                {


                    bool worked1 = int.TryParse(str2, out int i);
                    if (worked1)
                    {
                        foreach (string str3 in str[0].Split(' '))
                        {
                            bool worked2 = int.TryParse(str3, out int j);
                            if (worked2)
                            {
                                if (j == i)
                                {
                                    val++;
                                    string[] aString = list[0].Split(' ');
                                    aString[1].Trim(' ');
                                        bool worked = int.TryParse(aString[1], out int g);
                                        if (worked)
                                        {
                                        g--;
                                            if (val + g < textFile.Length && val + g != g)
                                            {
                                                textList.Add(textFile[val + g]);
                                                textList.Sort();
                                            }

                                        }

                                    
                                }
                            }
                        }
                    }
                }
            }

            return textList.Count;
        }
    }
}