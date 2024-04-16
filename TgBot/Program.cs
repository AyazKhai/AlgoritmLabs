using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Task_5._8_Bacterias;

public class Program
{

    // Метод для вычисления времени сортировки методом вставок для n элементов
    static double InsertionSortTime(int n)
    {
        // Формула для времени сортировки методом вставок: 8 * n^2
        return 8 * n * n;
    }

    // Метод для вычисления времени сортировки методом слияния для n элементов
    static double MergeSortTime(int n)
    {
        // Формула для времени сортировки методом слияния: 64 * n * log2(n)
        return 64 * n * Math.Log(n, 2);
    }

    static void Main(string[] args)
    {
        var botClient = new TelegramBotClient("6438897987:AAGaho7IoA3P3KDHoqgyBWVCV-nKuxo43gc");
        botClient.StartReceiving(Update, Error);


        Console.ReadKey();
    }

    private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Error: {exception.Message}");
        return Task.CompletedTask;
    }

    public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;
        if (message != null)
        {
            if (message.Text.ToLower() == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"<b>Приветствую вас!!!</b> ", parseMode: ParseMode.Html);
                return;
            }
            if (message.Text.ToLower() == "/task1")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"<b>Задание 1.1 </b> \tПредположим, на одной и той же машине проводится сравнительный анализ реализаций двух алгоритмов сортировки, работающих по методу вставок и по методу слияния. Для сортировки n элементов методом вставок необходимо 8n2 шагов, а для сортировки методом слияния – 64n lg n шагов. При каком значении n время сортировки методом вставок превысит время сортировки методом слияния?  ", parseMode: ParseMode.Html);
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Введите количество элементов, которые требуется отсортировать", parseMode: ParseMode.Html);

                int n = 0;
                bool isAnswered = false;
                while (!isAnswered)
                {
                    // Ожидание ответа от пользователя
                    Update[] updates = await botClient.GetUpdatesAsync(offset: update.Id + 1, cancellationToken: cancellationToken, timeout: 60);
                    foreach (var u in updates)
                    {
                        if (u.Message?.Text != null && int.TryParse(u.Message.Text, out n))
                        {
                            isAnswered = true;
                            break;
                        }
                    }
                }

                if (n > 0)
                {
                    while (InsertionSortTime(n) <= MergeSortTime(n))
                    {
                        n++;
                    }
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Время сортировки методом вставок превысит время сортировки методом слияния при n = {n}", parseMode: ParseMode.Html);

                }
                else 
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Ошибка ввода, попробуйте заново", parseMode: ParseMode.Html);
                }
                // Выполнение алгоритма

                return;
            }
            if (message.Text.ToLower() == "/task2") 
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"<b>Задание 5.8</b>\tИмеется n бактерий красного цвета. Через 1 такт времени красная бактерия меняется на зеленую, затем через 1 такт времени делится на красную и зеленую. Определить, сколько будет всех бактерий через k тактов времени? ", parseMode: ParseMode.Html);
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Введите количество n красных бактерий", parseMode: ParseMode.Html);

                int n = 0;
                bool isAnswered = false;
                while (!isAnswered)
                {
                    // Ожидание ответа от пользователя
                    Update[] updates = await botClient.GetUpdatesAsync(offset: update.Id + 1, cancellationToken: cancellationToken, timeout: 60);
                    foreach (var u in updates)
                    {
                        if (u.Message?.Text != null && int.TryParse(u.Message.Text, out n))
                        {
                            isAnswered = true;
                            break;
                        }
                    }
                }

                await botClient.SendTextMessageAsync(message.Chat.Id, $"Введите количество k ктактов времени", parseMode: ParseMode.Html);

                int k = 0;
                isAnswered = false;
                while (!isAnswered)
                {
                    // Ожидание ответа от пользователя
                    Update[] updates = await botClient.GetUpdatesAsync(offset: update.Id + 2, cancellationToken: cancellationToken, timeout: 60);
                    foreach (var u in updates)
                    {
                        if (u.Message?.Text != null && int.TryParse(u.Message.Text, out k)) // Здесь исправлено на переменную k
                        {
                            isAnswered = true;
                            break;
                        }
                    }
                }
                if (n > 0 && k > 0)
                {
                    int totalBacteria = BacteriaSimulation.CalculateTotalBacteria(n, k);
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Ввсего бактерий через {k} тактов времени: {totalBacteria} бактерий", parseMode: ParseMode.Html);
                }
                else 
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Ошибка ввода, попробуйте заново", parseMode: ParseMode.Html);
                }
                // Выполнение алгоритма
                
                return;
            }

        }
    }
}