/*5.8	Имеется n бактерий красного цвета. 
 * Через 1 такт времени красная бактерия меняется на зеленую, затем через 1 такт времени делится на красную и зеленую. 
 * Определить, сколько будет всех бактерий через k тактов времени? 
 */

using Task_5._8_Bacterias;

class Program
{
    static void Main(string[] args)
    {
        int n = 2; // Изначальное количество бактерий
        int k = 8; // Количество тактов времени

        int totalBacteria = BacteriaSimulation.CalculateTotalBacteria(n, k);
        Console.WriteLine($"Всего бактерий через {k} тактов времени: {totalBacteria} бактерий");
    }
}
