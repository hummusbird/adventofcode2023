namespace advent_15;

class Program
{
    static void Main(string[] args)
    {
        List<string> strings = File.ReadAllText("input.txt").Split(",").ToList();
        int sum = 0;

        foreach (string step in strings)
        {
            int value = 0;
            foreach (char character in step)
            {
                value += character;
                value *= 17;
                value %= 256;
            }

            sum += value;
        }

        Console.WriteLine(sum);
    }
}
