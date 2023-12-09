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
             backgroundInformation();
             applicationQubic();
        }

        static void backgroundInformation()
        {
            Console.WriteLine("Данное приложение позволяет вычислить корни кубического уравнения.");
            Console.WriteLine("Вычисление корней кубического уравнения осуществляется двумя способами:");
            Console.WriteLine("1) Вычисление кубическиъх корней с помощью метода Вието-Кардано.");
            Console.WriteLine("2) C помощью бинарного поиска.");
            Console.WriteLine("3) Срванение результатов 1) и 2) способов.\n");
        }
        public static List<double> methodVietaCordano()
        {
            List<double> Li = new List<double>();
            Console.WriteLine("Введите коэффициенты a, b, c, d кубического уравнения ax^3 + bx^2 + cx + d = 0 через пробел:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double a = double.Parse(s_split[0]);
            double b = double.Parse(s_split[1]);
            double c = double.Parse(s_split[2]);
            double d = double.Parse(s_split[3]);
            Console.WriteLine("Введите уровень значимости(рекомендуется выбирать значение меньше, чем 0.001):");
            str = Console.ReadLine();
            s_split = str.Split();
            double eps = double.Parse(s_split[0]);
            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
            double discremenant = q * q / 4 + p * p * p / 27;
            if(Math.Abs(discremenant) < eps)
            {
                discremenant = 0;
            }
            if(discremenant > 0)
            {
                double u = -q / 2 + Math.Sqrt(discremenant);
                u = Math.Exp(Math.Log(u) / 3);
                double y = u - p / (3 * u);
                double x1 = y - b / (3 * a);
                double x2 = -(u - p / (3 * u)) / 2 - b / (3 * a);
                double x3 = Math.Sqrt(3) / 2 * (u + p / (3 * u));
                Li.Add(x1);
                Li.Add(x2);
                Li.Add(x3);
                return Li;
            }
            else
            {
                if(discremenant < 0)
                {
                    double phi;
                    if(Math.Abs(q) < eps)
                    {
                        phi = Math.PI / 2;
                    }
                    else
                    {
                        if(q < 0)
                        {
                            phi = Math.Atan(Math.Sqrt(-discremenant) / (-q / 2));
                        }
                        else
                        {
                            phi = Math.Atan(Math.Sqrt(-discremenant) / (-q / 2)) +Math.PI;
                        }
                    }
                    double r = 2 * Math.Sqrt(-p / 3);
                    double x1 = r * Math.Cos(phi / 3) - b / (3 * a);
                    double x2 = r * Math.Cos((phi + 2 * Math.PI) / 3) - b / (3 * a);
                    double x3 = r * Math.Cos((phi + 4 * Math.PI) / 3) - b / (3 * a);
                    Li.Add(x1);
                    Li.Add(x2);
                    Li.Add(x3);
                    return Li;
                }
                else
                {
                    if(Math.Abs(q) < eps)
                    {
                        double x1 = -b / (3 * a);
                        Li.Add(x1);
                        return Li;
                    }
                    else
                    {
                        double u = Math.Exp(Math.Log(Math.Abs(q) / 2) / 3);
                        if(q < 0)
                        {
                            u = -u;
                        }
                        double x1 = -2 * u - b / (3 * a);
                        double x2 = u - b / (3 * a);
                        Li.Add(x1);
                        Li.Add(x2);
                        return Li;
                    }
                }
            }
        }
        static List<double> methodBinarySearch()
        {
            Console.WriteLine("Введите коэффициенты a, b, c, d кубического уравнения ax^3 + bx^2 + cx + d = 0 через пробел:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            int a = int.Parse(s_split[0]);
            int b = int.Parse(s_split[1]);
            int c = int.Parse(s_split[2]);
            int d = int.Parse(s_split[3]);
            if(a < 0)
            {
                a = -a;
                b = -b;
                c = -c;
                d = -d;
            }
            Console.WriteLine("Введите левую и правую границы для бинарного поиска:");
            str = Console.ReadLine();
            s_split = str.Split();
            double leftBound = int.Parse(s_split[0]);
            double rightBound = int.Parse(s_split[1]);
            Console.WriteLine("Введите уровень значимости(рекомендуется выбирать значение меньше, чем 0.001):");
            str = Console.ReadLine();
            s_split = str.Split();
            double eps = double.Parse(s_split[0]);
            while(rightBound - leftBound > eps)
            {
                double mid = (leftBound + rightBound) / 2.0;
                double value = a * mid * mid * mid + b * mid * mid + c * mid + d;
                if(Math.Abs(value) <= eps)
                {
                    break;
                } else if (value > 0)
                {
                    rightBound = mid;
                }
                else
                {
                    leftBound = mid;
                }
            }
            Console.WriteLine("Результат вычисления кубического уравнения методом бинарного поиска равен " + ((leftBound + rightBound) / 2.0));
            List<double> li = new List <double>();
            li.Add((leftBound + rightBound) / 2.0);
            return li;
        }
        static void applicationQubic() {
            bool marker = false;
            List<double> li= new List<double>();
            while (true)
            {
                int label = Convert.ToInt32(Console.ReadLine());
                switch (label)
                {
                    case 1:
                        li = methodVietaCordano();
                        marker = true;
                        break;
                    case 2:
                        li = methodBinarySearch();
                        marker = true;
                        break;
                    case 3:
                        li = methodVietaCordano();
                        li = methodBinarySearch();
                        marker = true;
                        break;
                    default:
                        break;
                }
                if (marker)
                {
                    System.Environment.Exit(1);
                }
            }


        }
    }
}
