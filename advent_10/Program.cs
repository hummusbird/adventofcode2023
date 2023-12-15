namespace advent_10;

class Program
{
    static void Main(string[] args)
    {
        List<string> lines = File.ReadAllLines("test2.txt").ToList();
        ulong length = 0;
        //Y , X
        (int, int) S_location = (lines.IndexOf(lines.Find(x => x.Contains('S'))), lines.Find(x => x.Contains('S')).IndexOf('S'));
        (int, int) current = S_location.ToTuple().ToValueTuple();

        while (true)
        {



        }
    }
}
