namespace advent_5;
class Program
{
    static void Main(string[] args)
    {
        /*
            the only reason i'm commiting this code before i found the answer, is just to document how massively
            overengineered i keep writing code. There is no reason i had to store every fucking value, but here
            i am, with a program that runs out of memory in less than thirty seconds. well done, me.
        */

        string input = File.ReadAllText("input.txt");

        List<long> seeds = input.Split("\n")[0].Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();

        Dictionary<long, long> seedtosoil = new();
        foreach (string line in input.Replace("seed-to-soil map:\n", "").Split("\n\n")[1].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                seedtosoil.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> soiltofertilizer = new();
        foreach (string line in input.Replace("soil-to-fertilizer map:\n", "").Split("\n\n")[2].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                soiltofertilizer.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> fertilizertowater = new();
        foreach (string line in input.Replace("fertilizer-to-water map:\n", "").Split("\n\n")[3].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                fertilizertowater.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> watertolight = new();
        foreach (string line in input.Replace("water-to-light map:\n", "").Split("\n\n")[4].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                watertolight.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> lighttotemp = new();
        foreach (string line in input.Replace("light-to-temperature map:\n", "").Split("\n\n")[5].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                lighttotemp.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> temptomoist = new();
        foreach (string line in input.Replace("temperature-to-humidity map:\n", "").Split("\n\n")[6].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                temptomoist.Add(maps[1] + i, maps[0] + i);
            }
        }

        Dictionary<long, long> moisttopos = new();
        foreach (string line in input.Replace("humidity-to-location map:\n", "").Split("\n\n")[7].Split("\n").ToList())
        {
            List<long> maps = line.Split(" ").Select(long.Parse).ToList();

            for (long i = 0; i < maps[2]; i++)
            {
                moisttopos.Add(maps[1] + i, maps[0] + i);
            }
        }

        List<long> locations = new();

        foreach (long seed in seeds)
        {
            long soil = seedtosoil.ContainsKey(seed) ? seedtosoil[seed] : seed;
            long fertilizer = soiltofertilizer.ContainsKey(soil) ? soiltofertilizer[soil] : soil;
            long water = fertilizertowater.ContainsKey(fertilizer) ? fertilizertowater[fertilizer] : fertilizer;
            long light = watertolight.ContainsKey(water) ? watertolight[water] : water;
            long temperature = lighttotemp.ContainsKey(light) ? lighttotemp[light] : light;
            long humidity = temptomoist.ContainsKey(temperature) ? temptomoist[temperature] : temperature;
            long location = moisttopos.ContainsKey(humidity) ? moisttopos[humidity] : humidity;
            locations.Add(location);
        }

        Console.WriteLine(locations.Min());
    }
}
