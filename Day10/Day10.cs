using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day10
    {
        static char[,] grid, bigGrid;
        static bool[,] flooded;
        static string[] lines;

        public static Stack<bigGridPosition> placesToCheck;
        public Day10()
        {
            lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day10.txt");

            grid = new char[lines[0].Length, lines.Length];
            bigGrid = new char[lines[0].Length * 3, lines.Length * 3];
            flooded = new bool[lines[0].Length * 3, lines.Length * 3];
            bool[,] visited = new bool[lines[0].Length, lines.Length];

            placesToCheck = new Stack<bigGridPosition>();

            int startX = 0;
            int startY = 0;

            int total = 0;

            for(int y = 0; y < lines.Length; y++)
            {
                for(int x = 0; x < lines[0].Length; x++)
                {
                    grid[x, y] = lines[y][x];
                    if (grid[x,y] == 'S')
                    {
                        startX = x;
                        startY = y;
                    }

                }
            }

            gridPosition currentNode = new gridPosition(startX, startY);
            visited[startX,startY] = true;
            List<gridPosition> originalNeighbours = checkSurroundings(startX, startY);
            int pathLength = 1;

            while (currentNode.x != originalNeighbours[1].x || currentNode.y != originalNeighbours[1].y || currentNode.name != originalNeighbours[1].name)
            {
                List<gridPosition> neighbours = checkSurroundings(currentNode.x, currentNode.y);
                if (visited[neighbours[0].x, neighbours[0].y] == false)
                    currentNode = neighbours[0];
                else if (visited[neighbours[1].x, neighbours[1].y] == false)
                    currentNode = neighbours[1];
                else
                    break;

                visited[currentNode.x,currentNode.y] = true;

                pathLength++;
            }

            for(int y = 0; y < lines.Length; y++)
            {
                for(int x = 0; x < lines[0].Length; x++)
                {
                    gridPosition tmp = new gridPosition(x, y);
                    if (visited[x, y])
                    {
                        Console.Write(tmp.name);
                        switch (grid[x, y])
                        {
                            case '-':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '.'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '-'; bigGrid[3 * x + 1, 3 * y + 1] = '-'; bigGrid[3 * x + 2, 3 * y + 1] = '-';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '.'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case '|':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '|'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '.'; bigGrid[3 * x + 1, 3 * y + 1] = '|'; bigGrid[3 * x + 2, 3 * y + 1] = '.';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '|'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case '7':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '.'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '-'; bigGrid[3 * x + 1, 3 * y + 1] = '7'; bigGrid[3 * x + 2, 3 * y + 1] = '.';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '|'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case 'F':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '.'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '.'; bigGrid[3 * x + 1, 3 * y + 1] = 'F'; bigGrid[3 * x + 2, 3 * y + 1] = '-';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '|'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case 'J':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '|'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '-'; bigGrid[3 * x + 1, 3 * y + 1] = 'J'; bigGrid[3 * x + 2, 3 * y + 1] = '.';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '.'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case 'L':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '|'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '.'; bigGrid[3 * x + 1, 3 * y + 1] = 'L'; bigGrid[3 * x + 2, 3 * y + 1] = '-';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '.'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            case 'S':
                                bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '|'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                                bigGrid[3 * x + 0, 3 * y + 1] = '.'; bigGrid[3 * x + 1, 3 * y + 1] = 'S'; bigGrid[3 * x + 2, 3 * y + 1] = '-';
                                bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '.'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                                break;
                            default:
                                Console.WriteLine();
                                break;
                        }

                    }
                    else
                    {
                        Console.Write('.');

                        bigGrid[3 * x + 0, 3 * y + 0] = '.'; bigGrid[3 * x + 1, 3 * y + 0] = '.'; bigGrid[3 * x + 2, 3 * y + 0] = '.';
                        bigGrid[3 * x + 0, 3 * y + 1] = '.'; bigGrid[3 * x + 1, 3 * y + 1] = '.'; bigGrid[3 * x + 2, 3 * y + 1] = '.';
                        bigGrid[3 * x + 0, 3 * y + 2] = '.'; bigGrid[3 * x + 1, 3 * y + 2] = '.'; bigGrid[3 * x + 2, 3 * y + 2] = '.';
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < lines.Length * 3; i++)
            {
                for (int j = 0; j < lines[0].Length * 3; j++)
                {
                    Console.Write(bigGrid[j,i]);
                }
                Console.WriteLine();
            }

            placesToCheck.Push(new bigGridPosition(0, 0));
            while(placesToCheck.Count > 0)
            {
                bigGridPosition current;
                current = placesToCheck.Pop();

                int x = current.x;
                int y = current.y;
                flooded[x, y] = true;


                if (bigGrid[x, y] == '.')
                {
                    if (x > 0)
                        if (flooded[x - 1, y] == false)
                            placesToCheck.Push(new bigGridPosition(x - 1, y));
                    if (x < lines[0].Length * 3 - 1)
                        if (flooded[x + 1, y] == false)
                            placesToCheck.Push(new bigGridPosition(x + 1, y));

                    if (y > 0)
                        if (flooded[x, y - 1] == false)
                            placesToCheck.Push(new bigGridPosition(x, y - 1));
                    if (y < lines.Length * 3 - 1)
                        if (flooded[x, y + 1] == false)
                            placesToCheck.Push(new bigGridPosition(x, y + 1));
                }


            }

            for (int y = 0; y < lines.Length; y++)
            {
                for(int x = 0; x < lines[0].Length; x++)
                {
                    if (visited[x, y] == false && flooded[x * 3, y * 3] == false)
                        total++;
                }
            }

            Console.WriteLine(pathLength / 2);
            Console.WriteLine(total);
            Console.ReadKey();
        }

        public List<gridPosition> checkSurroundings(int x, int y)
        {
            List<gridPosition> surroundings = new List<gridPosition>();
            List<gridPosition> options = new List<gridPosition> {new gridPosition(x-1, y), new gridPosition(x+1,y), new gridPosition(x,y-1), new gridPosition(x,y+1) };
            gridPosition self = new gridPosition(x, y);

            if (options[0].name == '-' || options[0].name == 'F' || options[0].name == 'L')
                if (self.name == '-' || self.name == 'J' || self.name == '7' || self.name == 'S')
                    surroundings.Add(options[0]); //Left
            if (options[1].name == '-' || options[1].name == '7' || options[1].name == 'J')
                if (self.name == '-' || self.name == 'L' || self.name == 'F' || self.name == 'S')
                    surroundings.Add(options[1]); //Right
            if (options[2].name == '|' || options[2].name == 'F' || options[2].name == '7')
                if (self.name == '|' || self.name == 'L' || self.name == 'J' || self.name == 'S')
                    surroundings.Add(options[2]); //Up
            if (options[3].name == '|' || options[3].name == 'L' || options[3].name == 'J')
                if (self.name == '|' || self.name == 'F' || self.name == '7' || self.name == 'S')
                    surroundings.Add(options[3]); //Down

            return surroundings;
        }

        public struct gridPosition
        {
            public int x;
            public int y;
            public char name;
            public gridPosition(int x, int y)
            {
                this.x = x;
                this.y = y;
                try
                {
                    this.name = Day10.grid[x, y];
                }
                catch
                {
                    this.name = 'Q';
                }
            }
        }

        public struct bigGridPosition
        {
            public int x;
            public int y;
            public char name;
            public bigGridPosition(int x, int y)
            {
                this.x = x;
                this.y = y;
                try
                {
                    this.name = Day10.bigGrid[x, y];
                }
                catch
                {
                    this.name = 'Q';
                }
            }
        }
    }
}
