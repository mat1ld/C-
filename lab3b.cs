using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

class Program2
{
    static void Main(string[] args)
    {
        if(args.Length > 0){
			if(args[0] == "-f"){
				block1(args[1]);
			} else if(args[0] == "-c"){
				block2();
			} else{
				Console.WriteLine("Вы ввели некорректный флаг!\nНеобходимо указать флаг -f \"path\" для чтения данных из файла по адресу,\nлибо флаг -c для чтения данных из консоли.");
			}
		}
		
    }
	public static void block1(string path){
		Console.WriteLine(path);
		int count = 0;
		double product = 1;
		double harmonic = 0;
		string data;
		try{
			data = File.ReadAllText(path);
		} catch (Exception ex){
			Console.WriteLine("При чтении файла по адресу \"" + path + "\" возникла ошибка.\n" + ex.Message);
			return;
		}
		string[] numbers = data.Split(new char [] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
		foreach(string number in numbers){
			string correctStringNumber = number.Replace('.', ',');
			if(double.TryParse(correctStringNumber, NumberStyles.Any, CultureInfo.InvariantCulture, out double num)){
				if(num > 0){
					product *= num;
					harmonic += 1/num;
					count++;
				}
			} else{
				Console.WriteLine($"Ошибка. Введенный набор символ не является числом. '{number}'.");
			}
		}
		double geometric = Math.Pow(product, 1.0/count);
		double harmonicRes = harmonic/count;
		Console.WriteLine("Среднее геометрическое равно " + geometric);
		Console.WriteLine("Среднее гармоническое равно " + harmonicRes);
	}
	public static void block2(){
		List<double> numbers = new List<double>();
        Console.WriteLine("Введите числа (нажмите Esc, чтобы завершить ввод):");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "esc")
            {
                break;
            }
            string[] numberStrings = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string numberString in numberStrings)
            {
                double number = Convert.ToDouble(numberString);            
                numbers.Add(number);
            }
        }

        if (numbers.Count > 0)
        {
            double arithmeticMean = numbers.Average();
            double geometricMean = CalculateGeometricMean(numbers);
            double harmonicMean = CalculateHarmonicMean(numbers);
            Console.WriteLine($"Среднее арифметическое равно " + arithmeticMean);
            Console.WriteLine($"Среднее геометрическое равно " + geometricMean);
            Console.WriteLine($"Среднее гармоническое равно " + harmonicMean);
        }
        else
        {
            Console.WriteLine("Нет введенных чисел для вычисления.");
        }
	}
	static double CalculateGeometricMean(List<double> numbers)
    {
        double product = 1;
        foreach (var number in numbers)
        {
            product *= number;
        }
        return Math.Pow(product, 1.0 / numbers.Count);
    }

    static double CalculateHarmonicMean(List<double> numbers)
    {
        double sumOfReciprocals = numbers.Sum(number => 1 / number);
        return numbers.Count / sumOfReciprocals;
    }
}
