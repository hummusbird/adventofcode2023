namespace advent_1;
class Program
{
    static void Main(string[] args)
    {
        string[] instructions = File.ReadAllText("input.txt").Split("\n");

        List<int> calibrations = new();

        foreach (string line in instructions)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (int.TryParse(line[i].ToString(), out int value))
                {
                    //Console.WriteLine(value);
                    calibrations.Add(value * 10);
                    break;
                }
            }

            for (int i = line.Length; i >= 0; i--)
            {
                if (int.TryParse(line[i - 1].ToString(), out int value))
                {
                    //Console.WriteLine(value);
                    calibrations[^1] += value;
                    break;
                }
            }
        }

        int total = 0;

        foreach (int num in calibrations)
        {
            Console.WriteLine(num);
            total += num;
        }

        Console.WriteLine("Total: " + total);
    }
}
