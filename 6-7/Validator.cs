using System;

internal class Validator
{
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

    public int ReadNonNegativeInt(string prompt)
    {
        int x;
        do
        {
            x = ReadInt(prompt);
            if (x < 0)
            {
                Console.WriteLine("Число >= 0");
            }
        } while (x < 0);
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
}