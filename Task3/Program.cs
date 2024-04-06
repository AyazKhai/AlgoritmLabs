/*составить программу, создающую очередь с двухсторонним доступом (дек) D и выводящую его на экран после некоторой обработки. Создание и вывод дека на экран оформить в виде процедур для обработки очередей и стеков.8.
 * D– список действительных чисел. Удалить все отрицательные элементы.(вар 8)
 */
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем дек D из списка действительных чисел
        LinkedList<double> D = new LinkedList<double>(new[] { 1.5, -2.0, 3.7, -4.2, 5.0 });

        // Выводим исходный дек D
        Console.WriteLine("Исходный дек D:");
        PrintDeque(D);

        // Удаляем отрицательные элементы из дека D
        RemoveNegativeElements(D);

        // Выводим измененный дек D
        Console.WriteLine("\nДек D после удаления отрицательных элементов:");
        PrintDeque(D);

        Console.ReadLine();
    }

    static void RemoveNegativeElements(LinkedList<double> deque)
    {
        // Создаем временный список для хранения элементов без отрицательных чисел
        LinkedList<double> tempDeque = new LinkedList<double>();

        // Проходим по каждому элементу в деке и добавляем положительные элементы во временный дек
        foreach (double element in deque)
        {
            if (element >= 0)
            {
                tempDeque.AddLast(element);
            }
        }

        // Очищаем исходный дек
        deque.Clear();

        // Добавляем в исходный дек все элементы из временного дека
        foreach (double element in tempDeque)
        {
            deque.AddLast(element);
        }
    }


    static void PrintDeque(LinkedList<double> deque)
    {
        foreach (double element in deque)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
