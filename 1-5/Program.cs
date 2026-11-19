using System;
using System.Collections.Generic;

internal class Program
{
    private const string Path4 = "task4.txt";
    private const string Path5 = "task5.txt";

    static void Main()
    {
        Validator v = new Validator();
        bool running = true;
        int choice = 0;

        do
        {
            PrintMenu();
            choice = v.ReadInt("Номер: ");

            switch (choice)
            {
                case 1:
                    RunTask1(v);
                    break;

                case 2:
                    RunTask2(v);
                    break;

                case 3:
                    RunTask3(v);
                    break;

                case 4:
                    CollectionTasks.FillFile4(Path4);
                    CollectionTasks.Task4(Path4);
                    break;

                case 5:
                    CollectionTasks.FillFile5(Path5, v);
                    Console.WriteLine("\nРезультат:");
                    CollectionTasks.Task5(Path5);
                    break;

                case 0:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        } while (running);
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\n--- ЛАБОРАТОРНАЯ №4 ---");
        Console.WriteLine();
        Console.WriteLine("1. List: Дубликаты");
        Console.WriteLine("2. LinkedList: Соседи");
        Console.WriteLine("3. HashSet: Языки");
        Console.WriteLine("4. HashSet: Буквы");
        Console.WriteLine("5. Школа №50");
        Console.WriteLine("0. Выход");
        Console.WriteLine();
    }

    private static void RunTask1(Validator v)
    {
        int nInt = v.ReadPositiveInt("Сколько int: ");
        List<int> nums =
            CollectionTasks.ReadList(v, nInt);
        Console.WriteLine(
            "\nБыло: " + string.Join(", ", nums));

        List<int> unique =
            CollectionTasks.RemoveDuplicates(nums);
        Console.WriteLine(
            "Стало: " + string.Join(", ", unique));

        int nCircle =
            v.ReadPositiveInt("Сколько Circle: ");
        List<Circle> circles = new List<Circle>();

        int i = 0;
        while (i < nCircle)
        {
            Console.Write($"Радиус {i + 1}: ");
            double r = v.ReadDouble("");
            circles.Add(new Circle(r));
            i++;
        }

        Console.WriteLine(
            "Было: " + string.Join(", ", circles));

        List<Circle> uniqueCircles =
            CollectionTasks.RemoveDuplicates(circles);
        Console.WriteLine(
            "Стало: "
            + string.Join(", ", uniqueCircles));
    }

    private static void RunTask2(Validator v)
    {
        int count =
            v.ReadPositiveInt("Сколько элементов: ");
        List<int> temp =
            CollectionTasks.ReadList(v, count);
        LinkedList<int> linked =
            new LinkedList<int>(temp);

        int e = v.ReadInt("\nЗначение E: ");
        Console.WriteLine(
            "Было: " + string.Join(" ", linked));

        CollectionTasks.SwapNeighbors(linked, e);
        Console.WriteLine(
            "Стало: " + string.Join(" ", linked));
    }

    private static void RunTask3(Validator v)
    {
        Console.WriteLine("Языки через запятую:");
        string? allInput = Console.ReadLine();
        HashSet<string> allLang =
            ReadSetFromLine(allInput);

        int countWorkers =
            v.ReadPositiveInt("Работников: ");
        List<HashSet<string>> workers =
            new List<HashSet<string>>();

        int w = 0;
        while (w < countWorkers)
        {
            Console.Write(
                $"Языки работника {w + 1}: ");
            string? input = Console.ReadLine();
            HashSet<string> raw =
                ReadSetFromLine(input);
            HashSet<string> worker =
                new HashSet<string>();

            foreach (string lang in raw)
            {
                if (allLang.Contains(lang))
                {
                    worker.Add(lang);
                }
                else
                {
                    Console.WriteLine(
                        $"'{lang}' нет в списке, "
                        + "пропущено.");
                }
            }

            workers.Add(worker);
            w++;
        }

        CollectionTasks.Task3(workers, allLang);
    }

    private static HashSet<string> ReadSetFromLine(
        string? line)
    {
        HashSet<string> set = new HashSet<string>();

        if (string.IsNullOrWhiteSpace(line))
        {
            return set;
        }

        string[] parts = line.Split(
            new char[] { ',', ' ' },
            StringSplitOptions.RemoveEmptyEntries);

        foreach (string p in parts)
        {
            set.Add(p.Trim());
        }

        return set;
    }
}