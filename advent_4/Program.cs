using System.Globalization;

namespace advent_4;
class Program
{
    static void Main(string[] args)
    {
        string[] cards = File.ReadAllLines("test.txt");

        List<int> points = new();

        foreach (string card in cards)
        {
            List<int> numbers = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[0].Split(" ").ToList().Select(int.Parse).ToList();
            List<int> winners = card.Replace("  ", " ").Split(": ")[1].Split(" | ")[1].Split(" ").ToList().Select(int.Parse).ToList();

            points.Add((int)Math.Pow(2, numbers.Intersect(winners).Count() - 1));
        }

        Console.WriteLine(points.Sum());
    }
}
