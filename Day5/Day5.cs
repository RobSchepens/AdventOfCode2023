using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day5
    {

        public Day5()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day5.txt");

            long bestResult = long.MaxValue;

            string[] tmpSeeds = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            long[] longs = new long[tmpSeeds.Length - 1];
            List<SeedRange> seeds = new List<SeedRange>();

            for(int i = 0; i < longs.Length; i++)
            {
                longs[i] = long.Parse(tmpSeeds[i + 1]);
            }

            for(int i = 0; i < longs.Length; i+=2)
            {
                seeds.Add(new SeedRange(longs[i], longs[i+1]));
            }
            

            int currentRow = 3;

            List<Range> seedSoil = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                seedSoil.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> soilFertilizer = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                soilFertilizer.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> fertilizerWater = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                fertilizerWater.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> waterLight = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                waterLight.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> lightTemperature = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                lightTemperature.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> temperatureHumidity = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                temperatureHumidity.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }
            currentRow += 2;

            List<Range> humidityLocation = new List<Range>();
            while (lines[currentRow] != "")
            {
                string[] line = lines[currentRow].Split(' ');
                humidityLocation.Add(new Range(long.Parse(line[0]), long.Parse(line[1]), long.Parse(line[2])));

                currentRow++;
            }

            for(int i = 0; i < seeds.Count; i++)
            {
                SeedRange seed = seeds[i];

                for(long k = seed.start; k < seed.end; k++)
                {
                    long currentLong = k;
                    for (int j = 0; j < seedSoil.Count; j++)
                    {
                        if (seedSoil[j].ContainsSource(currentLong))
                        {
                            currentLong = seedSoil[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < soilFertilizer.Count; j++)
                    {
                        if (soilFertilizer[j].ContainsSource(currentLong))
                        {
                            currentLong = soilFertilizer[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < fertilizerWater.Count; j++)
                    {
                        if (fertilizerWater[j].ContainsSource(currentLong))
                        {
                            currentLong = fertilizerWater[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < waterLight.Count; j++)
                    {
                        if (waterLight[j].ContainsSource(currentLong))
                        {
                            currentLong = waterLight[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < lightTemperature.Count; j++)
                    {
                        if (lightTemperature[j].ContainsSource(currentLong))
                        {
                            currentLong = lightTemperature[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < temperatureHumidity.Count; j++)
                    {
                        if (temperatureHumidity[j].ContainsSource(currentLong))
                        {
                            currentLong = temperatureHumidity[j].GiveDestination(currentLong);
                            break;
                        }
                    }
                    for (int j = 0; j < humidityLocation.Count; j++)
                    {
                        if (humidityLocation[j].ContainsSource(currentLong))
                        {
                            currentLong = humidityLocation[j].GiveDestination(currentLong);
                            break;
                        }
                    }

                    if (currentLong < bestResult)
                        bestResult = currentLong;

                }
            }
            Console.WriteLine(bestResult);
            Console.ReadKey();
        }

        struct Range
        {
            public long destination;
            public long source;
            public long range;

            public Range(long destination, long source, long range)
            {
                this.destination = destination;
                this.source = source;
                this.range = range;
            }

            public bool ContainsSource(long x)
            {
                return x >= source && x < source + range;
            }

            public long GiveDestination(long x)
            {
                return destination + (x - source);
            }
        }

        struct SeedRange
        {
            public long start;
            public long range;
            public long end;

            public SeedRange(long start, long range)
            {
                this.start = start;
                this.range = range;
                end = start + range;
            }
        }
    }
}
