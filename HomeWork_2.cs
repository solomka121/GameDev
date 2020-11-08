using System;

class Program
{
    static void Main()
    {
        /* Test test = new Test();
         test.AllExceptZero();*/

    }
    private void FindTheLowest(int a ,int b ,int c) //1 
    {
        int lower = a < b ? a : b;
        lower = lower < c ? lower : c;
        Console.WriteLine($"{lower} is the lowest");
        Console.ReadLine();
    }
    private int GetLenght(string message) //2
    {
        int MessageLenght = message.Length;
        return MessageLenght;
    }
    private void AllExceptZero() //3
    {
        Console.WriteLine("Write any number \ntype zero if you want to stop");
        
        float NumbersSumm = 0;
        bool IsStopped = false;

        while (!IsStopped)
        {
            float CurNumber = Convert.ToSingle(Console.ReadLine());
            if (CurNumber % 2 != 0 && CurNumber > 0)
            {
                NumbersSumm += CurNumber;
            }
            else if (CurNumber == 0)
            {
                IsStopped = true;
            }
        }
        Console.WriteLine(NumbersSumm);
        Console.ReadLine();
    }
    private bool CheckLogAndPas() //4
    {
        int MaxAttempts = 3;
        int CurrentAttempt = 0;
        string TrueLogin = "root";
        string TruePassword = "GeekBrains";
        do
        {
            CurrentAttempt++;

            Console.WriteLine("Write Login");
            string Login = Console.ReadLine();

            Console.WriteLine("Write Password");
            string Password = Console.ReadLine();

            if (Login == TrueLogin && Password == TruePassword)
            {
                Console.Clear();
                Console.WriteLine("Correct , press any button to continue");
                Console.ReadLine();
                return true;
            }
            else if(Login == TrueLogin)
            {
                Console.WriteLine("Incorrect Password");
                Console.WriteLine($"{MaxAttempts - CurrentAttempt} attempts  left , try again");
            }
            else
            {
                Console.WriteLine("Incorrect Data");
                Console.WriteLine($"{MaxAttempts - CurrentAttempt} attempts  left , try again");
            }
        }
        while(CurrentAttempt < MaxAttempts);
        Console.WriteLine("Out Of Attempts");
        Console.Clear();
        return false;
    }
}
