using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Sorts
    {
        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="comparisons">счетчик сравнения</param>
        /// <param name="swaps">счетчик перемещений</param>
        /// <param name="swaps"></param>
        public static void ShakerSortAlgorithm(int[] array, out long comparisons, out long swaps)
        {
            comparisons = 0;
            swaps = 0;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = array.Length - 1; i > 0; i--)
                {
                    comparisons++; // увеличиваем счетчик сравнений
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        swapped = true;
                        swaps++; // увеличиваем счетчик обменов
                    }
                }

                if (!swapped)
                    break;

                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    comparisons++; // увеличиваем счетчик сравнений
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        swapped = true;
                        swaps++; // увеличиваем счетчик обменов
                    }
                }
            } while (swapped);
        }

        /// <summary>
        /// Битонная сортировка
        /// </summary>
        /// <param name="arr">Изначальный массив</param>
        /// <param name="cnt">Длина массива</param>
        /// <param name="order">по возрастанию(True), по убываванию(False)</param>
        /// <param name="comparisons">счетчик сравнения</param>
        /// <param name="swaps">счетчик перемещений</param>
        /// <exception cref="ArgumentException"></exception>
        public static void BitonicSort(int[] arr, int cnt, bool order, out long comparisons, out long swaps)
        {
            comparisons = 0;
            swaps = 0;
            // Проверяем, является ли cnt степенью двойки
            if ((cnt & (cnt - 1)) != 0)
            {
                throw new ArgumentException("Длина массива должна быть степенью двойки");
            }

            BitonicSortRecursive(arr, 0, cnt, order, ref comparisons, ref swaps);
        }
        private static void BitonicMerge(int[] arr, int low, int cnt, bool order, ref long comparisons, ref long swaps)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;

                for (int i = low; i < low + k; i++)
                {
                    int j = i + k;

                    // Увеличиваем счетчик операций сравнения
                    comparisons++;

                    // Выбираем правильный порядок для сравнения
                    bool needSwap = order ? (arr[i] > arr[j]) : (arr[i] < arr[j]);

                    if (needSwap)
                    {
                        swaps++; // Увеличиваем счетчик операций обмена
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                // Рекурсивно сливаем обе части массива
                BitonicMerge(arr, low, k, order, ref comparisons, ref swaps);
                BitonicMerge(arr, low + k, k, order, ref comparisons, ref swaps);
            }
        }

        private static void BitonicSortRecursive(int[] arr, int low, int cnt, bool order, ref long comparisons, ref long swaps)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;

                BitonicSortRecursive(arr, low, k, true, ref comparisons, ref swaps);
                BitonicSortRecursive(arr, low + k, k, false, ref comparisons, ref swaps);

                BitonicMerge(arr, low, cnt, order, ref comparisons, ref swaps);
            }
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// </summary>
        /// <param name="array">Изначальный массив</param>
        /// <param name="comparisons">счетчик сравнения</param>
        /// <param name="swaps">счетчик перемещений</param>
        public static void HeapSortAlgorithm(int[] array, out long comparisons, out long swaps)
        {
            comparisons = 0; // Обнуляем счетчик операций сравнения
            swaps = 0; // Обнуляем счетчик операций обмена

            int n = array.Length;

            // Построение кучи (heapify)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i, ref comparisons, ref swaps);
            }

            // Последовательно извлекаем элементы из кучи
            for (int i = n - 1; i > 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Вызываем процедуру heapify на уменьшенной куче
                Heapify(array, i, 0, ref comparisons, ref swaps);
            }
        }

        // Функция для поддержания свойства кучи в узле index в куче размером n
        private static void Heapify(int[] array, int n, int index, ref long comparisons, ref long swaps)
        {
            int largest = index; // Инициализируем наибольший элемент как корень
            int left = 2 * index + 1; // Левый потомок узла index
            int right = 2 * index + 2; // Правый потомок узла index

            // Увеличиваем счетчик операций сравнения
            comparisons++;

            // Если левый потомок больше родителя, то присваиваем largest ему
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // Увеличиваем счетчик операций сравнения
            comparisons++;

            // Если правый потомок больше родителя, то присваиваем largest ему
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // Увеличиваем счетчик операций сравнения
            comparisons++;

            // Если largest не равен index, то делаем обмен элементов и вызываем heapify рекурсивно
            if (largest != index)
            {
                // Увеличиваем счетчик операций обмена
                swaps++;

                int temp = array[index];
                array[index] = array[largest];
                array[largest] = temp;

                // Вызываем heapify рекурсивно для поддержания свойства кучи в largest
                Heapify(array, n, largest, ref comparisons, ref swaps);
            }
        }
    }
}
