namespace Task_1
{
    internal class Program
    {
        static string[] textFile = File.ReadAllLines("TextFiles/TextFile1.txt");
        static string[] textFile2 = File.ReadAllLines("TextFiles/TextFile2.txt");
        static Dictionary<string, int> numberTable = new Dictionary<string, int>
        {
            {"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},
            {"seven",7},{"eight",8},{"nine",9}
        };

        static void Main(string[] args)
        {
            Console.WriteLine(PartTwo());
        }

        static int PartOne()
        {
            int num = 0;
            foreach (string line in textFile)
            {
                bool hasANum = false;
                int num1 = 0;
                int num2 = 0;
                string numbers = "";
                char[] c = line.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (!hasANum)
                    {
                        if (int.TryParse(c[i].ToString(), out int a))
                        {
                            num1 = a;
                            hasANum = true;
                        }
                    }

                    if (int.TryParse(c[i].ToString(), out int b))
                    {
                        num2 = b;
                    }
                }
                numbers = num1.ToString() + num2.ToString();

                num += int.Parse(numbers);
            }

            return num;
        }

        static int PartTwo()
        {
            int num = 0;
            foreach (string line in textFile2)
            {
                int pos = 0;
                int pos2 = 0;
                bool hasANum = false;
                int num1 = 999999;
                int num2 = 0;
                string numbers = "";
                char[] c = line.ToCharArray();
                foreach (string str in numberTable.Keys)
                {
                    if ((!hasANum || line.IndexOf(str) < pos) && line.Contains(str))
                    {
                        num1 = numberTable[str];
                        hasANum = true;
                        pos = line.IndexOf(str);
                    }
                    if (line.Contains(str) && line.LastIndexOf(str) > pos2)
                    {
                        num2 = numberTable[str];
                        pos2 = line.LastIndexOf(str);

                    }


                }
                for (int i = 0; i < c.Length; i++)
                {
                    if (!hasANum || i < pos)
                    {
                        if (int.TryParse(c[i].ToString(), out int a))
                        {
                            num1 = a;
                            pos = i;
                            hasANum = true;
                        }

                    }

                    if (int.TryParse(c[i].ToString(), out int b) && i >= pos2)
                    {
                        num2 = b;
                        pos2 = i;
                    }
                }
                numbers = num1.ToString() + num2.ToString();
                Console.WriteLine(numbers);
                num += int.Parse(numbers);
            }

            return num;
        }
    }
}