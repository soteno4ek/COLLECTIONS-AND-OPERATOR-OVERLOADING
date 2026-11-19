using System;
using System.IO;
using System.Collections.Generic;

internal class CollectionTasks
{
    public static List<int> ReadList(
        Validator v, int count)
    {
        List<int> list = new List<int>();
        int i = 0;

        while (i < count)
        {
            Console.Write($"Элемент {i + 1}: ");
            list.Add(v.ReadInt(""));
            i++;
        }
        return list;
    }

    public static List<T> RemoveDuplicates<T>(
        List<T> list)
    {
        List<T> result = new List<T>();
        HashSet<T> seen = new HashSet<T>();

        foreach (T item in list)
        {
            if (seen.Add(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public static void SwapNeighbors<T>(
        LinkedList<T> list, T e)
    {
        EqualityComparer<T> cmp =
            EqualityComparer<T>.Default;

        LinkedListNode<T> node = list.First;

        while (node != null)
        {
            if (cmp.Equals(node.Value, e))
            {
                if (node.Previous != null
                    && node.Next != null)
                {
                    if (!cmp.Equals(
                        node.Previous.Value,
                        node.Next.Value))
                    {
                        T temp = node.Previous.Value;
                        node.Previous.Value =
                            node.Next.Value;
                        node.Next.Value = temp;
                    }
                }
            }
            node = node.Next;
        }
    }

    public static void Task3(
        List<HashSet<string>> workers,
        HashSet<string> allLang)
    {
        HashSet<string> allKnow =
            new HashSet<string>(allLang);
        HashSet<string> atLeastOne =
            new HashSet<string>();

        foreach (HashSet<string> worker in workers)
        {
            allKnow.IntersectWith(worker);
            atLeastOne.UnionWith(worker);
        }

        HashSet<string> nobodyKnows =
            new HashSet<string>(allLang);
        nobodyKnows.ExceptWith(atLeastOne);

        PrintSet("Знают все:", allKnow);
        PrintSet("Знает хотя бы один:", atLeastOne);
        PrintSet("Не знает никто:", nobodyKnows);
    }

    private static void PrintSet(
        string header, HashSet<string> set)
    {
        Console.WriteLine($"\n{header}");

        if (set.Count == 0)
        {
            Console.WriteLine("(пусто)");
            return;
        }

        foreach (string s in set)
        {
            Console.WriteLine(s);
        }
    }

    public static void FillFile4(string path)
    {
        Console.WriteLine(
            "Текст (пустая строка - конец):");

        StreamWriter writer =
            new StreamWriter(File.Create(path));

        string? line = Console.ReadLine();

        while (!string.IsNullOrEmpty(line))
        {
            writer.WriteLine(line);
            line = Console.ReadLine();
        }
        writer.Close();
    }

    public static void Task4(string path)
    {
        string text = File.ReadAllText(path);
        HashSet<char> firstLetters =
            new HashSet<char>();
        bool atWordStart = true;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                if (atWordStart)
                {
                    firstLetters.Add(char.ToUpper(c));
                }
                atWordStart = false;
            }
            else if (c != '-')
            {
                atWordStart = true;
            }
        }

        Console.WriteLine("Начальные буквы:");

        foreach (char c in firstLetters)
        {
            Console.WriteLine(c);
        }
    }

    public static void FillFile5(
        string path, Validator v)
    {
        const int School50 = 50;
        const int MinSchool50 = 5;
        const int MinSchool = 1;
        const int MaxSchool = 99;
        const int MinScore = 1;
        const int MaxScore = 100;

        int n = v.ReadPositiveInt(
            "Всего учеников: ");

        while (n < MinSchool50)
        {
            Console.WriteLine(
                "Нужно минимум 5 учеников "
                + "школы № 50.");
            n = v.ReadPositiveInt(
                "Всего учеников: ");
        }

        List<string> lines = new List<string>();
        int count50 = 0;

        while (lines.Count < n
            || count50 < MinSchool50)
        {
            if (lines.Count == n
                && count50 < MinSchool50)
            {
                Console.WriteLine(
                    "В школе № 50 меньше 5 "
                    + "учеников. Добавьте.");
                n++;
            }

            int idx = lines.Count + 1;
            Console.WriteLine($"\nУченик {idx}:");

            string surname = v.ReadWord("Фамилия: ");
            string name = v.ReadWord("Имя: ");
            int school = v.ReadRangeInt(
                "Школа (1-99): ",
                MinSchool, MaxSchool);
            int score = v.ReadRangeInt(
                "Балл (1-100): ",
                MinScore, MaxScore);

            if (school == School50)
            {
                count50++;
            }

            lines.Add(
                $"{surname} {name} "
                + $"{school} {score}");
        }

        using (StreamWriter writer =
            new StreamWriter(File.Create(path)))
        {
            writer.WriteLine(lines.Count);
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }

    public static void Task5(string path)
    {
        const int School50 = 50;
        const int MinSchool50 = 5;
        const int ExpectedParts = 4;
        const int MinSchool = 1;
        const int MaxSchool = 99;
        const int MinScore = 1;
        const int MaxScore = 100;
        const int MaxWordLen = 20;

        string[] allLines = File.ReadAllLines(path);
        if (allLines.Length == 0
            || !int.TryParse(allLines[0], out int n)
            || n < MinSchool50
            || allLines.Length - 1 < n)
        {
            Console.WriteLine("Ошибка данных.");
            return;
        }

        SortedDictionary<int, List<string>> scoresMap =
            new SortedDictionary<int, List<string>>();
        int count50 = 0;

        int i = 1;
        while (i <= n)
        {
            string[] parts = allLines[i].Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != ExpectedParts)
            {
                Console.WriteLine(
                    $"Ошибка в строке {i + 1}.");
                return;
            }

            string surname = parts[0];
            string name = parts[1];

            if (surname.Length > MaxWordLen
                || name.Length > MaxWordLen
                || !int.TryParse(
                    parts[2], out int school)
                || school < MinSchool
                || school > MaxSchool
                || !int.TryParse(
                    parts[3], out int score)
                || score < MinScore
                || score > MaxScore)
            {
                Console.WriteLine(
                    $"Неверные поля в {i + 1}.");
                return;
            }

            if (school == School50)
            {
                count50++;
                if (!scoresMap.ContainsKey(score))
                {
                    scoresMap.Add(
                        score,
                        new List<string>());
                }
                scoresMap[score].Add(
                    $"{surname} {name}");
            }

            i++;
        }

        if (count50 < MinSchool50
            || scoresMap.Count == 0)
        {
            Console.WriteLine(
                "Учеников 50 школы < 5.");
            return;
        }

        List<int> keys =
            new List<int>(scoresMap.Keys);
        int topIdx = keys.Count - 1;
        List<string> best = scoresMap[keys[topIdx]];

        if (best.Count > 2)
        {
            Console.WriteLine(best.Count);
        }
        else if (best.Count == 2)
        {
            Console.WriteLine(best[0]);
            Console.WriteLine(best[1]);
        }
        else
        {
            Console.WriteLine(best[0]);
            if (keys.Count >= 2)
            {
                List<string> second =
                    scoresMap[keys[topIdx - 1]];
                if (second.Count == 1)
                {
                    Console.WriteLine(second[0]);
                }
            }
        }
    }
}