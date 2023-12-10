using System;
using System.IO;

public delegate double myF(double x);
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) 
        {
            double a = -1.5, b = 2.0;
            double epsilon = 0.0001;
            double result = methodDihotomii(f3, a, b , epsilon);
            Console.WriteLine("Решение уравнения y = f(x) методом дихотомии c точностью " + epsilon + " равно " + result);
        }

        public static double f1(double x){
            return Math.Exp(x) + 7*x + 4; // y = e^x + 7x + 4
        }

        public static double f2(double x){
            return Math.Exp(x) - 2;   // y = e ^ x -2
        }
        public static double f3(double x){
            return Math.Pow(x, 2.0) + 5 * x + 7; // y = x ^ 2 + 5x + 7
        }

        public static double f4(double x){
            return Math.Pow(x, 3.0);    // y = x^3
        }
        public static double methodDihotomii (myF mf, double a, double b, double epsilon){
                double c = 0;
                do{
                    c = (a + b) / 2.0;
                    if( (mf(a) * mf(c)) < 0){
                        b = c;
                    } else if ((mf(b) * mf(c)) < 0){
                        a = c;
                    } else{
                        Console.WriteLine("Корень не найден.");
                        Environment.Exit(0);

                    }
                } while(Math.Abs(b - a) > epsilon);
                return c;
        }
    }
}