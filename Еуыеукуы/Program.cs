class Program 
{
    static void Main()
    {
        Console.WriteLine("dsdsds");
        static string Print1()
        {
            Console.WriteLine("method1 works");
            return "method1";
        }
        static string Print2()
        {
            Console.WriteLine("method2 works");
            return "method2";
        }
        //Func представляет делегат, который принимает один или более параметров и возвращает результат.
        (string name, Func<string> pinters)[] values =
        {
            ("1",()=> Print1()),
            ("2",Print2),
        };

        foreach (var value in values)
        {
            Console.WriteLine("Love" + value.name);
            string answ = value.pinters();
            Console.WriteLine(answ);
        }
        //foreach (var (title, generator) in scenarios)
        //{
        //    Console.WriteLine($"     {title}:");
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    int[] array = generator();
        //    Sorts.ShakerSortAlgorithm(array, out comparisons, out swaps);
        //    stopwatch.Stop();
        //    Console.WriteLine($"Время выполнения: {stopwatch.ElapsedTicks} тиков, Число сравнений: {comparisons}, Число обменов: {swaps}");
        //    Console.WriteLine("Отсортированный массив:");
        //    Sorts.PrintArray(array);
        //}
    }
}
