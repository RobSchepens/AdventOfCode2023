using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day1
    {
        bool firstNumber = true;
        int result = 0;
        int latestNumber = 0;
        string currentString = "";

        public Day1()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day1.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                currentString = "";
                for(int j = 0; j < line.Length; j++)
                {
                    if ("0123456789".Contains(line[j]))
                    {
                        AddResult(line[j].ToString(), false);
                    }
                    else
                    {
                        string tmp = line[j].ToString();
                        currentString = currentString + tmp;
                    }

                    if (currentString.Contains("one"))
                        AddResult("1");
                    else if (currentString.Contains("two"))
                        AddResult("2");
                    else if (currentString.Contains("three"))
                        AddResult("3");
                    else if (currentString.Contains("four"))
                        AddResult("4");
                    else if (currentString.Contains("five"))
                        AddResult("5");
                    else if (currentString.Contains("six"))
                        AddResult("6");
                    else if (currentString.Contains("seven"))
                        AddResult("7");
                    else if (currentString.Contains("eight"))
                        AddResult("8");
                    else if (currentString.Contains("nine"))
                        AddResult("9");
                    else if (currentString.Contains("zero"))
                        AddResult("0");

                }
                result += latestNumber;
                firstNumber = true;
            }

            Console.WriteLine(result);
            Console.ReadKey();

        }

        void AddResult(string x, bool written = true)
        {
            if (written)
                currentString = currentString[currentString.Length - 1].ToString();
            else
                currentString = "";

            latestNumber = int.Parse(x);

            if (firstNumber)
            {
                result += 10 * latestNumber;
                firstNumber = false;
            }
        }
    }
}
