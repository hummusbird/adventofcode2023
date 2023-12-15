namespace advent_14;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("input.txt").ToList();

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

        int load = 0;

        for (int i = 0; i < input.Count; i++)
        {
            load += input[i].Count(c => c == 'O') * (input.Count - i);
        }

        Console.WriteLine(load);
    }
}