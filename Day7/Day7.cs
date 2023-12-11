using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day7
    {

        public Day7()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\AdventOfCode2023\Day7.txt");


            int total = 0;
            List<Hand> hands = new List<Hand>();
            List<Hand> currentResult;

            for (int i = 0; i < lines.Length; i++)
            {
                string cards = lines[i].Split(' ')[0];
                int betAmount = int.Parse(lines[i].Split(' ')[1]);
                Result result = Result.Highcard;
                int jokers = 0;

                var tmp = cards
                    .GroupBy(c => c)
                    .Select(g => new { Letter = g.Key, Count = g.Count() })
                    .ToList();

                for(int j = 0; j < tmp.Count; j++)
                    if (tmp[j].Letter == 'J')
                        jokers += tmp[j].Count;

                if (tmp.Count() == 1)
                    result = Result.Fiveofakind;
                if (tmp.Count() == 2)
                {
                    for (int j = 0; j < tmp.Count(); j++)
                    {
                        if (tmp[j].Count == 4)
                        {
                            if (jokers > 0)
                                result = Result.Fiveofakind;
                            else
                                result = Result.Fourofakind;
                            break;
                        }
                        else
                        {
                            if (jokers > 0)
                                result = Result.Fiveofakind;
                            else
                                result = Result.Fullhouse;
                        }
                    }
                }
                if (tmp.Count() == 3)
                {
                    for(int j = 0; j < tmp.Count(); j++)
                    {
                        if (tmp[j].Count == 3)
                        {
                            if (jokers > 0)
                                result = Result.Fourofakind;
                            else
                                result = Result.Threeofakind;
                            break;
                        }
                        else
                        {
                            if (jokers == 1)
                                result = Result.Fullhouse;
                            else if (jokers == 2)
                                result = Result.Fourofakind;
                            else
                                result = Result.Twopair;

                        }
                    }
                }
                if (tmp.Count() == 4)
                    if (jokers > 0)
                        result = Result.Threeofakind;
                    else
                        result = Result.Pair;
                if (tmp.Count() == 5)
                    if (jokers > 0)
                        result = Result.Pair;
                    else    
                        result = Result.Highcard;

                hands.Add(new Hand(cards, betAmount, result));
            }

            int counter = 1;

            for(int i = 0; i < 7; i++)
            {
                currentResult = new List<Hand>();
                foreach(Hand hand in hands)
                {
                    if(hand.result == (Result)i)
                    {
                        currentResult.Add(hand);
                    }
                }

                currentResult.Sort((x,y) => x.constructedString.CompareTo(y.constructedString));

                for (int j = 0; j < currentResult.Count(); j++)
                {
                    total += currentResult[j].betAmount * counter;
                    counter++;
                }
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }

        struct Hand
        {
            string input;
            public int[] cards = new int[5];
            public string constructedString = "";
            public int betAmount;
            public Result result;

            public Hand(string input, int betAmount, Result result)
            {
                this.input = input;
                this.betAmount = betAmount;
                this.result = result;

                for(int i = 0; i < 5; i++)
                {
                    switch(input[i])
                    {
                        case 'T':
                            cards[i] = 10;
                            break;
                        case 'J':
                            cards[i] = 1;
                            break;
                        case 'Q':
                            cards[i] = 11;
                            break;
                        case 'K':
                            cards[i] = 12;
                            break;
                        case 'A':
                            cards[i] = 13;
                            break;
                        default:
                            cards[i] = input[i] - 48;
                            break;
                    }
                    constructedString += (char)(cards[i] + 64);
                }
            }
        }

        enum Result
        {
            Highcard,
            Pair,
            Twopair,
            Threeofakind,
            Fullhouse,
            Fourofakind,
            Fiveofakind
        }
    }
}
