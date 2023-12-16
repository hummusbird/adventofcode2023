namespace advent_15_2;

class Program
{
    static void Main(string[] args)
    {
        List<string> instructions = File.ReadAllText("input.txt").Split(",").ToList();
        List<Lens>[] boxes = new List<Lens>[256];

        for (int i = 0; i < boxes.Length; i++) { boxes[i] = new(); }

        foreach (string instruction in instructions)
        {
            if (instruction.Contains('-'))
            {
                string label = instruction.Replace("-", "");
                int box = hash(label);

                boxes[box].Remove(boxes[box].Find(l => l.label == label));
            }
            else
            {
                string label = instruction.Split("=")[0];
                int box = hash(label);
                int focallength = int.Parse(instruction.Split("=")[1]);

                if (boxes[box].Any(l => l.label == label)) { boxes[box].Find(l => l.label == label).focallength = focallength; }
                else
                {
                    boxes[box].Add(new Lens()
                    {
                        label = label,
                        focallength = focallength
                    });
                }
            }
        }

        int focussingpower = 0;

        for (int box = 0; box < boxes.Length; box++)
        {
            for (int lens = 0; lens < boxes[box].Count; lens++)
            {
                focussingpower += (box + 1) * (lens + 1) * boxes[box][lens].focallength;
            }
        }

        Console.WriteLine(focussingpower);
    }

    static int hash(string step)
    {
        int value = 0;
        foreach (char character in step)
        {
            value += character;
            value *= 17;
            value %= 256;
        }

        return value;
    }

    class Lens
    {
        public string label;
        public int focallength;
    }
}
