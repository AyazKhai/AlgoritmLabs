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
        
        // Метод для вывода массива на экран
        public static void PrintArray(int[] array)
        {
            int counter = 0;
            foreach (var element in array)
            {
                Console.Write(element + ", ");
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine(counter);
        }


        // Метод для изменения массива, чтобы он содержал K% повторений одного элемента
        public static int[] ModifyArrayWithRepeats(int[] array, int minValue, int maxValue, double k)
        {
            Random rand = new Random();
            int repeatValue = rand.Next(minValue, maxValue + 1);
            int repeatsCount = (int)(array.Length * k / 100);

            int[] modifiedArray = new int[array.Length];
            Array.Copy(array, modifiedArray, array.Length);

            for (int i = 0; i < modifiedArray.Length; i++)
            {
                if (i < repeatsCount)
                    modifiedArray[i] = repeatValue;
                else
                    modifiedArray[i] = rand.Next(minValue, maxValue + 1);
            }
            return modifiedArray;
        }

        // Метод для изменения массива, чтобы он содержал L отсортированных подмассивов
        public static int[] ModifyArrayWithSortedSubarrays(int[] array, int subarrayLength)
        {
            int[] modifiedArray = new int[array.Length];
            Array.Copy(array, modifiedArray, array.Length);

            Random rand = new Random();

            for (int i = 0; i < modifiedArray.Length; i += subarrayLength)
            {
                int subarrayEnd = Math.Min(i + subarrayLength, modifiedArray.Length); // Определяем конец подмассива

                int[] tempArray = new int[subarrayEnd - i];
                Array.Copy(modifiedArray, i, tempArray, 0, tempArray.Length);

                Array.Sort(tempArray);

                Array.Copy(tempArray, 0, modifiedArray, i, tempArray.Length);
            }
            return modifiedArray;
        }

        // Метод для изменения массива, чтобы он был почти отсортированным, с M% случайных элементов
        public static int[] ModifyArrayWithPartiallyRandomSorted(int[] array, int minValue, int maxValue, double m)
        {
            int[] modifiedArray = new int[array.Length];
            Array.Copy(array, modifiedArray, array.Length);

            Random rand = new Random();
            int randomCount = (int)(array.Length * m / 100);

            HashSet<int> randomIndices = new HashSet<int>();

            // Генерация случайных индексов для замены
            while (randomIndices.Count < randomCount)
            {
                int randomIndex = rand.Next(array.Length);
                if (!randomIndices.Contains(randomIndex))
                    randomIndices.Add(randomIndex);
            }

            // Замена выбранных элементов на случайные значения
            foreach (int index in randomIndices)
            {
                modifiedArray[index] = rand.Next(minValue, maxValue + 1);
            }

            // Сортировка оставшихся элементов
            Array.Sort(modifiedArray, randomCount, array.Length - randomCount);

            return modifiedArray;
        }
        /*
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

            // Генерируем случайные числа для всего массива
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(0, 101); // Генерируем случайное число в диапазоне от 0 до 100
            }

            // Разбиваем массив на подмассивы, сортируем их и размещаем в основном массиве
            for (int i = 0; i < length; i += subarrayLength)
            {
                int subarrayEnd = Math.Min(i + subarrayLength, length); // Определяем конец подмассива

                // Создаем временный массив для текущего подмассива
                int[] tempArray = new int[subarrayEnd - i];
                Array.Copy(array, i, tempArray, 0, tempArray.Length);

                // Сортируем подмассив
                Array.Sort(tempArray);

                // Копируем отсортированный подмассив в основной массив
                Array.Copy(tempArray, 0, array, i, tempArray.Length);
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
        */
    }
}
