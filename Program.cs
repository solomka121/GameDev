using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

struct Account
{
    string login;
    string password;

    public Account(string login , string password)
    {
        this.login = login;
        this.password = password;
    }

    public void PrintData()
    {
        Console.WriteLine($"Login : {login}");
        Console.WriteLine($"Password : {password}");
    }
    
    public bool CheckData(Account account)
    {
        if (account.login == login && account.password == password)
        {
            return true;
        }
        return false;
    }
}

class SignInService
{
    View view = new View();
    Account[] accounts = new Account[10];

    public void ReadDataFile()
    {
        using (StreamReader sr = new StreamReader("Resources/Data.txt"))
        {
            string line;
            for (int i = 0; (line = sr.ReadLine()) != null ; i++)
            {
                string[] cred = line.Split(' ');
                accounts[i] = new Account(cred[0] , cred[1]);
            }
            sr.Close();
        }

        for (int i = 0; i < accounts.Length; i++)
        {
            Account acc = accounts[i];
            acc.PrintData();
        }
    }
    
    public void SingIn()
    {
        int maxSingInAttempts = 3;
        bool correct = false;
        ReadDataFile();

        for (int currentSingInAttempt = 1 ; currentSingInAttempt <= maxSingInAttempts ; currentSingInAttempt++)
        {
            Console.WriteLine("Write Login");
            string log = Console.ReadLine();
            Console.WriteLine("Write Password");
            string pass = Console.ReadLine();
            
            Account acc = new Account(log , pass);
            for (int i = 0; i < accounts.Length && correct == false; i++)
            {
                correct = acc.CheckData(accounts[i]);
            }

            if (correct)
            {
                Console.WriteLine("Welcome");
                return;
            }
            else
            {
                Console.WriteLine("Incorrect Login or Password");
                Console.WriteLine($"{maxSingInAttempts - currentSingInAttempt} attempts left");
            }
        }
    }
    
}

class Program
{
    static void Main()
    {
        /*View view = new View();
        SignInService signInService = new SignInService();
        
        signInService.SingIn();*/

        /*ExampleArray Ex = new ExampleArray();
        int[] TestArr = Ex.RandomArray(8);
        TestArr = Ex.Inverse(TestArr);*/

        ArrayTwo arrayTwo = new ArrayTwo( 6 , 6 , 0 , 10);
        //arrayTwo.GetSudokuField(); // doesnt work
        
        arrayTwo.Print();
        Console.WriteLine(arrayTwo.GetSum());
        Console.WriteLine(arrayTwo.GetMax());
        //arrayTwo.PrintInFile();
        
        TwentyMas();
        
        Console.ReadLine();
        
    }

    public static void TwentyMas()
    {
        int pairs = 0;
        int notPairs = 0;
        string currentPair;
        int[] numbers = new int[19];
        Random randomNumer = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = randomNumer.Next(-10 , 10);
            Console.Write(numbers[i] + "  "); 
        }
        Console.WriteLine();
        for (int i = 0; i < numbers.Length; )
        {
            int firstNum = numbers[i];
            int secondNumber = 0;
            i++;
            if (i < numbers.Length) 
            {
                secondNumber = numbers[i];
            }

            if (firstNum % 3 == 0 || secondNumber % 3 == 0)
            {
                pairs++;
                Console.WriteLine($"Pair : {firstNum} , { secondNumber} - is Pair");
            }
            else
            {
                Console.WriteLine($"Pair : {firstNum} , { secondNumber} - No");
                notPairs++;
            }

        }

        Console.WriteLine(); // space
        Console.WriteLine($"Pairs : {pairs}");
        Console.WriteLine($"Not Pairs : {notPairs}");
        Console.ReadLine();
    }
}

class ArrayTwo
{
    int[,] twoArray;

    public ArrayTwo()
    {

    } //standard constructor
    
    public ArrayTwo(int height , int lenght , int min , int max)
    {
        Random rnd = new Random();
        twoArray = new int[height, lenght];
        for (int i = 0; i < twoArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoArray.GetLength(1); j++)
            {
                twoArray[i, j] = rnd.Next(min, max);
            }
        }
    }

    public void GetSudokuField(int difficulty = 0)
    {
        int maxStartNumbers = 0; // max start numbers
        Random rnd = new Random();
        
        switch (difficulty)
        {
            default:
                Console.WriteLine("Error");
                break;
            case 0:
                maxStartNumbers = 81; // full field
                break;
            case 1:
                maxStartNumbers = 40;
                break;
            case 2:
                maxStartNumbers = 30;
                break;
        }

        twoArray = new int[9 , 9];
        
        for (int i = 0; i < twoArray.GetLength(0); i++) // put 0 in each cell
        {
            for (int j = 0; j < twoArray.GetLength(1); j++)
            {
                twoArray[i, j] = 0;
            }
        }

        for (int currStartNumbers = 0; currStartNumbers < maxStartNumbers; currStartNumbers++) // put numbers
        {
            int randomIndex;
            int randomRow;
            int randomNumber;
            do
            {
                randomIndex = rnd.Next(0 , 9);
                randomRow = rnd.Next(0 , 9);
            } while (twoArray[randomRow , randomIndex] != 0);
            
            do
            {
                randomNumber = rnd.Next(1, 10);
            } while (!CheckXY(randomNumber , randomRow , randomIndex));

            twoArray[randomRow , randomIndex] = randomNumber;
        }

        bool CheckXY(int number , int row , int index)
        {
            for (int i = 0; i < twoArray.GetLength(1); i++) // check x
            {
                if (twoArray[row , i] == number)
                {
                    return false;
                }
            }
            
            // works only with 1 check , horizontal or vertical *
            
            /*for (int i = 0; i < twoArray.GetLength(0); i++) // check y
            {
                if (twoArray[i , index] == number)
                {
                    return false;
                }
            }*/
            
            return true;
        }

    }

    public int GetSum()
    {
        int sum = 0;
        for (int i = 0; i < twoArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoArray.GetLength(1); j++)
            {
                sum += twoArray[i, j];
            }
        }

        return sum;
    }

    public int GetMax()
    {
        int max = twoArray[0, 0];
        for (int i = 0; i < twoArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoArray.GetLength(1); j++)
            {
                if (max < twoArray[i,j])
                {
                    max = twoArray[i,j];
                }
            }
        }
        return max;
    }

    public void PrintInFile()
    {
        using (StreamWriter sr = new StreamWriter("Resources/TwoArray.txt"))
        {
            for (int i = 0; i < twoArray.GetLength(0); i++)
            {
                sr.WriteLine();
                for (int j = 0; j < twoArray.GetLength(1); j++)
                {
                    sr.Write(twoArray[i , j] + "  ");
                }
            }
            sr.Close();
        }
    }

    public void Print()
    {
        for (int i = 0; i < twoArray.GetLength(0); i++)
        {
            Console.WriteLine();
            for (int j = 0; j < twoArray.GetLength(1); j++)
            {
                Console.Write(twoArray[i , j] + "  ");
            }
        }
        Console.WriteLine();
    }
}

public class ExampleArray
{
    private View _view = new View();

    public int[] RandomArray(int n)
    {
        int[] arr = new int[n];
        Random randomNumber = new Random();

        for (int i = 0; i < n; i++) arr[i] = randomNumber.Next(0 , 20);

        _view.PrintArray(arr);
        return arr;
    }

    public int[] StepArray(int lenght , int startNum , int step)
    {
        int[] arr = new int[lenght];
        arr[0] = startNum;
        for (int i = 1; i < lenght; i++)
        {
            arr[i] = startNum + step * i;
        }
        _view.PrintArray(arr);
        return arr;
    }

    public int[] InputArray()
    {
        _view.Print("Введите размер массива");
        int size = _view.GetInt();
        int[] arr = new int[size];

        _view.Print("Вводите данные массива");
        for (int i = 0; i < size; i++)
        {
            arr[i] = _view.GetInt();
        }

        _view.PrintArray(arr);
        return arr;
    }
    
    public int[] Inverse(int[] arr)
    {
        for (int i = 0 ; i < arr.Length ; i++)
        {
            arr[i] = arr[i] * -1;
        }
        _view.PrintArray(arr);
        return arr;
    }

    public int SumArray(int[] valueArr)
    {
        int result = 0;

        for (int i = 0; i < valueArr.Length; i++)
        {
            result += valueArr[i];
        }

        _view.Print(result);

        return result;
    }

   

    
}
public class View
{
    public void Print(object value, bool isNewLine = true)
    {
        if (isNewLine)
        {
            Console.WriteLine(value);
        }
        else
        {
            Console.Write(value);
        }

    }

    public int GetInt()
    {
        int result = 0;
        do
        {
            Print("Введите число");
        } while (!Int32.TryParse(GetString(), out result));
        return result;
    }

    public double GetDouble()
    {
        double result = 0.0d;
        do
        {
            Print("Введите число");
        } while (!Double.TryParse(GetString().Replace(".", ","), out result));
        return result;
    }

    public string GetString()
    {
        return Console.ReadLine();
    }

    public void Pause()
    {
        Console.ReadKey();
    }

    public void PrintArray(int[] arr)
    {
        for (int index = 0; index < arr.Length; index++)
        {
            var i = arr[index];
            Print($"{i}");
        }
    }

    public void PrintMatrix(int[,] array)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Print($" [{i},{j}] {array[i, j]}", false);
            }

            Print(" ");
        }
    }
}