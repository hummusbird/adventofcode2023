namespace advent_7;

class Program
{
    static void Main(string[] args)
    {
        List<string> hands = File.ReadAllLines("input.txt").ToList();

        List<string> sort = new List<string> { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };

        List<string> five = new();      // AAAAA
        List<string> four = new();      // 55559
        List<string> fullhouse = new(); // 23332
        List<string> three = new();     // TTT98
        List<string> two = new();       // 23432
        List<string> one = new();       // A23A4
        List<string> zero = new();      // 23456

        foreach (string hand in hands)
        {
            string cards = hand.Split(" ")[0];

            switch (cards.Distinct().ToList().Count)
            {
                case 1: // AAAAA
                    five.Add(hand);
                    break;

                case 2:
                    if (cards.Count(x => x == cards[0]) == 2 || cards.Count(x => x == cards[0]) == 3)
                    { fullhouse.Add(hand); } // 23332
                    else { four.Add(hand); } // 55559
                    break;

                case 3: // TTT98, 22334
                    List<char> distinct = cards.Distinct().ToList();
                    if (cards.Count(x => x == distinct[0]) == 2 || cards.Count(x => x == distinct[1]) == 2 || cards.Count(x => x == distinct[2]) == 2)
                    { two.Add(hand); } // 22334
                    else { three.Add(hand); } // TTT98
                    break;

                case 4: // A23A4
                    one.Add(hand);
                    break;

                case 5: // 23456
                    zero.Add(hand);
                    break;
            }
        }

        Console.WriteLine("no pairs   " + zero.Count);
        Console.WriteLine("one pair   " + one.Count);
        Console.WriteLine("two pairs  " + two.Count);
        Console.WriteLine("three kind " + three.Count);
        Console.WriteLine("full house " + fullhouse.Count);
        Console.WriteLine("four kind  " + four.Count);
        Console.WriteLine("five kind  " + five.Count);

        zero = zero.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        one = one.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        two = two.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        three = three.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        fullhouse = fullhouse.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        four = four.OrderByDescending(x => sort.IndexOf(x[0].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[1].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[2].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[3].ToString()))
            .ThenByDescending(x => sort.IndexOf(x[4].ToString())).ToList();

        five = five.OrderByDescending(x => sort.IndexOf(x[0].ToString())).ToList();

        List<string> concat = zero.Concat(one).Concat(two).Concat(three).Concat(fullhouse).Concat(four).Concat(five).ToList();

        ulong score = 0;

        for (int i = 0; i < concat.Count; i++)
        {
            score += ulong.Parse(concat[i].Split(" ")[1]) * (ulong)(i + 1);
        }

        Console.WriteLine(score);
    }
}
