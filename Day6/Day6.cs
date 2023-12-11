using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day6
    {

        public Day6()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day6.txt");

            string[] line1 = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] line2 = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int result = 1;
            for (int i = 1; i < line1.Length; i++)
            {
                int wins = 0;
                int time = int.Parse(line1[i]);
                int distance = int.Parse(line2[i]);

                for (int j = 0; j < time; j++)
                {
                    if (j * (time - j) > distance)
                        wins++;
                }
                result *= wins;

            }
            
            long result2 = 1;

            long time2 = 44806572;
            long distance2 = 208158110501102;

            long wins2 = 0;

            for(int j = 0; j < time2; j++)
            {
                if (j * (time2 - j) > distance2)
                    wins2++;
            }

            result2 *= wins2;

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();
        }
    }
}
