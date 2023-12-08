namespace advent_8;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");

        List<string> node_text = input.Split("\n\n").Last().Split("\n").ToList();
        string instructions = input.Split("\n\n").First();

        int steps = 0;
        string node = "AAA";

        while (true)
        {
            int direction = instructions[steps % instructions.Length].ToString() == "R" ? 1 : 0;

            node = node_text.Find(x => x.StartsWith(node)).Replace(" ", "").Substring(5, 7).Split(",")[direction];

            steps++;
            if (node == "ZZZ") { break; }
        }

        Console.WriteLine(steps);
    }
}
