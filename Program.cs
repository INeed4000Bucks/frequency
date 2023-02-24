using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        StreamReader input = new StreamReader("input1.txt");
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        char[] unincluded = { ',', ' ', '.', ';', '\u200B', '，', '？', '\v', '\n', '。', '【', '】', '：', '“', '”', '，', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        var startTime = DateTime.Now;
        while (true)
        {
            int charNum = input.Read();
            if (charNum == -1)
            {
                break;
            }

            char character = Convert.ToChar(charNum);
            if (frequency.ContainsKey(character))
            {
                frequency[character]++;
            }
            else if (Array.IndexOf(unincluded, character) == -1)
            {
                frequency[character] = 1;
            }
        }
        var endTime = DateTime.Now;
        var executionTime = endTime - startTime;

        input.Close();

        DateTime now = DateTime.Now;
        string dateTimeStr = now.ToString("yyyy-MM-dd--HH-mm-ss");

        StreamWriter output;
        try
        {
            output = new StreamWriter($"{dateTimeStr} out.txt", false);
        }
        catch
        {
            output = new StreamWriter($"{dateTimeStr} out.txt", true);
        }

        foreach (KeyValuePair<char, int> entry in frequency)
        {
            output.WriteLine($"{entry.Key}: {entry.Value}");
        }

        output.Close();

        Console.WriteLine("Done");
        Console.WriteLine();
        Console.WriteLine($"Execution time: {executionTime.TotalSeconds} seconds.");
    }
}
