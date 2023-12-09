using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
             CalculateExponential();
             CalculatePi();
             CalculateLn();
             CalculateSqrt();
             CalculateGamma();
        }
        public static void CalculateExponential()
        {
            //double epsilon = 0.001;
            Console.WriteLine("Введите уровень погрешности:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            exp1(epsilon);
            exp2(epsilon);
            exp3(epsilon);
        }
        public static void exp1(double epsilon)
        {
            double n = 2;
            double previous = Math.Pow((1.0 + 1.0 / n), n);
            while (true)
            {
                n++;
                double current = Math.Pow((1.0 + 1.0 / n), n);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Экспонента" + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void exp2(double epsilon)
        {
            long n = 0;
            double previous = 1.0 / (double)factorial(n);
            n++;
            previous += 1.0 / (double)factorial(n);
            while (true)
            {
                n++;
                double current = previous + 1.0 / (double)factorial(n);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Экспонента" + previous + " при заданной точности " + epsilon);
                    break;
                }
            }

        }
        public static void exp3(double epsilon)
        {
            double step = epsilon / 10;
            double previous = step;
            while (true)
            {
                double current = previous + step;
                if (Math.Abs(1.0 - Math.Log(current)) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Экспонента" + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void CalculatePi()
        {
            //double epsilon = 0.00001;
            Console.WriteLine("Введите уровень погрешности:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
             pi1(epsilon);
             pi2(epsilon);
             pi3(epsilon);
        }
        public static void pi1(double epsilon)
        {
            epsilon = epsilon < 0.001 ? 0.00999 : epsilon;
            long n = 1;
            double previous = Math.Pow(2, 4 * n) * Math.Pow(factorial(n), 4) / n / Math.Pow(factorial(2 * n), 2);
            while (true)
            {
                n++;
                double current = Math.Pow(2, 4 * n) * Math.Pow(factorial(n), 4) / n / Math.Pow(factorial(2 * n), 2);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Пи " + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void pi2(double epsilon)
        {
            long n = 1;
            double previous = Math.Pow(-1, n + 1) / (2 * n - 1);
            double accum = previous;
            while (true)
            {
                n++;
                double current = Math.Pow(-1, n + 1) / (2 * n - 1);
                if (Math.Abs(current - previous) > epsilon)
                {
                    accum += current;
                    previous = current;
                }
                else
                {
                    accum *= 4;
                    Console.WriteLine("Пи " + accum + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void pi3(double epsilon)
        {
            for (double i = 0; i <= 2 * Math.PI; i += epsilon / 10.0)
            {
                double value = Math.Cos(i);
                if (Math.Abs(value + 1) < epsilon)
                {
                    Console.WriteLine("Пи " + i + " при заданной точности " + epsilon);
                    break;
                }
            }

        }
        public static void CalculateLn()
        {
            //double epsilon = 0.00001;
            Console.WriteLine("Введите уровень погрешности:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
             ln1(epsilon);
             ln2(epsilon);
             ln3(epsilon);
        }
        public static void ln1(double epsilon)
        {
            double n = 1;
            double previous = n * (Math.Pow(2, (1.0 / n)) - 1);
            while (true)
            {
                n++;
                double current = n * (Math.Pow(2, (1.0 / n)) - 1);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Натуральный логарифм 2 равен " + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void ln2(double epsilon)
        {
            double n = 1;
            double previous = Math.Pow(-1, n - 1) / n;
            while (true)
            {
                n++;
                double current = previous + Math.Pow(-1, n - 1) / n;
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Натуральный логарифм 2 равен " + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void ln3(double epsilon)
        {
            double step = epsilon / 10.0;
            double x = step;
            while (true)
            {
                if (Math.Abs(Math.Exp(x) - 2.0) > epsilon)
                {
                    x += step;
                }
                else
                {
                    Console.WriteLine("Натуральный логарифм 2 равен " + x + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void CalculateSqrt()
        {
            //double epsilon = 0.001;
            Console.WriteLine("Введите уровень погрешности:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            sqrt1(epsilon);
            sqrt2(epsilon);
            sqrt3(epsilon);
        }
        public static void sqrt1(double epsilon)
        {
            double n = 2;
            double x = 1;
            for (; ; )
            {
                double nx = (x + n / x) / 2;
                if (Math.Abs(x - nx) < epsilon)
                {
                    break;
                }
                x = nx;
            }
            Console.WriteLine("Корень из двух равен " + x + " при заданной точности " + epsilon);
        }
        public static void sqrt2(double epsilon)
        {
            int k = 2;

            double previous = Math.Pow(2, Math.Pow(2, -k));

            while (true)
            {
                k++;
                double current = previous * Math.Pow(2, Math.Pow(2, -k));
                if (Math.Abs(previous - current) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Корень из двух равен " + previous + " при заданной точности " + epsilon);
                    break;
                }
            }
        }
        public static void sqrt3(double epsilon)
        {
            double step = epsilon / 10.0;
            double x = step;
            while (true)
            {
                if (Math.Abs(Math.Pow(x, 2) - 2.0) > epsilon)
                {
                    x += step;
                }
                else
                {
                    Console.WriteLine("Корень из 2 равен " + x + " при заданной точности " + epsilon);
                    break;
                }

            }
        }
        public static void CalculateGamma()
        {
            //double epsilon = 0.00001;
            Console.WriteLine("Введите уровень погрешности:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
             gamma1(epsilon);
             gamma2(epsilon);
             gamma3(epsilon);
        }
        public static void gamma1(double epsilon)
        {
            int n = (int)(1.0 / epsilon) * 100;
            double accum = 1.0;
            double previous = 1.0;
            for(int i = 2; i < n; i++)
            {
                double current = accum + (1.0 / i) - Math.Log(n);
                if(Math.Abs(current - previous) > epsilon)
                {
                    accum += 1.0 / i;
                    previous = current;
                }
                else
                {
                    accum = accum - Math.Log(i);
                    Console.WriteLine("Значение константы Эйлера-Маскерони равно " + accum + " при заданном уровне погрешности " + epsilon);
                    break;
                }
            }
        }
        public static void gamma2(double epsilon)
        {
            long k = 1;
            double n = 1.0 / epsilon;
            double previous = (-Math.Pow(Math.PI, 2))/6;
            while (k < n)
            {
                k++;
                previous += (1.0 / Math.Pow(((int)Math.Sqrt(k)), 2) - 1.0 / k);
            }
            Console.WriteLine("Значение константы Эйлера - Маскерони равно " + previous + " при заданном уровне погрешности " + epsilon);
        }
        public static void gamma3(double epsilon)
        {
            int k = 2;
            double previous = (((double)(k - 1)) / k);
            while (true)
            {
                k++;
                double current = 1;
                if (NumberIsPrime(k))
                {
                    current = (((double)(k - 1)) / k);
                }
                else
                {
                    continue;
                }
                if (Math.Abs(current*previous - previous) > epsilon)
                {
                    previous *= current;
                }
                else
                {
                    previous *= Math.Log(k);
                    Console.WriteLine("Значение экспоненты в степени минус гамма равно " + previous);
                    break;
                }
            }
        }
        public static bool NumberIsPrime(int number)
        {
            if(number <= 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }
            if(number % 2 == 0)
            {
                return false;
            }
            for(int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static long factorial(long number)
        {
            if (number == 0)
            {
                return 1;
            }
            long result = 1;
            for (long i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        static long CalculateCombination(int n, int k)
        {
            if (k < 0 || k > n)
            {
                throw new ArgumentException("k должно быть большо 0, но меньше n");
            }
            long numenator = factorial(n);
            long denominator = factorial(k) * factorial(n - k);
            return numenator / denominator;
        }
               
    }
}
