using System.Net;

namespace advent_8_2;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");

        List<string> node_text = input.Split("\n\n").Last().Split("\n").ToList();
        string instructions = input.Split("\n\n").First();

        List<string> nodes = new(node_text.FindAll(x => x[2] == 'A'));
        ulong[] loops = new ulong[nodes.Count];

        for (int i = 0; i < loops.Length; i++) { loops[i] = new(); }

        for (int i = 0; i < nodes.Count; i++)
        {
            ulong steps = 0;
            while (true)
            {
                int direction = instructions[(int)steps % instructions.Length].ToString() == "R" ? 1 : 0;
                nodes[i] = node_text.Find(x => x.StartsWith(nodes[i])).Replace(" ", "").Substring(5, 7).Split(",")[direction];

                if (nodes[i][2] == 'Z')
                {
                    Console.WriteLine("found " + nodes[i] + " for node " + i + " after " + steps + 1);
                    loops[i] = steps + 1;
                    break;
                }
                steps++;
            }
        }

        ulong score = loops[0];

        for (int i = 1; i < loops.Length; i++)
        {
            score = lcm(score, loops[i]);
        }

        Console.WriteLine(score);
    }

    static ulong gcf(ulong a, ulong b)
    {
        while (b != 0)
        {
            ulong temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static ulong lcm(ulong a, ulong b)
    {
        return (a / gcf(a, b)) * b;
    }
}
