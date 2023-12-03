namespace advent_3;
class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("test.txt");

        int total = 0;

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                int length = 0;

                while ((x < input[y].Length) && input[y][x] >= '0' && input[y][x] <= '9') // check for numbers and count their length
                {
                    length++;
                    x++;
                }

                x -= length; // set x position back to the start of the number, we're now going to check for surrounding symbols

                if (length != 0) // if the length is zero, we're not on a number so skip
                {
                    bool found = false;

                    for (int k = -1; k <= 1; k++) // k is our y incrementor
                    {
                        if (y == 0 && k < 0) { k++; } // don't go out of range
                        else if (y + k == input.Count() || found) { break; } // don't go out of range

                        for (int j = -1; j <= length + 1; j++) // j is our x incrementor
                        {
                            if (x == 0 && j < 0) { j++; } // don't go out of range
                            else if (x + j == input[y].Count() || found) { break; } // dont go out of range

                            //Console.WriteLine("length:\t" + length + "\nx: " + x + " y: " + y + "\nj: " + j + " k: " + k);

                            if (((input[y + k][x + j] < '0') || (input[y + k][x + j] > '9')) && input[y + k][x + j] != '.') // anything that isn't a number or '.'
                            {
                                found = true;
                                int number = 0;

                                for (int h = 0; h < length; h++)
                                {
                                    number += (int)(int.Parse(input[y][x + h].ToString()) * Math.Pow(10, length - h - 1)); // we create the number like this: 4*100 + 6*10 + 1*1 = 461
                                }

                                Console.WriteLine("number:\t" + number);
                                //Console.WriteLine("\nsymbol:\t" + input[y + k][x + j]);
                                //Console.WriteLine("coords:\t" + (y + k + 1) + "," + (x + j + 1));
                                total += number; // add number to total
                                break;
                            }
                        }
                    }

                    x += length; // set x back to the end, so we don't search the same number again
                }
            }
        }

        Console.WriteLine(total);
    }
}
