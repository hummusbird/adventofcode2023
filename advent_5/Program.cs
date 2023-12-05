namespace advent_5;
class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("test2.txt");

        List<long> seeds = input.Split("\n")[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();

        List<string> groups = input.Split("\n\n").ToList();
        List<List<List<long>>> maps = new();

        for (int i = 1; i < groups.Count; i++)
        {
            List<string> mapinput = groups[i].Split("\n").ToList();
            List<List<long>> map = new();

            for (int j = 1; j < mapinput.Count; j++)
            {
                map.Add(mapinput[j].Split(" ").Select(long.Parse).ToList());
            }

            maps.Add(map);
        }

        List<long> outputs = new();
        long lowest = 9999999999;

        foreach (long seed in seeds)
        {
            outputs.Add(GoDeeper(seed, maps, 0));
        }

        for (long i = 0; i < seeds.Count; i += 2)
        {
            for (long j = seeds[0]; j < seeds[0] + seeds[1]; j++)
            {
                long output = GoDeeper(j, maps, 0);
                if (output < lowest) { Console.WriteLine(lowest); lowest = output; };
            }
            //if (i % 1000000 == 0) { Console.WriteLine(i); }
        }

        Console.WriteLine("Part 1: " + outputs.Min());
        Console.WriteLine("Part 2: " + lowest);
    }

    static long GoDeeper(long value, List<List<List<long>>> maps, long depth)
    {
        foreach (List<long> range in maps[(int)depth])
        {
            if (value >= range[1] && value <= range[1] + range[2])
            {
                value += range[0] - range[1];
                break;
            }
        }

        depth++;

        if (depth < maps.Count) { value = GoDeeper(value, maps, depth); }

        return value;
    }
}
