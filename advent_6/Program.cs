using System.Collections.Immutable;

namespace advent_6;
class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("input.txt").ToList();

        List<ulong> time = input[0].Replace("Time: ", "").Split(" ").Select(ulong.Parse).ToList();
        List<ulong> distance = input[1].Replace("Distance: ", "").Split(" ").Select(ulong.Parse).ToList();

        List<ulong> waystowin = new();

        for (int i = 0; i < time.Count; i++)
        {
            waystowin.Add(0);

            for (ulong j = 0; j < time[i]; j++)
            {
                ulong dist = (time[i] - j) * j;
                if (dist > distance[i]) { waystowin[i]++; }
            }
        }

        ulong score = 1;

        foreach (ulong i in waystowin)
        {
            score *= i;
        }

        Console.WriteLine(score);
    }
}
