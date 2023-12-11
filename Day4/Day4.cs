using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day4
    {

        public Day4()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day4.txt");

            int result = 0;
            int[] distribution = new int[lines.Length];

            for(int i = 0; i < distribution.Length; i++)
            {
                distribution[i] = 1;
            }

            for(int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);

                int lineScore = 0;
                int amountOfMatching = 0;
                int[] winningNumbers = new int[10];
                int[] myNumbers = new int[25];

                string[] tmp = line[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tmp.Length; j++)
                {
                    winningNumbers[j] = int.Parse(tmp[j]);
                }
                tmp = line[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tmp.Length; j++)
                {
                    myNumbers[j] = int.Parse(tmp[j]);
                }

                foreach (int j in myNumbers)
                {
                    if (winningNumbers.Contains(j))
                    {
                        amountOfMatching++;

                        if (lineScore == 0)
                            lineScore = 1;
                        else
                            lineScore *= 2;
                    }
                }

                for(int k = 0; k < amountOfMatching; k++)
                {
                    distribution[i + k + 1] += 1 * distribution[i];
                }

                result += lineScore;

            }
            
            int result2 = 0;
            for(int i = 0; i < distribution.Length; i++)
            {
                result2 += distribution[i];
            }

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();
        }
    }
}
