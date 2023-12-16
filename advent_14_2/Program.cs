namespace advent_14_2;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("test.txt").ToList();
        List<List<string>> results = new();

        results.Add(moveEast(moveSouth(moveWest(moveNorth(input.ToList())))));

        for (int i = 1; i < 1000000000; i++)
        {
            List<string> cycle = moveEast(moveSouth(moveWest(moveNorth(results[^1].ToList()))));

            foreach (List<string> search in results)
            {
                if (search.SequenceEqual(cycle))
                {
                    int loopstart = results.IndexOf(search);
                    int length = i - loopstart;
                    int lastIndex = ((1000000000 - loopstart) % length) + 1;

                    Console.WriteLine(loopstart + " " + i + " " + length + " " + lastIndex);

                    long load = 0;

                    for (int j = 0; j < results[lastIndex].Count; j++)
                    {
                        load += results[lastIndex][j].Count(c => c == 'O') * (results[lastIndex].Count - j);
                    }

                    Console.WriteLine(load);

                    Environment.Exit(0);
                }
            }

            results.Add(cycle);
        }
    }

    static List<string> moveNorth(List<string> input)
    {
        for (int y = 1; y < input.Count; y++)
        {
            int cur_Y = y;
            for (int x = 0; x < input[cur_Y].Length; x++)
            {
                while (input[cur_Y][x] == 'O' && cur_Y > 0 && input[cur_Y - 1][x] == '.')
                {
                    char[] lastline = input[cur_Y - 1].ToCharArray();
                    lastline[x] = 'O';
                    input[cur_Y - 1] = new string(lastline);

                    char[] currline = input[cur_Y].ToCharArray();
                    currline[x] = '.';
                    input[cur_Y] = new string(currline);

                    cur_Y--;
                }
                cur_Y = y;
            }
        }

        return input;
    }

    static List<string> moveSouth(List<string> input)
    {
        input.Reverse();
        List<string> south = moveNorth(input);
        south.Reverse();
        return south;
    }

    static List<string> moveWest(List<string> input)
    {
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 1; x < input[y].Length; x++)
            {
                int cur_X = x;

                while (input[y][cur_X] == 'O' && cur_X > 0 && input[y][cur_X - 1] == '.')
                {
                    char[] thisline = input[y].ToCharArray();
                    thisline[cur_X] = '.';
                    thisline[cur_X - 1] = 'O';

                    input[y] = new string(thisline);
                    cur_X--;
                }
            }
        }

        return input;
    }

    static List<string> moveEast(List<string> input)
    {
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = input[y].Length - 1; x >= 0; x--)
            {
                int cur_X = x;

                while (input[y][cur_X] == 'O' && cur_X < input[y].Length - 1 && input[y][cur_X + 1] == '.')
                {
                    char[] thisline = input[y].ToCharArray();
                    thisline[cur_X] = '.';
                    thisline[cur_X + 1] = 'O';

                    input[y] = new string(thisline);
                    cur_X++;
                }
            }
        }

        return input;
    }
}