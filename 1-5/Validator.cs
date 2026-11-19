using System;

internal class Validator
{
    private const int MinWordLength = 1;
    private const int MaxWordLength = 20;

    public int ReadInt(string prompt)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();
        int x = 0;

        while (!int.TryParse(s, out x))
        {
            Console.WriteLine("Только цифры");
            Console.WriteLine();
            Console.Write(prompt);
            s = Console.ReadLine();
        }
        return x;
    }

    public int ReadPositiveInt(string prompt)
    {
        int x;
        do
        {
            x = ReadInt(prompt);
            if (x <= 0)
            {
                Console.WriteLine("Число > 0");
            }
        } while (x <= 0);
        return x;
    }

    public int ReadRangeInt(
        string prompt, int min, int max)
    {
        int x;
        do
        {
            x = ReadInt(prompt);
            if (x < min || x > max)
            {
                Console.WriteLine(
                    $"Ошибка: от {min} до {max}");
            }
        } while (x < min || x > max);
        return x;
    }

    public double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();
        double x = 0;

        while (!double.TryParse(s, out x) || x < 0)
        {
            Console.WriteLine("Число >= 0");
            Console.WriteLine();
            Console.Write(prompt);
            s = Console.ReadLine();
        }
        return x;
    }

    public string ReadWord(string prompt)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(s)
            || !IsValidWord(s))
        {
            Console.WriteLine(
                "Буквы и '-', до 20 симв.,");
            Console.WriteLine("без пробелов.");
            Console.Write(prompt);
            s = Console.ReadLine();
        }
        return s!;
    }

    private static bool IsValidWord(string? s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        if (s.Length < MinWordLength
            || s.Length > MaxWordLength)
        {
            return false;
        }

        bool hasLetter = false;

        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
            }
            else if (c != '-')
            {
                return false;
            }
        }
        return hasLetter;
    }
}