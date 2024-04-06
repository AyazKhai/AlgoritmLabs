using Lab2;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int length = 32; //длина массива
        int minValue = 0; // Минимальное значение элементов
        int maxValue = 100; // Максимальное значение элементов
        double k = 25; // Процент повторений в массиве с повторениями
        int subarrayLength = 12; // Длина подмассивов в массиве из отсортированных подмассивов должна быть меньше половины длины
        double m = 5; // Процент случайных элементов в частично отсортированном массиве
        long comparisons, swaps;
        int[] originalArray = ArrayGenerator.GenerateRandomArray(length, minValue, maxValue);

        // Создание копий массива с таким же размером и содержимым
        int[] arrayWithRep = ArrayGenerator.ModifyArrayWithRepeats((int[])originalArray.Clone(), minValue, maxValue, k);
        int[] arrayWirhSortSub = ArrayGenerator.ModifyArrayWithSortedSubarrays((int[])originalArray.Clone(), subarrayLength);
        int[] arrayPartRandSort = ArrayGenerator.ModifyArrayWithPartiallyRandomSorted((int[])originalArray.Clone(), minValue, maxValue, m);



        (string title, int[] arr)[] scenarios = {
            ("Массив случайных чисел",originalArray),
            ("Массив случайных чисел с повторениями K%", arrayWithRep),
            ("Массив из отсортированных L подмассивов",arrayWirhSortSub),
            ("Отсортированный массив с случайными элементами M%", arrayPartRandSort),
        };

        Console.WriteLine("Шейкерная сортировка");
        foreach (var (title, arr) in scenarios)
        {
            Console.WriteLine($"     {title}");
            int[] array = (int[])arr.Clone();
            Console.Write("Массив до сортировки: ");
            ArrayGenerator.PrintArray(array);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Sorts.ShakerSortAlgorithm(array, out comparisons, out swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
            Console.Write("Отсортированный массив: ");
            ArrayGenerator.PrintArray(array);
            Console.WriteLine();
        }

        Console.WriteLine("Битонная сортировка");
        foreach (var (title, arr) in scenarios)
        {
            Console.WriteLine($"     {title}");
            int[] array = (int[])arr.Clone();
            Console.Write("Массив до сортировки: ");
            ArrayGenerator.PrintArray(array);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Sorts.BitonicSort(array, array.Length, true, out comparisons, out swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
            Console.Write("Отсортированный массив: ");
            ArrayGenerator.PrintArray(array);
            Console.WriteLine();
        }
        Console.WriteLine("Пирамидальная сортировка");
        foreach (var (title, arr) in scenarios)
        {
            Console.WriteLine($"     {title}");
            int[] array = (int[])arr.Clone();
            Console.Write("Массив до сортировки: ");
            ArrayGenerator.PrintArray(array);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Sorts.HeapSortAlgorithm(array, out comparisons, out swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
            Console.Write("Отсортированный массив: ");
            ArrayGenerator.PrintArray(array);
            Console.WriteLine();
        }
        /*
        (string title, Func<int[]> generator)[] scenarios = {
            ("Массив случайных чисел", () => ArrayGenerator.GenerateRandomArray(length, minValue, maxValue)),
            ("Массив случайных чисел с повторениями K%", () => ArrayGenerator.GenerateArrayWithRepeats(length, minValue, maxValue, k)),
            ("Массив из отсортированных L подмассивов", () => ArrayGenerator.GenerateSortedSubarraysArray(length, subarrayLength)),
            ("Отсортированный массив с случайными элементами M%", () => ArrayGenerator.GeneratePartiallyRandomSortedArray(length, minValue, maxValue, m)),
        };
        Console.WriteLine("Шейкерная сортировка");
        foreach (var (title, generator) in scenarios)
        {
            Console.WriteLine($"     {title}");
            int[] array = generator();
            Console.Write("Массив до сортировки: ");
            ArrayGenerator.PrintArray(array);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Sorts.ShakerSortAlgorithm(array, out comparisons, out swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
            Console.Write("Отсортированный массив: ");
            ArrayGenerator.PrintArray(array);
            Console.WriteLine();
        }
        */
    }
}