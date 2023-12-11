using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day3
    {

        public Day3()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day3.txt");

            int[,] ints = new int[lines.Length,lines[0].Length];
            bool[,] symbols = new bool[lines.Length, lines[0].Length];
            int result = 0;
            int result2 = 0;
            string[][] numbers = new string[lines.Length][];

            List<string> characters = new List<string>();

            for(int i = 0; i < lines.Length; i++)
                for(int j = 0; j < lines[i].Length; j++)
                    characters.Add(lines[i][j].ToString());

            characters.RemoveAll(x => "0123456789".Contains(x));
            string[] charactersArray = characters.Distinct().ToArray();


            for (int i = 0; i < lines.Length; i++)
                numbers[i] = lines[i].Split(charactersArray, StringSplitOptions.RemoveEmptyEntries);
            
            for(int i = 0; i < lines.Length; i++)
            {
                int intAmount = 0;
                bool currentlyNumber = false;
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if("0123456789".Contains(lines[i][j]))
                    {
                        ints[i,j] = int.Parse(numbers[i][intAmount]);
                        symbols[i,j] = false;
                        currentlyNumber = true;
                    }
                    else 
                    {
                        ints[i, j] = 0;

                        if (lines[i][j] == '.')
                            symbols[i, j] = false;
                        else
                            symbols[i, j] = true;

                        if(currentlyNumber == true)
                        {
                            intAmount++;
                            currentlyNumber = false;
                        }
                    }
                }
            }

            for(int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    List<int> tmp = new List<int>();
                    if (symbols[i, j])
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                try
                                {
                                    if (ints[i + k, j + l] != 0)
                                        tmp.Add(ints[i + k, j + l]);
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    tmp = tmp.Distinct().ToList();

                    for (int k = 0; k < tmp.Count; k++)
                    {
                        result += tmp[k];
                    }

                    if (tmp.Count == 2 && lines[i][j] == '*')
                    {
                        result2 += tmp[0] * tmp[1];
                    }
                }
            }

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();
        }

    }
}
