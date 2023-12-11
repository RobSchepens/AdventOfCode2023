using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day11
    {
        List<int> horizontalExpansion, verticalExpansion;
        public Day11()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day11.txt");
            horizontalExpansion = new List<int>();
            verticalExpansion = new List<int>();
            List<Galaxy> galaxy = new List<Galaxy>();

            int galaxyCount = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                bool expansion = true;
                for(int j = 0; j < line.Length; j++)
                {
                    if(line[j] == '#')
                    {
                        galaxy.Add(new Galaxy(j, i, galaxyCount));
                        galaxyCount++;
                        expansion = false;
                    }
                }
                if(expansion)
                    verticalExpansion.Add(i);
            }

            for(int i = 0; i < lines[0].Length; i++)
            {
                bool expansion = true;
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '#')
                        expansion = false;
                }
                if (expansion)
                    horizontalExpansion.Add(i);
            }


            for (int i = 0; i < galaxyCount; i++)
                galaxy[i] = Expand(galaxy[i]);


            long result = 0;

            for(int i = 0; i < galaxyCount; i++)
            {
                for(int j = i; j < galaxyCount; j++)
                {
                    if(i != j)
                    {
                        int total = Math.Abs(galaxy[i].x - galaxy[j].x) + Math.Abs(galaxy[i].y - galaxy[j].y);
                        result += total;
                    }
                }
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public Galaxy Expand(Galaxy galaxy)
        {
            int xIncrease = 0;
            int yIncrease = 0;

            for(int i = 0; i < horizontalExpansion.Count; i++)
                if (horizontalExpansion[i] < galaxy.x)
                    xIncrease += 999999;

            for (int i = 0; i < verticalExpansion.Count; i++)
                if (verticalExpansion[i] < galaxy.y)
                    yIncrease += 999999;

            galaxy.x += xIncrease;
            galaxy.y += yIncrease;
            return galaxy;
        }

        public struct Galaxy
        {
            public int x, y;
            public int name;
            public Galaxy(int x, int y, int name)
            {
                this.x = x;
                this.y = y;
                this.name = name;
            }
        }
    }
}
