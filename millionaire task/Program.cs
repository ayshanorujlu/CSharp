using System;
using System.Collections.Specialized;
using System.Drawing;

string[] quiz =
{
    "Where is the capital of India?",//b
    "Where is the capital of Canada? ",//c
    "Where is the capital of Brazil?",//b
    "Where is the capital of Azerbaijan?",//a
    "Where is the capital of Argentina?",//c
};

string[][] variants = new string[5][];
variants[0] = new string[3] { "Baku ", "New Delhi", "Ankara" };
variants[1] = new string[3] { "Vienna", "Luanda", "Ottawa" };
variants[2] = new string[3] { "Ottawa", "Brasilia", "Prague" };
variants[3] = new string[3] { "Baku", "Luanda ", "Gandja" };
variants[4] = new string[3] { "Dhaka", "Vienna", "Buenos Aires" };

string[] answers =
{
    "New Delhi",
    "Ottawa ",
    "Brasilia",
    "Baku",
    "Buenos Aires"
};

string answer1;
string answer2;
string answer3;


void DeleteElementFromArray(ref string[] array, int index)
{
    string[] temp = new string[array.Length - 1];
    for (int i = 0; i < index; i++)
    {
        temp[i] = array[i];
    }
    for (int i = index; i < array.Length - 1; i++)
    {
        temp[i] = array[i + 1];
    }
    array = temp;
}

void CorrectVariant(ref int point)
{
    Console.Clear();
    point += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Correct variant!");
    Thread.Sleep(1000);
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
}

void WrongVariant(ref int point)
{
    Console.Clear();
    point -= 10;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Wrong variant!");
    Thread.Sleep(1000);
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
}

void ShowPoint(int point)
{
    if (point >= 0)
    {
        Console.WriteLine("Your point:" + point);
    }
    else
    {
        Console.WriteLine("Your point:" + 0);
    }
}

int point = 0;
Random random = new Random();

for (int i = 0; i < quiz.Length; i++)
{
    Console.WriteLine(i + 1 + "." + quiz[i]);
    int j = random.Next(0, variants[i].Length - 1);
    answer1 = variants[i][j];
    DeleteElementFromArray(ref variants[i], j);
    Console.WriteLine("A." + answer1);
    j = random.Next(0, variants[i].Length - 1);
    answer2 = variants[i][j];
    DeleteElementFromArray(ref variants[i], j);
    Console.WriteLine("B." + answer2);
    j = random.Next(0, variants[i].Length - 1);
    answer3 = variants[i][j];
    DeleteElementFromArray(ref variants[i], j);
    Console.WriteLine("C." + answer3);
    Console.WriteLine("Choose Variant || A | B | C ");
    ShowPoint(point);
labelquiz:
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.A)
    {
        if (answer1 == answers[i])
        {
            CorrectVariant(ref point);
        }
        else
        {
            WrongVariant(ref point);
        }
    }
    else if (key.Key == ConsoleKey.B)
    {
        if (answer2 == answers[i])
        {
            CorrectVariant(ref point);
        }
        else
        {
            WrongVariant(ref point);
        }
    }
    else if (key.Key == ConsoleKey.C)
    {
        if (answer3 == answers[i])
        {
            CorrectVariant(ref point);
        }
        else
        {
            WrongVariant(ref point);
        }
    }
    else
    {
        goto labelquiz;
    }
}

Console.WriteLine("FINISHED!");
Console.WriteLine("Total point:" + point);




