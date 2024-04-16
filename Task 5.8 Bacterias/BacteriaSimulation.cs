using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._8_Bacterias
{
    public class BacteriaSimulation
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
            return CalculateFibonacci(k)*n;
        }
        

    }

}
