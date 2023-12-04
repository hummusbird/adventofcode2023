using System.Globalization;

namespace advent_4;
class Program
{
    static void Main(string[] args)
    {
        string[] cards = File.ReadAllLines("input.txt");

        int points = 0;

        foreach (string card in cards)
        {
            List<int> numbers = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[0].Split(" ").ToList().Select(int.Parse).ToList();
            List<int> winners = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[1].Split(" ").ToList().Select(int.Parse).ToList();

            points += (int)Math.Pow(2, numbers.Intersect(winners).Count() - 1);
        }

        Console.WriteLine(points);
    }
}
