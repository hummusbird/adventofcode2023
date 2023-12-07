namespace advent_7_2;

class Program
{
    static void Main(string[] args)
    {
        List<string> hands = File.ReadAllLines("input.txt").ToList();

        List<string> sort = new() { "A", "K", "Q", "T", "9", "8", "7", "6", "5", "4", "3", "2", "J" };

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

            int handtype = 0;

            for (int i = 0; i < sort.Count - 1; i++)
            {
                string replaced = cards.Replace("J", sort[i]);

                switch (replaced.Distinct().ToList().Count)
                {
                    case 1: // AAAAA five of a kind
                        five.Add(hand);
                        break;

                    case 2:
                        if (replaced.Count(x => x == replaced[0]) == 2 || replaced.Count(x => x == replaced[0]) == 3)
                        { handtype = handtype < 4 ? 4 : handtype; } // 23332 fullhouse
                        else { handtype = handtype < 5 ? 5 : handtype; } // 55559 four of a kind
                        break;

                    case 3: // TTT98, 22334
                        List<char> distinct = replaced.Distinct().ToList();
                        if (replaced.Count(x => x == distinct[0]) == 2 || replaced.Count(x => x == distinct[1]) == 2 || replaced.Count(x => x == distinct[2]) == 2)
                        { handtype = handtype < 2 ? 2 : handtype; } // 22334 two pair
                        else { handtype = handtype < 3 ? 3 : handtype; } // TTT98 three of a kind
                        break;

                    case 4: // A23A4 one pair
                        handtype = handtype < 1 ? 1 : handtype;
                        break;

                    case 5: // 23456 no matches
                        handtype = handtype < 0 ? 0 : handtype;
                        break;
                }
            }

            switch (handtype)
            {
                case 0:
                    zero.Add(hand);
                    break;
                case 1:
                    one.Add(hand);
                    break;
                case 2:
                    two.Add(hand);
                    break;
                case 3:
                    three.Add(hand);
                    break;
                case 4:
                    fullhouse.Add(hand);
                    break;
                case 5:
                    four.Add(hand);
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

        ulong score = 0;

        List<string> concat = zero.Concat(one).Concat(two).Concat(three).Concat(fullhouse).Concat(four).Concat(five).ToList();

        for (int i = 0; i < concat.Count; i++)
        {
            score += ulong.Parse(concat[i].Split(" ")[1]) * (ulong)(i + 1);
        }

        Console.WriteLine(score);
    }
}
