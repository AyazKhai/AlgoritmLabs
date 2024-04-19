﻿/*5.8	Имеется n бактерий красного цвета. 
 * Через 1 такт времени красная бактерия меняется на зеленую, затем через 1 такт времени делится на красную и зеленую. 
 * Определить, сколько будет всех бактерий через k тактов времени? 
 */

using Task_5._8_Bacterias;

class Program
{

    /// <summary>
    /// Вычисляет сумму последних двух чисел в последовательности Фибоначчи до заданного номера.
    /// </summary>
    /// <param name="k">Номер последнего числа в последовательности Фибоначчи, для которого нужно вычислить сумму.</param>
    /// <returns>Сумма последних двух чисел в последовательности Фибоначчи.</returns>
    private static int CalculateFibonacci(int k)
    {
        // Если номер меньше или равен 1, возвращаем само число, так как это будет одно из двух последних чисел в последовательности.
        if (k <= 1)
            return k;

        // Инициализация предыдущего и текущего чисел Фибоначчи.
        int prev = 1;
        int curr = 1;

        // Проходим по последовательности, начиная с третьего числа (индекс 2) до заданного номера k.
        for (int i = 2; i < k; i++)
        {
            // Вычисляем следующее число Фибоначчи путем сложения предыдущего и текущего чисел.
            int next = prev + curr;
            // Обновляем значения предыдущего и текущего чисел для следующей итерации.
            prev = curr;
            curr = next;
        }

        // Возвращаем сумму последних двух чисел Фибоначчи.
        return prev + curr;
    }
    public static int CalculateTotalBacteria(int n, int k)
    {
        return CalculateFibonacci(k) * n;
    }
    static void Main(string[] args)
    {
        int n = 2; // Изначальное количество бактерий
        int k = 8; // Количество тактов времени

        int totalBacteria = BacteriaSimulation.CalculateTotalBacteria(n, k);
        Console.WriteLine($"Всего бактерий через {k} тактов времени: {totalBacteria} бактерий");
    }
}
