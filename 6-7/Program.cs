using System;

internal class Program
{
    private const int MaxHour = 23;
    private const int MaxMinute = 59;

    static void Main()
    {
        Validator v = new Validator();
        bool running = true;
        int choice = 0;

        do
        {
            Console.WriteLine(
                "\n--- ЛАБОРАТОРНАЯ №4 ---");
            Console.WriteLine();
            Console.WriteLine(
                "6. Задание 6: Класс Time");
            Console.WriteLine(
                "7. Задание 7: Перегрузки");
            Console.WriteLine("0. Выход");
            Console.WriteLine();

            choice = v.ReadInt("Номер: ");

            switch (choice)
            {
                case 6:
                    Console.WriteLine(
                        "\n--- ЗАДАНИЕ 6 ---");

                    Time def = new Time();
                    Console.WriteLine(
                        $"По умолчанию: {def}");

                    byte h1 = (byte)v.ReadRangeInt(
                        "Часы t1 (0-23): ",
                        0, MaxHour);
                    byte m1 = (byte)v.ReadRangeInt(
                        "Минуты t1 (0-59): ",
                        0, MaxMinute);
                    Time t1 = new Time(h1, m1);
                    Console.WriteLine($"t1 = {t1}");

                    byte h2 = (byte)v.ReadRangeInt(
                        "Часы t2 (0-23): ",
                        0, MaxHour);
                    byte m2 = (byte)v.ReadRangeInt(
                        "Минуты t2 (0-59): ",
                        0, MaxMinute);
                    Time t2 = new Time(h2, m2);
                    Console.WriteLine($"t2 = {t2}");

                    Time res = t1.SubtractTime(t2);
                    Console.WriteLine(
                        $"t1 - t2 = {res}");
                    break;

                case 7:
                    Console.WriteLine(
                        "\n--- ЗАДАНИЕ 7 ---");

                    byte h3 = (byte)v.ReadRangeInt(
                        "Часы t (0-23): ",
                        0, MaxHour);
                    byte m3 = (byte)v.ReadRangeInt(
                        "Минуты t (0-59): ",
                        0, MaxMinute);
                    Time t = new Time(h3, m3);
                    Console.WriteLine($"t = {t}");

                    Time dec = t;
                    dec--;
                    Console.WriteLine(
                        $"t-- = {dec}");

                    byte hours = (byte)t;
                    Console.WriteLine(
                        $"Явно к byte: {hours}");

                    bool isNz = t;
                    Console.WriteLine(
                        $"Неявно к bool: {isNz}");

                    int add = v.ReadNonNegativeInt(
                        "Добавить минут: ");
                    uint addU = (uint)add;
                    Console.WriteLine(
                        $"t + {addU} = {t + addU}");
                    Console.WriteLine(
                        $"{addU} + t = {addU + t}");

                    byte h4 = (byte)v.ReadRangeInt(
                        "Часы t2 (0-23): ",
                        0, MaxHour);
                    byte m4 = (byte)v.ReadRangeInt(
                        "Минуты t2 (0-59): ",
                        0, MaxMinute);
                    Time tPlus = new Time(h4, m4);

                    Console.WriteLine(
                        $"t + t2 = {t + tPlus}");
                    break;

                case 0:
                    running = false;
                    break;

                default:
                    Console.WriteLine(
                        "Неверный выбор");
                    break;
            }
        } while (running);
    }
}