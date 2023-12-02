namespace advent_2;
class Program
{
    static void Main(string[] args)
    {
        string[] inputtext = File.ReadAllText("input.txt").Split("\n");

        List<List<List<string>>> games = new();

        foreach (var game in inputtext)
        {
            List<List<string>> newgame = new();
            foreach (var round in game.Split(": ")[1].Split("; ").ToList())
            {
                newgame.Add(round.Split(", ").ToList());
            }
            games.Add(newgame);
        }

        int red = 12;
        int green = 13;
        int blue = 14;

        List<int> impossiblegames = new();
        List<int> gamepowers = new();

        foreach (List<List<string>> game in games)
        {
            int lowestred = 0;
            int lowestgreen = 0;
            int lowestblue = 0;

            foreach (List<string> round in game)
            {
                foreach (string colour in round)
                {
                    int num = int.Parse(colour.Split(" ")[0]);
                    string col = colour.Split(" ")[1];

                    switch (col)
                    {
                        case "red":
                            if (num > red) { impossiblegames.Add(games.IndexOf(game) + 1); }
                            if (num > lowestred) { lowestred = num; }
                            break;

                        case "green":
                            if (num > green) { impossiblegames.Add(games.IndexOf(game) + 1); }
                            if (num > lowestgreen) { lowestgreen = num; }
                            break;

                        case "blue":
                            if (num > blue) { impossiblegames.Add(games.IndexOf(game) + 1); }
                            if (num > lowestblue) { lowestblue = num; }
                            break;
                    }
                }
            }

            gamepowers.Add(lowestred * lowestgreen * lowestblue);
        }

        impossiblegames = impossiblegames.Distinct().ToList();

        int total = 0;

        for (int i = 1; i < games.Count() + 1; i++) { if (!impossiblegames.Contains(i)) { total += i; } }

        Console.WriteLine("part one: " + total);
        Console.WriteLine("part two: " + gamepowers.Sum());
    }
}
