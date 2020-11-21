using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;

class Lesson5
{
    static void Main()
    {
        Console.WriteLine("Write login"); // Task 1
        string login = Console.ReadLine();
        Console.WriteLine(CheckLogin(login));
        
        Message msg = new Message(Console.ReadLine()); // Task 2 - a , b , v 
        msg.WordsNoMoreThan(3); 
        msg.DeleteIfLastSymbolIs('a');
        msg.PrintTheLongestWord();
        
        ExamResults();     // Task 3
        
        GameYesNo(); // Task 4   
        
    }

    private static void ExamResults() // 3
    {
        StreamReader sr = new StreamReader("PupilsData.txt");
        int n = int.Parse(sr.ReadLine());
        Pupil[] pupils = new Pupil[n];
        for (int i = 0; i < pupils.Length; i++)
        {
            string str = sr.ReadLine();
            //Console.WriteLine(str);
            string[] data = str.Split(' ');
            pupils[i].SetName(data[0] , data[1]);
            pupils[i].SetMarks(int.Parse(data[2]) , int.Parse(data[3]) , int.Parse(data[4]));

        }

        int min = 4; // if all average marks 5 there are no bad marks

        for (int i = 0; i < pupils.Length; i++) // searching for min average mark
        {
            if (pupils[i].GetAverageMark() < min)
            {
                min = pupils[i].GetAverageMark();

            }
        }

        List<Pupil> worstPupils = new List<Pupil>();
        for (int i = 0; i < pupils.Length; i++)
        {
            if (pupils[i].GetAverageMark() == min && worstPupils.Count < 3)
            {
                worstPupils.Add(pupils[i]);
            }
        }

        Console.WriteLine("Worst Pupils");
        for (int i = 0; i < worstPupils.Count; i++)
        {
            worstPupils[i].PrintInfo();
        }

    }

    static bool CheckLogin(string login) // 1
    {
        char[] log = login.ToCharArray();

        /*if (  log.Length < 2 || log.Length > 10)
        {
            Console.WriteLine("Login must be from 2 to 10 chars");
            return false;
        }
        if (char.IsNumber(log[0]))
        {
            Console.WriteLine("Login cant start with number");
            return false;
        }*/

        Regex latin = new Regex(@"^\D[a-zA-Z0-9]{1,9}$");
        return latin.IsMatch(login);
    }

    private static void GameYesNo()  // Task 4     
    {
        StreamReader sr = new StreamReader("YesNo.txt");
        string str;
        string[] questions = new string[100];
        string[] answers = new string[100];
        int i = 0;
        
        while ((str = sr.ReadLine()) != null) // read file and get data
        {
            string[] parts = str.Split('.');
            questions[i] = parts[0];
            string ans;
            ans = parts[1].Remove(0, 2);
            answers[i] = ans.Remove(ans.Length - 1 , 1);
            i++;
        }
        
        sr.Close();

        int Points = 0;
        Random rnd = new Random();
        
        int[] oldQuestions = new int[100];
        
        string right = "Верно , + 1";
        string notRight = "Не верно , + 0";
        string lastAnswerResult = "Верно/Не верно";
        int randomQuestion;
        
        for (int j = 0; j < 100; j++)
        {
            //Console.Clear();

            Console.WriteLine($"Points : {Points} : {lastAnswerResult}");

            bool flag; // just simple var
            do
            {
                randomQuestion = rnd.Next(100); 
                flag = true;
                for (int k = 0; k < oldQuestions.Length; k++) // run trough massive
                {
                    if (randomQuestion == oldQuestions[k]) // find if that question already was
                    {
                        flag = false;
                    }
                }
            } while (!flag);
            oldQuestions[j] = randomQuestion;

            Console.WriteLine(questions[randomQuestion]);
            Console.Write("( Да / Нет )");
            
            string userAnswer = Console.ReadLine();
            userAnswer = userAnswer.ToLower();
            userAnswer.Replace(" ", "");

            if (userAnswer.CompareTo(answers[randomQuestion]) == 0) // right 
            {
                Points++;
                lastAnswerResult = right;
            }
            else
            {
                lastAnswerResult = notRight;
            }
        }
        Console.WriteLine($"Ты набрал : {Points} очков");
    } 
}

class Message // 2
{
    string message;
    
    public Message(string message)
    {
        this.message = message;
    }

    public void WordsNoMoreThan(int n)
    {
        string[] words = message.Split(' ');
        string newMessage = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length < n)
            {
                newMessage += words[i] + ' ';
            }
            else
            {
                
            }
        }

        Console.WriteLine(newMessage);
    }

    public void DeleteIfLastSymbolIs(char l)
    {
        string[] words = message.Split(' ');
        string newMessage = "";

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].LastIndexOf(l) + 1 != words[i].Length)
            {
                newMessage += words[i] + " ";
            }
            else
            {
                
            }
        }

        message = newMessage;
        Console.WriteLine(message);
    }

    public void PrintTheLongestWord()
    {
        string[] words = message.Split(' ');
        int maxLenght = words[0].Length;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > maxLenght)
            {
                maxLenght = words[i].Length;
            }
        }

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length == maxLenght)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

struct Pupil // 3
{
    string secondName;
    string name;
    int[] marks;

    public void SetName(string secondName , string name)
    {
        this.secondName = secondName;
        this.name = name;
    }

    public void SetMarks(int firstSub , int secondSub , int thirdSub)
    {
        marks = new int[3] {firstSub , secondSub , thirdSub };
    }

    public int GetAverageMark()
    {
        int average;
        int summ = 0;
        for (int i = 0; i < marks.Length; i++)
        {
            summ += marks[i];
        }

        average = summ / marks.Length;
        return average;
    }

    public void PrintInfo()
    {
        Console.Write($"{secondName} {name} {GetAverageMark()}");
        Console.WriteLine();
    }
}

