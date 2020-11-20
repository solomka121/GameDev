using System;

namespace HomeWork3
{
    class Complex
    {
        public double re;
        public double im;
        //  в C# в структурах могут храниться также действия над данными
        public Complex Plus(Complex x)
        {
            Complex y = new Complex();
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }
        public Complex Minus(Complex x)
        {
            Complex y = new Complex();
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public Complex Multi(Complex x)
        {
            Complex y = new Complex();
            y.re = re * x.re - im * x.im;
            y.im = re * x.im + im * x.re;
            return y;
        }
        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }
    class Drob
    {
        public int Numer;
        public int Denom;

        public void SetNumbers(int Num , int Den)
        {
            Numer = Num;
            Denom = Den;
        }

        public void Print()
        {
            string Line = "-";
            int BiggestNumber = Numer > Denom ? Numer.ToString().Length : Denom.ToString().Length;
            while (BiggestNumber > Line.Length) Line = Line + "-";

            Console.WriteLine($"Numerator   : {Numer}"); // spaces for same lenght
            Console.SetCursorPosition(14 , Console.CursorTop);
            Console.WriteLine(Line);
            Console.WriteLine($"Denominator : {Denom}");
        }
         
        public Drob Plus(Drob Second , bool ToShow = false)
        {
            Drob result = new Drob();

            if (ToShow)
            {
                Console.WriteLine($"Plusing {Numer}/{Denom} + {Second.Numer}/{Second.Denom} ...");
                Console.WriteLine();
            }

            if (Denom == Second.Denom)
            {
                result.Numer = Numer + Second.Numer;
                result.Denom = Denom;
            }
            else
            {
                //int DenomMax = Denom > Second.Denom ? Denom : Second.Denom;

                int LastDenom = Denom;
                Numer = Numer * Second.Denom;
                Denom = Denom * Second.Denom;

                Second.Numer = Second.Numer * LastDenom;

                result.Numer = Numer + Second.Numer;
                result.Denom = Denom;
            }

            return result;
        }

    }

    class Program
    {
        static void Main()
        {
            Random GetRandomNumber = new Random();
            
            int MinNumer = 2;
            int MaxNumer = 6;

            int MinDenom = 2;
            int MaxDenom = 8;

            Drob FirstDrob = new Drob();
            FirstDrob.SetNumbers(GetRandomNumber.Next(MinNumer , MaxNumer), GetRandomNumber.Next(MinDenom , MaxDenom));

            Drob SecondDrob = new Drob();
            SecondDrob.SetNumbers(GetRandomNumber.Next(MinNumer, MaxNumer), GetRandomNumber.Next(MinDenom, MaxDenom));

            Console.WriteLine($"First drob : {FirstDrob.Numer}/{FirstDrob.Denom}");
            Console.WriteLine($"Second drob : {SecondDrob.Numer}/{SecondDrob.Denom}");
            Console.WriteLine();

            Drob Result = FirstDrob.Plus(SecondDrob, true);
            Result.Print();

            Console.ReadLine();
        }

        private static void OddNumbers()
        {
            int Number;
            int Summ = 0;
            bool Exit = false;
            string AllNumbers = "Your odd numbers : ";
            Console.WriteLine("Write any full number , or 0 to stop");
            do
            {
                string Num = Console.ReadLine();
                bool Ok = int.TryParse(Num, out Number);
                if (Ok)
                {
                    if (Number % 2 != 0 && Number > 0)
                    {
                        Summ += Number;
                        AllNumbers = $"{AllNumbers} {Number} ,";
                    }
                    if (Number == 0)
                    {
                        Exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Type");
                }
            } while (!Exit);
            Console.WriteLine(AllNumbers);
            Console.WriteLine($"The summ of all odd numbers is : {Summ}");
            Console.ReadLine();
        }

        private static void Comp()
        {
            Complex complex1 = new Complex();
            complex1.re = 1;
            complex1.im = 1;

            Complex complex2 = new Complex();
            complex2.re = 2;
            complex2.im = 2;

            Complex result = complex1.Plus(complex2);
            Console.WriteLine(result.ToString());
            result = complex1.Minus(complex2);
            Console.WriteLine(result.ToString());
            result = complex1.Multi(complex2);
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }


}
