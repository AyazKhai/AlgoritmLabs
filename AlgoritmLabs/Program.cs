/*составить программу, создающуюсписок Sи выводящую его после некоторой обработки.5.
 * S– цепочка целых чисел. Добавить после каждого отрицательного элемента новый нулевой элемент(Вар 5)
 */
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем исходный список S
        List<int> S = new List<int> { 1, -2, 3, -4, 5 };
        Console.WriteLine("Исходный список S:");
        PrintList(S);
        // Обработка списка: добавление нового нулевого элемента после каждого отрицательного элемента
        ProcessList(S);
        // Вывод обработанного списка
        Console.WriteLine("\nСписок S после обработки:");
        PrintList(S);
        Console.ReadLine();
    }

    static void ProcessList(List<int> list)
    {
        // Создаем временный список для хранения результатов обработки
        List<int> processedList = new List<int>();
        // Обходим исходный список
        foreach (int num in list)
        {
            // Добавляем текущий элемент в новый список
            processedList.Add(num);

            // Если текущий элемент отрицателен, добавляем новый нулевой элемент
            if (num < 0)
            {
                processedList.Add(0);
            }
        }
        // Очищаем исходный список и добавляем в него все элементы из обработанного списка
        list.Clear();
        list.AddRange(processedList);
    }
    static void PrintList(List<int> list)
    {
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}

