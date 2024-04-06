/*ставить программу для обработки очередей и стеков. 10.	
 * Составить программу, формирующую стек Sиз всех различных элементов очередей L1и L2.(вар 10)*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем очереди L1 и L2
        Queue<int> L1 = new Queue<int>();
        Queue<int> L2 = new Queue<int>();

        // Заполняем очереди произвольными значениями 
        L1.Enqueue(1);
        L1.Enqueue(22);
        L1.Enqueue(31);

        L2.Enqueue(3);
        L2.Enqueue(42);
        L2.Enqueue(22);

        // Формируем стек S из всех различных элементов очередей L1 и L2
        Stack<int> S = MergeQueuesToStack(L1, L2);

        // Выводим содержимое стека S
        Console.WriteLine("Стек S из всех различных элементов очередей L1 и L2:");
        PrintStack(S);

        Console.ReadLine();
    }

    static Stack<int> MergeQueuesToStack(Queue<int> queue1, Queue<int> queue2)
    {
        // Создаем временное множество для хранения уникальных элементов
        HashSet<int> uniqueElements = new HashSet<int>();

        // Обрабатываем очередь L1
        while (queue1.Count > 0)
        {
            int element = queue1.Dequeue();
            uniqueElements.Add(element);
        }

        // Обрабатываем очередь L2
        while (queue2.Count > 0)
        {
            int element = queue2.Dequeue();
            uniqueElements.Add(element);
        }

        // Создаем стек и добавляем в него уникальные элементы
        Stack<int> resultStack = new Stack<int>(uniqueElements);
        return resultStack;
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (int element in stack)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
