using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day2
    {

        public Day2()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day2.txt");

            int result = 0;
            int result2 = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                string[] reds = lines[i].Split("red");
                string[] blues = lines[i].Split("blue");
                string[] greens = lines[i].Split("green");

                int red = 0;
                int blue = 0;
                int green = 0;

                for(int j = 0; j < reds.Length - 1; j++)
                {
                    string[] section = reds[j].Split(' ');
                    int tmp = int.Parse(section[section.Length - 2]);
                    if (red < tmp)
                        red = tmp;
                }
                for(int j = 0; j < blues.Length - 1; j++)
                {
                    string[] section = blues[j].Split(' ');
                    int tmp = int.Parse(section[section.Length - 2]);
                    if (blue < tmp)
                        blue = tmp;
                }
                for(int j = 0; j < greens.Length - 1; j++)
                {
                    string[] section = greens[j].Split(' ');
                    int tmp = int.Parse(section[section.Length - 2]);
                    if (green < tmp)
                        green = tmp;
                }


                if (red <= 12 && blue <= 14 && green <= 13)
                    result += i + 1;

                result2 += red * blue * green;
            }

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();
        }

    }
}
