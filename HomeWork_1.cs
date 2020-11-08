using System;

class Program
{
    // Соломахин Вячеслав
    static void Main() // 1. программа "Анкета"
    {

        string Name;
        string SecondName;
        int Age;
        float Height;
        float Weight;

        float BMI;

        Console.WriteLine("Write your name");
        Name = Console.ReadLine();

        Console.WriteLine("Write your second name");
        SecondName = Console.ReadLine();

        Console.WriteLine("Write your age");
        Age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Write your height (cm)");
        Height = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine("Write your weight (kg)");
        Weight = Convert.ToSingle(Console.ReadLine());

        // а) Скелирование
        Console.WriteLine(Name + " | " + SecondName + " | " + Age + " | " + Height + " | " + Weight);

        // б) Форматированный вывод
        Console.WriteLine(string.Format("{0} | {1} | {2} | {3} | {4}", Name, SecondName, Age, Height, Weight));

        // в) Вывод со знаком $ ( "\n" - для удобства )
        Console.WriteLine($"\nName : {Name} \nSecondName : {SecondName} \nAge : {Age} \nHeight : {Height} \nWeight : {Weight}");

        // 2. Индекс массы тела 

        float HeightM = Height / 100f; // перевод в метры
        BMI = Weight / (HeightM * HeightM);

        Console.WriteLine($"\nYour Body Mass Index is {BMI: 0.00} \nNormal index is 18 - 25");

        WriteMessageInCenter($"{Name} | {SecondName} | {Age} | {Height} | {Weight}", 0, 0);

        Console.WriteLine($"Press any button to exit");
        Console.ReadLine();
    }

    // 3.  а) , б)
    static void Distance()
    {

        float x1, x2, y1, y2;

        Console.WriteLine($"Write x1");
        x1 = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine($"Write y1");
        y1 = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine($"Write x2");
        x2 = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine($"Write y2");
        y2 = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine($"Distance is : {Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)): 0.0}");
        Console.ReadLine();
    }

    static void Exchanger() // 4. a)
    {
        int FirstVar = 1;
        int SecondVar = 6;
        int ExchangerVar;

        ExchangerVar = FirstVar;
        FirstVar = SecondVar;
        SecondVar = ExchangerVar;
    }

    static void WriteMessageInCenter(string msg, int xOffset, int yOffset) // 5?
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 + xOffset - msg.Length / 2, Console.WindowHeight / 2 + yOffset);
        Console.WriteLine($"{msg}");
    }
}