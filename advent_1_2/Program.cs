namespace advent_1_2;
class Program
{
    static void Main(string[] args)
    {
        string[] instructions = File.ReadAllText("input.txt").Split("\n");

        string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        List<int> calibrations = new();

        foreach (string line in instructions)
        {
            for (int i = 0; i < line.Length; i++)
            {
                bool foundfirst = false;

                if (int.TryParse(line[i].ToString(), out int value))
                {
                    calibrations.Add(value * 10);
                    break;
                }

                foreach (string num in numbers)
                {
                    if (line.Length - i + 1 - num.Length > 0) // prevent going out of range when matching substrings
                    {
                        if (line.Substring(i, num.Length) == num) // try and match every number to each substring of its length
                        {
                            calibrations.Add((Array.IndexOf(numbers, num) + 1) * 10);
                            foundfirst = true;
                            break;
                        }
                    }
                }

                if (foundfirst) { break; }
            }

            for (int i = line.Length - 1; i >= 0; i--)
            {
                bool foundlast = false;

                if (int.TryParse(line[i].ToString(), out int value))
                {
                    calibrations[^1] += value;
                    break;
                }

                foreach (string num in numbers)
                {
                    if (line.Length - i + 1 - num.Length > 0) // prevent going out of range when matching substrings
                    {
                        if (line.Substring(i, num.Length) == num) // try and match every number to each substring of its length, in reverse
                        {
                            calibrations[^1] += Array.IndexOf(numbers, num) + 1;
                            foundlast = true;
                            break;
                        }
                    }
                }
                if (foundlast) { break; }
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
