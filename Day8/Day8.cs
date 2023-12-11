using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day8
    {

        public Day8()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day8.txt");

            string instructions = lines[0];
            Dictionary<string,Node> nodes = new Dictionary<string, Node>();
            List<Node> startingNodes = new List<Node>();

            for(int i = 0; i < lines.Length - 2; i++)
            {
                string[] line = lines[i + 2].Split(new char[] { ' ', '=', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                nodes.Add(line[0], new Node(line[0], line[1], line[2]));
                if (line[0][2] == 'A')
                    startingNodes.Add(new Node(line[0], line[1], line[2]));
            }
            int step = -1;
            bool done = false;

            int[] firstInstance = new int[startingNodes.Count];

            while (!done)
            {
                step++;

                for (int i = 0; i < startingNodes.Count; i++)
                {
                    if (startingNodes[i].name[2] == 'Z')
                    {
                        if (firstInstance[i] == 0)
                            firstInstance[i] = step;
                        else if (!done)
                            done = true;
                    }
                }
                char direction = instructions[step % instructions.Length];

                if (direction == 'L')
                    for (int i = 0; i < startingNodes.Count; i++)
                        startingNodes[i] = nodes[startingNodes[i].left];
                else if (direction == 'R')
                    for (int i = 0; i < startingNodes.Count; i++)
                        startingNodes[i] = nodes[startingNodes[i].right];
            }

            Console.WriteLine(lcm_of_array_elements(firstInstance));
            Console.ReadKey();
        }

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate 
                // we found all factors and terminate while loop.
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }
    }
    public struct Node
    {
        public string name;
        public string left;
        public string right;

        public Node(string name, string left, string right)
        {
            this.name = name;
            this.left = left;
            this.right = right;
        }
    }


}
