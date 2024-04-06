using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ArrayGenerator
    {
        // Метод для создания массива случайных чисел
        public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
            return array;
        }

        // Метод для создания массива случайных чисел с K% повторениями одного элемента
        public static int[] GenerateArrayWithRepeats(int length, int minValue, int maxValue, double k)
        {
            Random rand = new Random();
            int[] array = new int[length];
            int repeatValue = rand.Next(minValue, maxValue + 1);
            int repeatsCount = (int)(length * k / 100);

            for (int i = 0; i < length; i++)
            {
                if (i < repeatsCount)
                    array[i] = repeatValue;
                else
                    array[i] = rand.Next(minValue, maxValue + 1);
            }
            return array;
        }

        // Метод для создания массива из L отсортированных подмассивов
        public static int[] GenerateSortedSubarraysArray(int length, int subarrayLength)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i += subarrayLength)
            {
                int[] subarray = GenerateRandomArray(subarrayLength, 0, 100); // 0 и 100 - примерные границы для отсортированных подмассивов
                Array.Sort(subarray);
                Array.Copy(subarray, 0, array, i, subarray.Length);
            }
            return array;
        }

        // Метод для создания отсортированного массива, в котором M% чисел заменены на случайные
        public static int[] GeneratePartiallyRandomSortedArray(int length, int minValue, int maxValue, double m)
        {
            Random rand = new Random();
            int[] array = new int[length];
            int randomCount = (int)(length * m / 100);

            for (int i = 0; i < length; i++)
            {
                if (i < randomCount)
                    array[i] = rand.Next(minValue, maxValue + 1);
                else
                    array[i] = minValue + i; // Создаем почти отсортированный массив
            }

            // Перемешиваем случайные элементы
            for (int i = length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return array;
        }

    }
}
