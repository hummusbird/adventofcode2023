﻿namespace advent_4_2;
class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("input.txt").ToList();

        List<Card> cards = new();

        foreach (string card in input)
        {
            List<int> Numbers = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[0].Split(" ").ToList().Select(int.Parse).ToList();
            List<int> Winners = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[1].Split(" ").ToList().Select(int.Parse).ToList();
            cards.Add(new Card
            {
                Number = int.Parse(card.Replace("  ", " ").Replace("Card ", "").Split(": ")[0]),
                Intersection = Numbers.Intersect(Winners).ToList()
            });
        }

        int i = 0;

        while (i < cards.Count)
        {
            for (int j = cards[i].Number; j < cards[i].Number + cards[i].Intersection.Count; j++)
            {
                cards[j].Amount += cards[i].Amount;
            }

            if (cards.Count % 100 == 0) { Console.WriteLine(cards.Count + " " + cards[i].Number + " " + i); }

            i++;
        }

        Console.WriteLine(cards.Select(card => card.Amount).Sum());
    }

    public class Card
    {
        public int Amount = 1;
        public int Number { get; set; }
        public List<int> Intersection { get; set; }
    }
}
