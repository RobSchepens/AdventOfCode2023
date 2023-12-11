using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day9
    {

        public Day9()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day9.txt");

            int total = 0;
            int total2 = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                int[] history = new int[line.Length];

                for(int j = 0; j < history.Length; j++)
                    history[j] = int.Parse(line[j]);

                int result = history[history.Length - 1] + Extrapolate(history);

                int result2 = history[0] - Extrapolate2(history);

                total += result;
                total2 += result2;
            }

            Console.WriteLine(total);
            Console.WriteLine(total2);
            Console.ReadKey();
        }

        int Extrapolate(int[] input)
        {
            int[] sequence = new int[input.Length - 1];

            for(int i = 0; i < sequence.Length; i++)
                sequence[i] = input[i + 1] - input[i];

            if(areSame(sequence))
                return sequence[0];

            return sequence[sequence.Length - 1] + Extrapolate(sequence);
        }

        int Extrapolate2(int[] input)
        {
            int[] sequence = new int[input.Length - 1];

            for (int i = 0; i < sequence.Length; i++)
                sequence[i] = input[i + 1] - input[i];

            if (areSame(sequence))
                return sequence[0];

            return sequence[0] - Extrapolate2(sequence);
        }

        public static bool areSame(int[] arr)
        {

            // Put all array elements in a HashSet 
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
                s.Add(arr[i]);

            // If all elements are same, size of 
            // HashSet should be 1. As HashSet 
            // contains only distinct values. 
            return (s.Count == 1);
        }
    }
}
