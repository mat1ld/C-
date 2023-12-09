using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите вещественное число: ");
        double number = Convert.ToDouble(Console.ReadLine()); // "2.8937" --> 2.8937

        Console.Write("Введите систему счисления, в которую надо перевести вещественное число: "); //  "[2...36]" -- > [2...36] 
        int toBase = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите точность знаков для дробной части: ");
        int precision = Convert.ToInt32(Console.ReadLine());

        string result = ConvertToBaseWithPrecision(number, toBase, precision);
        Console.WriteLine("Результат перевода: " + result);
    }

    static string ConvertToBaseWithPrecision(double number, int toBase, int precision)
    {
        
        int integerPart = (int)number;
        double fractionalPart = number - Math.Floor(number);

        string result = ConvertIntegerPart(integerPart, toBase) + "." + ConvertFractionalPart(fractionalPart, toBase, precision);
        return result;
    }

    static string ConvertIntegerPart(int number, int toBase)
    {
        if (number == 0)
            return "0";

        string result = "";
        while (number > 0)
        {
            int remainder = number % toBase;
            result = CharForValue(remainder) + result;
            number /= toBase;
        }
        return result;
    }

    static string ConvertFractionalPart(double number, int toBase, int precision)
    {
        string result = "";
        for (int i = 0; i < precision; i++)
        {
            number *= toBase;
            int wholePart = (int)Math.Floor(number);
            result += CharForValue(wholePart);
            number -= wholePart;
        }
        return result;
    }

    static char CharForValue(int value)
    {
        if (value < 10)
            return (char)('0' + value);
        else
            return (char)('A' + value - 10);
    }
}