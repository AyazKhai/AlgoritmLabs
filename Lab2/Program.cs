using Lab2;
using System.Diagnostics;

class ShakerSort
{
    // Метод для выполнения шейкерной сортировки
    static void ShakerSortAlgorithm(int[] array, out long comparisons, out long swaps)
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

    // Метод для вывода массива на экран
    static void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int length = 24; // Примерная длина массива
        int minValue = 0; // Минимальное значение элементов
        int maxValue = 100; // Максимальное значение элементов
        double k = 25; // Процент повторений в массиве с повторениями
        int subarrayLength = 12; // Длина подмассивов в массиве из отсортированных подмассивов
        double m = 5; // Процент случайных элементов в частично отсортированном массиве
        long comparisons, swaps;

        ///////////////////////////////////////////
        Console.WriteLine("     Массив случайных чисел:");
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        // Выполняем сортировку и получаем число сравнений и обменов
        int[] randomArray = ArrayGenerator.GenerateRandomArray(length, minValue, maxValue);
        ShakerSortAlgorithm(randomArray, out comparisons, out swaps);
        stopwatch1.Stop();

        Console.WriteLine($"Время выполнения: {stopwatch1.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
        Console.WriteLine("Отсортированный массив:");
        PrintArray(randomArray);
        //////////////////////////////////////////


        ///////////////////////////////////////////
        Console.WriteLine("     Массив случайных чисел с большим количеством повторений одного элемента (K%):");
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        // Выполняем сортировку и получаем число сравнений и обменов
        int[] arrayWithRepeats = ArrayGenerator.GenerateArrayWithRepeats(length, minValue, maxValue, k);
        ShakerSortAlgorithm(arrayWithRepeats, out comparisons, out swaps);

        stopwatch2.Stop();
        Console.WriteLine($"Время выполнения: {stopwatch2.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
        Console.WriteLine("Отсортированный массив:");
        PrintArray(arrayWithRepeats);
        //////////////////////////////////////////

        ///////////////////////////////////////////
        Console.WriteLine("     Массив из L отсортированных подмассивов");
        Stopwatch stopwatch3 = Stopwatch.StartNew();
        // Выполняем сортировку и получаем число сравнений и обменов
        int[] sortedSubarraysArray = ArrayGenerator.GenerateSortedSubarraysArray(length, subarrayLength);
        ShakerSortAlgorithm(sortedSubarraysArray, out comparisons, out swaps);

        stopwatch3.Stop();
        Console.WriteLine($"Время выполнения: {stopwatch3.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
        Console.WriteLine("Отсортированный массив:");
        PrintArray(sortedSubarraysArray);
        //////////////////////////////////////////

        ///////////////////////////////////////////
        Console.WriteLine("     Отсортированный массив, в котором M% чисел заменены на случайные.");
        Stopwatch stopwatch4 = Stopwatch.StartNew();
        // Выполняем сортировку и получаем число сравнений и обменов
        int[] partiallyRandomSortedArray = ArrayGenerator.GeneratePartiallyRandomSortedArray(length, minValue, maxValue, m);
        ShakerSortAlgorithm(partiallyRandomSortedArray, out comparisons, out swaps);

        stopwatch4.Stop();
        Console.WriteLine($"Время выполнения: {stopwatch4.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
        Console.WriteLine("Отсортированный массив:");
        PrintArray(partiallyRandomSortedArray);
        //////////////////////////////////////////

        Console.WriteLine("\nЧастично отсортированный массив:");
        

        //Console.WriteLine("Исходный массив:");
        //PrintArray(partiallyRandomSortedArray);

        //// Выполняем шейкерную сортировку
        //ShakerSortAlgorithm(array);

        //Console.WriteLine("Отсортированный массив:");
        //PrintArray(array);
    }
}