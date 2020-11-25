using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;

    delegate void PrintT();
    delegate double Del(double x);
    

class Program
{
    public static Del deleg;
    
    static void Main()
    {
        /*Console.WriteLine("Таблица функции MyFunc:"); // task 1
        Table(new Fun(MyFunc), -2 , 2 , 2);                 
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        Table(MyFunc, -2 , 2 , 2);*/
        
        
        /*Console.WriteLine("Выберите функцию от 1 до 3"); // task 2
        int a = Convert.ToInt32(Console.ReadLine());

        switch (a)
        {
            default:
                Console.WriteLine("Ошибка");
                break;
            case 1:
                deleg += Calc;
                break;
            case 2:
                deleg += Calc2;
                break;
            case 3:
                deleg += Calc3;
                break;
        }

        SaveFunc("data.bin", Calc , -100, 100, 0.5);
        Console.WriteLine(Load("data.bin"));
        Console.ReadKey();*/
        
        // а как тут ? csv нету ( , задания странные какие-то 
    }
    public static double Calc(double x)
    {
        return x * x - 50 * x + 10;
    }
    public static double Calc2(double x)
    {
        return x * x - 50 * x + 100;
    }
    public static double Calc3(double x)
    {
        return x * x - 50 * x + 1000;
    }

    static void Collection()
    {
        int bakalavr = 0;
        int magistr = 0;
        int numOfBachelors = 0;
        int numOfMasters = 0;
        // Создадим необобщенный список
        ArrayList list = new ArrayList();
        // Запомним время в начале обработки данных
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("..\\..\\students_1.csv");
        while(!sr.EndOfStream)
        {
            try {
                string[] s = sr.ReadLine().Split(';');
                // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                list.Add(s[1]+" "+s[0]);// Добавляем склееные имя и фамилию
                if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
            }
            catch
            {
            }
        }
        sr.Close();
        list.Sort();            
        Console.WriteLine("Всего студентов:{0}", list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        foreach (var v in list) Console.WriteLine(v);
        // Вычислим время обработки данных
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }


    public static void SaveFunc(string fileName, Del f , double a,double b,double h)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x<=b)
        {
            bw.Write(f(x));
            x += h;// x=x+h;
        }
        bw.Close();
        fs.Close();
    }
    
    public static double Load(string fileName)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        double min = double.MaxValue;
        double d;
        for(int i=0;i<fs.Length/sizeof(double);i++)
        {
            // Считываем значение и переходим к следующему
            d = bw.ReadDouble();
            if (d < min) min = d;
        }
        bw.Close();
        fs.Close();
        return min;
    }
    
    public delegate double Fun(double x ,double a);
    public static void Table(Fun f, double x , double a, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,2:0.000} |", x, f(a,x));
            //Console.WriteLine($"| {x:0.000} | {f(x):0.000} |");
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    public static double MyFunc(double x , double a)
    {
        return a * Math.Sin(x);
    }

}
