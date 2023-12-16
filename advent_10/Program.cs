namespace advent_10;

class Program
{
    static public List<string> lines = File.ReadAllLines("input.txt").ToList();

    static void Main(string[] args)
    {
        //Y , X
        (int, int) S_location = (lines.IndexOf(lines.Find(x => x.Contains('S'))), lines.Find(x => x.Contains('S')).IndexOf('S'));
        (int, int) current = S_location.ToTuple().ToValueTuple();
        current.Item1--; // start at the item above S, as S is actually J
        (int, int) last = current.ToTuple().ToValueTuple();

        Console.WriteLine(findnextpipe(current, last, S_location, 1) / 2);
    }

    static long findnextpipe((int, int) current, (int, int) last, (int, int) S_location, long length)
    {
        (int, int) next = current.ToTuple().ToValueTuple();

        if (lines[current.Item1][current.Item2] == '|') { if (last.Item1 == current.Item1 + 1) { next.Item1--; } else { next.Item1++; } }
        else if (lines[current.Item1][current.Item2] == '-') { if (last.Item2 == current.Item2 + 1) { next.Item2--; } else { next.Item2++; } }
        else if (lines[current.Item1][current.Item2] == 'L') { if (last.Item1 == current.Item1 - 1) { next.Item2++; } else { next.Item1--; } }
        else if (lines[current.Item1][current.Item2] == 'J') { if (last.Item1 == current.Item1 - 1) { next.Item2--; } else { next.Item1--; } }
        else if (lines[current.Item1][current.Item2] == '7') { if (last.Item2 == current.Item2 - 1) { next.Item1++; } else { next.Item2--; } }
        else if (lines[current.Item1][current.Item2] == 'F') { if (last.Item2 == current.Item2 + 1) { next.Item1++; } else { next.Item2++; } }

        length++;

        if (current == S_location) { return length; }

        return findnextpipe(next, current, S_location, length);
    }
}
