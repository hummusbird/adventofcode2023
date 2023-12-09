namespace advent_9;

class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("input.txt");
        int nextvalue = 0;
        int prevvalue = 0;

        foreach (string line in input)
        {
            List<int> list = line.Split(" ").Select(int.Parse).ToList();
            nextvalue += difference(list) + list[^1];
            list.Reverse();
            prevvalue += difference(list) + list[^1];
        }

        Console.WriteLine(nextvalue);
        Console.WriteLine(prevvalue);
    }

    static int difference(List<int> list)
    {
        List<int> diff = new();
        for (int i = 0; i < list.Count - 1; i++) { diff.Add(list[i + 1] - list[i]); }
        if (diff.Distinct().ToList().Count == 1 && diff.Distinct().ToList()[0] == 0) { return 0; }

        return diff[^1] + difference(diff);
    }
}
