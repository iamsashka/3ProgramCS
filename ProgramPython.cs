using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Игра 'Угадай число'");
            Console.WriteLine("2. Таблица умножения");
            Console.WriteLine("3. Вывод делителей числа");
            Console.WriteLine("4. Выход");

            int choice = GetIntegerInput("Выберите программу (1/2/3/4): ");

            switch (choice)
            {
                case 1:
                    Угадайчисло();
                    break;
                case 2:
                    Таблицаумножения();
                    break;
                case 3:
                    Выводделителейчисла();
                    break;
                case 4:
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1, 2, 3 или 4.");
                    break;
            }
        }
    }

    static int GetIntegerInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Пожалуйста, введите целое число.");
        }
    }

    static void Угадайчисло()
    {
        Random random = new Random();
        int randomNumber = random.Next(101);
        int attempts = 0;

        while (true)
        {
            int userGuess = GetIntegerInput("Угадайте число от 0 до 100: ");
            attempts++;

            if (userGuess < randomNumber)
                Console.WriteLine("Загаданное число больше, думай.");
            else if (userGuess > randomNumber)
                Console.WriteLine("Загаданное число меньше. думай.");
            else
            {
                Console.WriteLine($"Поздравляем! Вы наконец-то угадали число {randomNumber}, хотя вам потребовалось {attempts} попыток. Не расстраивайтесь, в следующий раз получится с первой попытки, наверное :)");
                return;
            }
        }
    }

    static void Таблицаумножения()
    {
        int[,] table = new int[10, 10]; // Объявляем двумерный массив (матрицу) для хранения таблицы умножения 10x10.
        // Заполнение матрицы значениями таблицы умножения с использованием вложенных циклов.
        for (int i = 0; i < 10; i++) // Внешний цикл для строк таблицы.
        {
            for (int j = 0; j < 10; j++) // Внутренний цикл для столбцов таблицы.
            {
                table[i, j] = (i + 1) * (j + 1); // Вычисляем и записываем результат умножения в ячейку матрицы.
            }
        }
        // Вывод таблицы умножения в виде таблицы.
        Console.WriteLine("Таблица умножения 10x10:");
        for (int i = 0; i < 10; i++) // Внешний цикл для строк таблицы.
        {
            for (int j = 0; j < 10; j++) // Внутренний цикл для столбцов таблицы.
            {
                Console.Write($"{table[i, j],4}");  // Выводим значение из ячейки матрицы с выравниванием в 4 символа.
            }
            Console.WriteLine(); // Переходим на новую строку после каждой строки таблицы.
        }
    }

    static void Выводделителейчисла()
    {
        int number = GetIntegerInput("Введите число: ");
        List<int> divisors = new List<int>();

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                divisors.Add(i);
        }

        Console.WriteLine($"Делители числа {number}: {string.Join(", ", divisors)}");
    }
}